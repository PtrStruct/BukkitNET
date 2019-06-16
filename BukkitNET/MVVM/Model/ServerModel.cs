using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.Core;

namespace BukkitNET.MVVM.Model
{
    public class ServerModel : ObservableObject
    {
        public ServerModel()
        {
            
        }

        private string _serverName;

        public string ServerName
            {
            get { return _serverName; }
            set
            {
                _serverName = value;
                OnPropertyChanged();
            }
        }

        private string _serverVersion;

        public string ServerVersion
        {
            get { return _serverVersion; }
            set { _serverVersion = value; }
        }


        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value; 
                OnPropertyChanged();
            }
        }

        private string _jarPath;

        public string JarPath
        {
            get { return _jarPath; }
            set
            {
                _jarPath = value; 
                OnPropertyChanged();
            }
        }



    }
}
