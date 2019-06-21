using System;
using System.Collections.ObjectModel;
using BukkitNET.Core;
using BukkitNET.MVVM.Model;
using BukkitNET.MVVM.View;
using BukkitNET.Services;

namespace BukkitNET.MVVM.ViewModel
{
    public class ServersViewModel : ObservableObject
    {
        public RelayCommand AddServerModelCommand { get; set; }
        public RelayCommand DeleteServerCommand { get; set; }
        public RelayCommand ShowEditServerCommand { get; set; }
        public RelayCommand SaveServerCommand { get; set; }

        

        public ObservableCollection<ServerModel> ServerCollection { get; set; }
        public ServersViewModel()
        {
            /*Commands*/
            AddServerModelCommand = new RelayCommand(o =>
            {
                ServerCollection.Add(new ServerModel());
            }, o => true);
            DeleteServerCommand = new RelayCommand(o => { ServerCollection.Remove(o as ServerModel); ServerListService.SaveServer(ServerCollection); }, o => true);

            ShowEditServerCommand = new RelayCommand(o =>
            {
                var servermodel = o as ServerModel;

                BlurRadius = 10;
                var servereditView = new ServerEditView(this);
                servereditView.DataContext = servermodel;
                servereditView.ShowDialog();
                IsModalVisible = true;

            }, o => true);

            ServerCollection = ServerListService.LoadServers();

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

        private bool isModalVisible;

        public bool IsModalVisible
        {
            get { return isModalVisible; }
            set
            {
                isModalVisible = value;
                OnPropertyChanged();
            }
        }




    }
}
