using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.Core;
using BukkitNET.Services;

namespace BukkitNET.MVVM.Model
{

    [Serializable]
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
            set
            {
                _serverVersion = value;
                OnPropertyChanged();

            }
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
