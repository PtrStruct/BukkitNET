using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BukkitNET.Core;
using BukkitNET.MVVM.Model;
using BukkitNET.MVVM.View;

namespace BukkitNET.MVVM.ViewModel
{
    public class ServersViewModel : ObservableObject
    {
        public RelayCommand AddServerModelCommand { get; set; }
        public RelayCommand ShowEditServerCommand { get; set; }


        public ObservableCollection<ServerModel> ServerCollection { get; set; }
        public ServersViewModel()
        {

            /*Commands*/
            AddServerModelCommand = new RelayCommand(o =>
            {
                ServerCollection.Add(new ServerModel());


            }, o => true);


            ShowEditServerCommand = new RelayCommand(o =>
            {
                var servermodel = o as ServerModel;

                BlurRadius = 10;
                var servereditView = new ServerEditView(this);
                servereditView.DataContext = servermodel;
                servereditView.ShowDialog();

            }, o => true);


            ServerCollection = new ObservableCollection<ServerModel>();

            ServerCollection.Add(new ServerModel { ServerName = "Craftarctica", ServerVersion = "1.14.2", Status = "Online" });
            ServerCollection.Add(new ServerModel { ServerName = "Octagon", ServerVersion = "1.14.2", Status = "Offline" });
            ServerCollection.Add(new ServerModel { ServerName = "ReinsOfMinecraft", ServerVersion = "1.14.2", Status = "Offline" });

            BlurRadius = 0;
        }

        private int _blurRadius;

        public int BlurRadius
        {
            get { return _blurRadius; }
            set
            {
                _blurRadius = value;
                OnPropertyChanged();
            }
        }



    }
}
