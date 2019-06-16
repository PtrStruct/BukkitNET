using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BukkitNET.Core;
using BukkitNET.Properties;

namespace BukkitNET.MVVM.ViewModel
{
    class BaseViewModel : ObservableObject
    {
        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand UsersViewCommand { get; set; }
        public RelayCommand ServersViewCommand { get; set; }    


        public BaseViewModel()
        {

            /*Commands*/
            DashboardViewCommand = new RelayCommand(o => { CurrentView = DashboardViewModel; }, o => true);
            SettingsViewCommand = new RelayCommand(o => { CurrentView = SettingsViewModel; }, o => true);
            UsersViewCommand = new RelayCommand(o => { CurrentView = UsersViewModel; }, o => true);
            ServersViewCommand = new RelayCommand(o => { CurrentView = SettingsViewModel; }, o => true);

            //Initialize a new instance of the ViewModel
            DashboardViewModel = new DashboardViewModel();
            SettingsViewModel = new SettingsViewModel();
            UsersViewModel = new UsersViewModel();
            ServersViewModel = new ServersViewModel();

            //Set the default view to the DashboardViewModel
            CurrentView = DashboardViewModel;
        }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private DashboardViewModel _dashboardViewModel;

        public DashboardViewModel DashboardViewModel
        {
            get { return _dashboardViewModel; }
            set { _dashboardViewModel = value; }
        }

        private SettingsViewModel _settingsViewModel;

        public SettingsViewModel SettingsViewModel
        {
            get { return _settingsViewModel; }
            set { _settingsViewModel = value; }
        }

        private UsersViewModel _usersViewModel;

        public UsersViewModel UsersViewModel
        {
            get { return _usersViewModel; }
            set { _usersViewModel = value; }
        }

        private ServersViewModel _serversViewModel;

        public ServersViewModel ServersViewModel
        {
            get { return _serversViewModel; }
            set { _serversViewModel = value; }
        }





    }

}
