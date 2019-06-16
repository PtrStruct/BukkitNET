using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BukkitNET.Core;

namespace BukkitNET.MVVM.ViewModel
{
    class ConsoleViewModel : ObservableObject
    {
        public RelayCommand EnterCommand { get; set; }
        public ConsoleViewModel()
        {
            EnterCommand = new RelayCommand(o => { MessageBox.Show(o as string); }, o => true);
        }
    }
}
