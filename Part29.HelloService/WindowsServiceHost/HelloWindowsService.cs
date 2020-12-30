using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;


namespace WindowsServiceHost
{
    public partial class HelloWindowsService : ServiceBase
    {

        ServiceHost host;
        public HelloWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
                host.Close();
        }
    }
}

/* Part 27 Hosting a wcf service in a windows service
 * Step 1 Add project WindowsServiceHost  
 * 1)
 *    Add project Windows service.
 *    Add reference.
 *    Add App.config item and copy content form other project file.
 *    Rename service file  Service1.cs to HellWindowsService.cs 
 * 2) 
 *    Typing code in HelloWindowsService.cs
 * 3)   
 *    Add Installer
 *      -> Click the ProjectInstall property item  at design of HelloWindowsService.cs
 *    Modify ServiceName property of serviceInstaller1 
 *      -> HelloWindowsService
 *    Modify StartType property of serviceInstaller1 
 *      -> Automatic
 *    Modify Account property of serviceProcessInstaller1 
 *      -> LocalSystem 
 * 4)
 *    Build the solution
 *    
 * Step2 Install the windows service using INSTALLUTIL.EXE 
 * 1) Install at Visual Studio Command Prompt
 *      ex) 
 *          installutil -i C:\git\WCFTutorial\Part27.HelloService\WindowsServiceHost\bin\Release\WindowsServiceHost.exe
 *          installutil -u C:\git\WCFTutorial\Part27.HelloService\WindowsServiceHost\bin\Release\WindowsServiceHost.exe
 *      
 * Setp3 Test
 * 1) Check the service at Services management 
 *  -> type run services.msc
 */