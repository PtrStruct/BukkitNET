using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BukkitNET.Core;
using BukkitNET.MVVM.Model;
using BukkitNET.Services;

namespace BukkitNET.MVVM.ViewModel
{

    class ConsoleViewModel : ObservableObject
    {
        static StreamWriter WriteCommands;



        public string ConsoleLogFilePath { get; set; }
        public ObservableCollection<string> ConsoleLogMessages { get; set; }
        public RelayCommand EnterCommand { get; set; }

        public ServerModel ServerInstance { get; set; }

        private string _currentCommand;

        public string CurrentCommand
        {
            get { return _currentCommand; }
            set
            {
                _currentCommand = value;
                OnPropertyChanged();
            }
        }


        private ServerModel _onlineServerModel;

        public ServerModel OnlineServerModel
        {
            get { return _onlineServerModel; }
            set
            {
                _onlineServerModel = value;
                OnPropertyChanged();
            }
        }


        public string TestProperty { get; set; }

        public ConsoleViewModel()
        {

            //var d = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
            //                          $@"\BukkitNET\ConsoleLogs");
            //var file = d.GetFiles()
            //    .OrderByDescending(f => f.LastWriteTime)
            //    .FirstOrDefault();

            ConsoleLogMessages = new ObservableCollection<string>();

            EnterCommand = new RelayCommand(o =>
            {
                //Start Armada
                ProcessCommand(o as string);

            }, o => true);


            if (!String.IsNullOrEmpty(ConsoleLogFilePath))
            {
                foreach (var consoleMessage in File.ReadAllLines(ConsoleLogFilePath))
                {
                    ConsoleLogMessages.Add(consoleMessage);
                }
            }
        }


        public void ProcessCommand(string command)
        {
            var serverName = command.Split(' ')[1];
            var Server = ServerListService.LoadServers().FirstOrDefault(x => x.ServerName == serverName);
            var IsAnyServerStarted = ServerListService.LoadServers().Any(x => x.Status == "online");

            switch (command.Split(' ')[0].ToLower())
            {
                case "start":
                    if (!IsAnyServerStarted)
                    {
                        if (Server != null)
                        {
                            StartServer(Server);
                            ServerListService.UpdateEntry(Server, "online");
                            OnlineServerModel = Server;
                            CurrentCommand = "";
                        }
                        else
                            Debug.Print($"Server {serverName} not found.");
                    }
                    else
                    {
                        Debug.Print($"A server is already started.");

                    }
                    break;

                case "stop":
                    if (Server != null)
                    {
                        ServerService.StopServer(Server);
                        ServerListService.UpdateEntry(Server, "offline");
                        CurrentCommand = "";

                    }
                    break;

                default:
                    WriteCommands?.WriteLineAsync(command);
                    CurrentCommand = "";

                    break;
            }
        }

        public void StartServer(ServerModel ServerModel)
        {
            ServerInstance = ServerModel;
            Debug.Print($"Starting server: {ServerModel.ServerName}");
            ConsoleLogMessages.Clear();

            var jarPath = ServerModel.JarPath;
            var startInfo = new ProcessStartInfo(@"java -Xmx" + 1024 + "M -Xms" + 1024 + "M -jar " + jarPath + " " + "nogui");

            //Generate files to this folder.
            startInfo.WorkingDirectory = Path.GetDirectoryName(jarPath);
            Process Minecraft = new Process();
            Minecraft.StartInfo = startInfo;
            Minecraft.StartInfo.FileName = "CMD.exe";
            Minecraft.StartInfo.CreateNoWindow = true;
            Minecraft.StartInfo.RedirectStandardInput = true;
            Minecraft.StartInfo.RedirectStandardOutput = true;
            Minecraft.StartInfo.RedirectStandardError = true;
            Minecraft.StartInfo.UseShellExecute = false;
            Minecraft.OutputDataReceived += ServerProc_OutputDataReceived;
            Minecraft.ErrorDataReceived += ServerProcOnErrorDataReceived;
            Minecraft.Start();
            Minecraft.BeginOutputReadLine();
            Minecraft.BeginErrorReadLine();
            WriteCommands = Minecraft.StandardInput;
            WriteCommands.WriteLineAsync(@"java -Xmx" + 1024 + "M -Xms" + 1024 + "M -jar " + jarPath + " " + "nogui");
        }


        public void StopServer(ServerModel sm)
        {
            Debug.Print($"Stopping server: {sm.ServerName}");
            ConsoleLogMessages.Add($"Stopping server: {sm.ServerName}");
        }

        private void ServerProc_Exited(object sender, EventArgs e) { Debug.Print("Server stopped."); }

        private void ServerProc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.Print(e.Data);
            var chunks = GetDataChunks(e.Data);
            try
            {
                switch (chunks[2])
                {
                    case "Authenticator":
                        UsersViewModel.ParseLogin(chunks[7]);
                        Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
                        break;

                    case "thread/INFO":
                        if (String.Equals(chunks[2], "Disconnected"))
                        {

                        }
                        Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
                        break;

                    default:
                        Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
                        break;
                }
            }
            catch (Exception exception)
            {
                Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
            }
            
        }

        private void ServerProcOnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.Print(e.Data);
            Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
        }

        private string[] GetDataChunks(string data)
        {
            return data.Split(' ');
        }

    }
}
