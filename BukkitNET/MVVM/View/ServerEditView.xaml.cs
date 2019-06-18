using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BukkitNET.MVVM.Model;
using BukkitNET.MVVM.ViewModel;
using BukkitNET.Services;

namespace BukkitNET.MVVM.View
{
    /// <summary>
    /// Interaction logic for ServerEditView.xaml
    /// </summary>
    public partial class ServerEditView : Window
    {
        public ServersViewModel ServersViewModel { get; set; }
        public ServerEditView(ServersViewModel svm)
        {
            InitializeComponent();
            ServersViewModel = svm;
        }

        private void ServerEditView_OnClosed(object sender, EventArgs e)
        {
            ServersViewModel.BlurRadius = 0;

            //save the new collection to the file
            ServerListService.SaveServer(ServersViewModel.ServerCollection);

        }

        private void ServerEditView_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
