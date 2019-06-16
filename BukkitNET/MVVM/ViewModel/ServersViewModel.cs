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

            for (int i = 0; i < 3; i++)
            {
                ServerCollection.Add(new ServerModel { ServerName = "My Server" });
            }
        }
    }
}
