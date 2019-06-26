using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using BukkitNET.MVVM.ViewModel;

namespace BukkitNET.Services
{
    public class ConsoleLogService : UsersViewModel
    {
        public ObservableCollection<string> TheUsers { get; set; }
        public ConsoleLogService()
        {
            TheUsers = Users;
        }

        /// <summary>
        /// Used to parse the incoming string data from the Server.
        /// </summary>
        /// <param name="data">data to be processed.</param>
        /// <returns></returns>
        public static string ParseData(string data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                var dataChunks = data.Split(' ');

                //if (dataChunks[2] == "Authenticator")
                //{
                //    //call the function that updates the property in the other viewmodel
                //    Console.WriteLine($"{dataChunks[7]}: connected.");
                //    TheUsers.Add(dataChunks[7]);
                //    Debug.Print("UsersCollection:");
                //    foreach (var user in UsersCollection)
                //    {
                //        Debug.Print(user);
                //    }
                    


                //}

                //try
                //{
                //    if (dataChunks[6] == "Disconnected")
                //    {
                //        Console.WriteLine($"{dataChunks[3]}: disconnected.");
                //        UsersCollection.Remove(dataChunks[3]);
                //        Debug.Print("UsersCollection:");
                //        foreach (var user in UsersCollection)
                //        {
                //            Debug.Print(user);
                //        }
                //    }
                //}
                //catch (Exception e)
                //{

                //}
            }


            return data;
        }
    }
}
