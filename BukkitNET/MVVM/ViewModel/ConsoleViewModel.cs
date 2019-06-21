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

            switch (command.Split(' ')[0].ToLower())
            {

                case "start":
                    if (Server != null)
                    {
                        StartServer(Server);
                        ServerListService.UpdateEntry(Server, "online");
                    }
                    else
                        Debug.Print($"Server {serverName} not found.");
                    break;

                case "stop":
                    if (Server != null)
                    {
                        ServerService.StopServer(Server);
                        ServerListService.UpdateEntry(Server, "offline");
                    }
                    break;
            }
        }

        public void StartServer(ServerModel ServerModel)
        {
            //ConsoleLogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
            //               $@"\BukkitNET\ConsoleLogs\Log - " + string.Format("{0:yyyy-MM-dd_hh-mm-ss-fff}", DateTime.Now) + ".dat";

            //using (var uh = File.Create(ConsoleLogFilePath)) { }

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
            Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
        }

        private void ServerProcOnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.Print(e.Data);
            Application.Current.Dispatcher.Invoke(() => { ConsoleLogMessages.Add(e.Data); });
        }
    }
}
