using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.MVVM.Model;

namespace BukkitNET.Services
{
    class ServerListService
    {

        public static string path = $@"{Environment.SpecialFolder.LocalApplicationData} \BukkitNET\Servers.dat";

        public static DirectoryInfo DataStorageDirectory =
            new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\BukkitNET\UserConfig\" +
                              System.Reflection.Assembly.GetEntryAssembly().GetName().Name);

        public ServerListService()
        {

        }


        private static void ReferenceExist()
        {
            if (!Directory.Exists($"{Environment.SpecialFolder.LocalApplicationData} \\BukkitNET"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                          @"\BukkitNET");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                             @"\BukkitNET\Servers.dat"))
            {
                using (var fc = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                            @"\BukkitNET\Servers.dat")) ;
            }
        }

        public static void UpdateEntry(ServerModel sm, string status)
        {
            //Load the collection
            //Query the collection
            //Update the entry
            //Save the collection

            //Each entry is a reference object

            var collection = LoadServers();

            collection.FirstOrDefault(x => x.ServerName == sm.ServerName).Status = status;
            SaveServer(collection);
        }

        public static ObservableCollection<ServerModel> LoadServers()
        {
            ReferenceExist();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                                  @"\BukkitNET\Servers.dat", FileMode.Open))
            {
                if (fs.Length > 0)
                {
                     return (ObservableCollection<ServerModel>)formatter.Deserialize(fs);
                }
            }

            return new ObservableCollection<ServerModel>();
        }

        public static void SaveServer(ObservableCollection<ServerModel> servers)
        {

            ReferenceExist();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                                  @"\BukkitNET\Servers.dat", FileMode.Create))
            {
                formatter.Serialize(fs, servers);
            }
        }



    }
}
