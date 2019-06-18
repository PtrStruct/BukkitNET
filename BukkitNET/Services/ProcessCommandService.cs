using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.MVVM.View;
using BukkitNET.MVVM.ViewModel;

namespace BukkitNET.Services
{
    class ProcessCommandService
    {
        public ProcessCommandService()
        {

        }

        public static void ProcessCommand(string command)
        {
            var serverName = command.Split(' ')[1];
            var Server = ServerListService.LoadServers().FirstOrDefault(x => x.ServerName == serverName);

            switch (command.Split(' ')[0].ToLower())
            {
                case "start":

                    if (Server != null)
                    {
                        ServerService.StartServer(Server);
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
    }
}
