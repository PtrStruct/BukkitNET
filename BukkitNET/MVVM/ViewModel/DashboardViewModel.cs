using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BukkitNET.Core;

namespace BukkitNET.MVVM.ViewModel
{
    class DashboardViewModel : ObservableObject
    {
        public DashboardViewModel()
        {
            OnlinePlayers = "0 / 20";
        }

        private string _onlinePlayers;

        public string OnlinePlayers
        {
            get { return _onlinePlayers; }
            set
            {
                _onlinePlayers = value;
                OnPropertyChanged();
            }
        }
    }
}
