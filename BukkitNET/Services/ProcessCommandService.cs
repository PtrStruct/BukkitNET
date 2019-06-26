using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.MVVM.View;
using BukkitNET.MVVM.ViewModel;

namespace BukkitNET.Services
{
    class ProcessCommandService
    {
        //static StreamWriter WriteCommands;

        public ProcessCommandService()
        {

        }

        //public void ProcessCommand(string command)
        //{
        //    var serverName = command.Split(' ')[1];
        //    var Server = ServerListService.LoadServers().FirstOrDefault(x => x.ServerName == serverName);

        //    switch (command.Split(' ')[0].ToLower())
        //    {
        //        case "start":
        //            if (Server != null)
        //            {
        //                ConsoleViewModel cvm = new ConsoleViewModel();
        //                cvm.StartServer(Server);
        //                ServerListService.UpdateEntry(Server, "online");
        //            }
        //            else
        //                Debug.Print($"Server {serverName} not found.");
        //            break;

        //        case "stop":
        //            if (Server != null)
        //            {
        //                ServerService.StopServer(Server);
        //                ServerListService.UpdateEntry(Server, "offline");
        //            }
        //            break;
        //    }
        //}
    }
}
