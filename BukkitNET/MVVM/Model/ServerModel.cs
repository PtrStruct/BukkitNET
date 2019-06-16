using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.Core;

namespace BukkitNET.MVVM.Model
{
    class ServerModel : ObservableObject
    {
        public ServerModel()
        {
            
        }

        private string _serverName;

        public string ServerName
            {
            get { return _serverName; }
            set { _serverName = value; }
        }

    }
}
