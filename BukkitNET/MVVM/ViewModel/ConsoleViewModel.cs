using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BukkitNET.Core;
using BukkitNET.Services;

namespace BukkitNET.MVVM.ViewModel
{
    class ConsoleViewModel : ObservableObject
    {
        public RelayCommand EnterCommand { get; set; }
        public ConsoleViewModel()
        {
            EnterCommand = new RelayCommand(o =>
            {

                //Start Armada
                ProcessCommandService.ProcessCommand(o as string);


                //    ServersViewModel svm = new ServersViewModel();
                //    var serverModel = svm.ServerCollection.First(x => x.ServerName == o as string);


                //    var jarPath = serverModel.JarPath;

                //    var startInfo = new ProcessStartInfo("java", "-Xmx1024M -Xms1024M -jar " + jarPath + " nogui");
                //    //startInfo.WorkingDirectory = ServerPath;
                //    startInfo.RedirectStandardInput = startInfo.RedirectStandardError = true;
                //    startInfo.UseShellExecute = false;
                //    startInfo.CreateNoWindow = true;


                //Process ServerProc = new Process();
                //ServerProc.StartInfo = startInfo;
                //ServerProc.EnableRaisingEvents = true;
                //ServerProc.ErrorDataReceived += new DataReceivedEventHandler(ServerProc_ErrorDataReceived);
                //ServerProc.Exited += new EventHandler(ServerProc_Exited);

                //MessageBox.Show(o as string);

            }, o => true);
        }
    }
}
