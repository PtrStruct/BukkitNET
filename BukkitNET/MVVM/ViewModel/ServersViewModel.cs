using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BukkitNET.Core;
using BukkitNET.MVVM.Model;
using BukkitNET.MVVM.View;
using BukkitNET.Services;

namespace BukkitNET.MVVM.ViewModel
{
    public class ServersViewModel : ObservableObject
    {
        public RelayCommand AddServerModelCommand { get; set; }
        public RelayCommand ShowEditServerCommand { get; set; }

        public RelayCommand SaveServerCommand { get; set; }


        public ObservableCollection<ServerModel> ServerCollection { get; set; }
        public ServersViewModel()
        {
            ServerCollection = new ObservableCollection<ServerModel>();
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
                IsModalVisible = true;

            }, o => true);

            //Deserialize data from Servers.dat
            //C:\Users\developer\source\repos\BukkitNET\BukkitNET\bin\Debug\Servers.dat
            //C:\Users\developer\AppData\Local\BukkitNET\UserConfig\BukkitNET\Servers.bin

            //if (!File.Exists(@"C:\Users\developer\source\repos\BukkitNET\BukkitNET\bin\Debug\Servers.dat"))
            //    File.Create("Servers.dat");
            //{

            //}

            if (File.ReadAllText("Servers.dat").Length > 0)
            {
                using (FileStream fs = new FileStream(@"C:\Users\developer\source\repos\BukkitNET\BukkitNET\bin\Debug\Servers.dat", FileMode.Open))
                {

                    BinaryFormatter formatter = new BinaryFormatter();

                    // Deserialize the hashtable from the file and 
                    // assign the reference to the local variable.
                    //ObservableCollection<ServerModel> server = (ObservableCollection<ServerModel>)formatter.Deserialize(fs);

                    ServerCollection = (ObservableCollection<ServerModel>)formatter.Deserialize(fs);

                }
            }



            //SaveServerCommand = new RelayCommand(o => { ServerListService.SaveServer(o as ServerModel); }, o => true);



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
