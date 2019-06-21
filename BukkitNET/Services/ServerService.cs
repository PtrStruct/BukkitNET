using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.MVVM.Model;
using BukkitNET.MVVM.ViewModel;

namespace BukkitNET.Services
{
    class ServerService
    {
        static StreamWriter WriteCommands;

        public ServerService()
        {

        }

        public static void StartServer(ServerModel ServerModel)
        {
            Debug.Print($"Starting server: {ServerModel.ServerName}");


            var jarPath = ServerModel.JarPath;

            var startInfo = new ProcessStartInfo("java", "-Xmx1024M -Xms1024M -jar " + jarPath + " nogui");
            //startInfo.WorkingDirectory = ServerPath;


            Process Minecraft = new Process();
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


        public static void StopServer(ServerModel sm)
        {
            Debug.Print($"Stopping server: {sm.ServerName}");
        }

        private static void ServerProc_Exited(object sender, EventArgs e)
        {
            Debug.Print("Server stopped.");
        }

        private static void ServerProc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.Print(e.Data);
        }

        private static void ServerProcOnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.Print(e.Data);
        }
    }
}
