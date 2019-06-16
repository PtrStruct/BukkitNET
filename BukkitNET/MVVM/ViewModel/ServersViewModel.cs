using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.MVVM.Model;

namespace BukkitNET.MVVM.ViewModel
{
    class ServersViewModel
    {
        public ObservableCollection<ServerModel> ServerCollection { get; set; }
        public ServersViewModel()
        {
            ServerCollection = new ObservableCollection<ServerModel>();

            ServerCollection.Add(new ServerModel { ServerName = "Craftarctica", ServerVersion = "1.14.2", Status = "Online" });
            ServerCollection.Add(new ServerModel { ServerName = "Octagon", ServerVersion = "1.14.2", Status = "Offline" });
            ServerCollection.Add(new ServerModel { ServerName = "ReinsOfMinecraft", ServerVersion = "1.14.2", Status = "Offline" });
        }
    }
}
