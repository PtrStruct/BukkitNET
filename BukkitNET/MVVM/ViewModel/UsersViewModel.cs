using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.Core;

namespace BukkitNET.MVVM.ViewModel
{
    public class UsersViewModel : ObservableObject
    {
        public static ObservableCollection<string> Users { get; set; }
        public UsersViewModel()
        {
            Users = new ObservableCollection<string>();

            Users.Add("Hello");
            Users.Add("World");
            Users.Add("Hello");
        }

        /// <summary>
        /// Used to add a user to the User collection.
        /// </summary>
        /// <param name="username">The username to add to the collection of users.</param>
        public static void ParseLogin(string username)
        {
            Users.Add(username);
        }

        /// <summary>
        /// Used to remove a user to the User collection.
        /// </summary>
        /// <param name="username">The username to remove to the collection of users.</param>
        public static void ParseDisconnect(string username)
        {

        }
    }
}
