using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace RunServer
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //Todo: fet it from command line
            //Arguments cmdline = new Arguments(args);
            // Console.WriteLine(cmdline["name"]);
            startInfo.FileName = "cmd";
            startInfo.WorkingDirectory = @"C:\Automation\AppWarp";
            startInfo.Arguments = "/C java -server -Xms1G -Xmx1G -classpath  \"dist\\App42GamingServer.jar;lib\\*\" com.shephertz.app42.server.Main";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit(2000);

            bool found = false;
            int count = 0;
            while (!found && count < 10)
            {
                Console.WriteLine("Waiting for Server to be in running state");
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    //On window when Appwarp Server run it's process name is Java
                    if (clsProcess.ProcessName == "java")
                    {
                        found = true;
                    }
                }
                Thread.Sleep(1000);
                count++;
            }
            if (!found)
            {
                Console.WriteLine("AppWarpServer did not start. Please Enter to Continue");
                Console.Read();
            }
            else
            {
                Console.WriteLine("AppWarpServer Started Succesfully");
            }
        }
    }
}
