# BukkitNET
A server wrapper with a modern GUI for CraftBukkit


## Installation

Clone or download the project and run it in Visual Studio

## Changing the default view state

```cs
public BaseViewModel()
{

    /*Commands*/
    DashboardViewCommand = new RelayCommand(o => { CurrentView = DashboardViewModel; }, o => true);
    SettingsViewCommand = new RelayCommand(o => { CurrentView = SettingsViewModel; }, o => true);
    UsersViewCommand = new RelayCommand(o => { CurrentView = UsersViewModel; }, o => true);
    ServersViewCommand = new RelayCommand(o => { CurrentView = ServersViewModel; }, o => true);

    //Initialize a new instance of the ViewModel
    DashboardViewModel = new DashboardViewModel();
    SettingsViewModel = new SettingsViewModel();
    UsersViewModel = new UsersViewModel();
    ServersViewModel = new ServersViewModel();

    //Set the default view to the DashboardViewModel
    CurrentView = DashboardViewModel;
}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


[![Open Source Love](https://badges.frapsoft.com/os/v1/open-source.svg?v=103)](https://github.com/PtrStruct/BukkitNET/tree/master)

## Version
![GitHub version](https://d25lcipzij17d.cloudfront.net/badge.svg?id=gh&type=6&v=1.0.0&x2=0)

## License
[![MIT Licence](https://badges.frapsoft.com/os/mit/mit.svg?v=103)](https://opensource.org/licenses/mit-license.php)
