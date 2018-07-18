using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Management;
using BurnSoft.Universal;
using System.Data.SQLite;
namespace BSAP_SubAppMonitor
{
    class Program
    {
        private static Timer t;
        private static long _PID;
        private static long _MAIN_APP_ID;
        private static long _INTERVAL;
        //private static string _APP_PATH;
        //private static bool _USELOCAL;

        private static void init()
        {
            bool didexist = false;
            BSOtherObjects obj = new BSOtherObjects();
            _PID = obj.GetCommand("pid", 0,ref didexist);
            _MAIN_APP_ID = obj.GetCommand("aid", 0, ref didexist);
            _INTERVAL = obj.GetCommand("interval", 60, ref didexist);
            if (_PID ==0 ) {
                Console.WriteLine("Main PID missing!");
                System.Environment.Exit(1);
            }
            if (_MAIN_APP_ID == 0)
            {
                Console.WriteLine("Missing Main App ID ( aid )!");
                System.Environment.Exit(1);
            }

        }
        public static void listChildProcesses(int parentProcessId)
        {
            String myQuery = string.Format("select * from win32_process where ParentProcessId={0}", parentProcessId);
            ObjectQuery objQuery = new ObjectQuery(myQuery);
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(objQuery);
            ManagementObjectCollection processList = objSearcher.Get();

            foreach (ManagementObject item in processList)
            {
                try
                {
                    int processId = Convert.ToInt32(item["ProcessId"].ToString());

                    Console.WriteLine("processId:{0} name:{1} {2}",
                        item["ProcessId"],
                        item["Name"],
                        item["ParentProcessId"]
                    );
                    listChildProcesses(Convert.ToInt32(item["ProcessId"]));

                    // recursive call
                    if (processId != parentProcessId)
                        listChildProcesses(processId);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }
        }
        private static void TimerCallback(Object o)
        {
            listChildProcesses(Convert.ToInt32(_PID));
            // Force a garbage collection to occur.
            GC.Collect();
        }
        static void Main(string[] args)
        {
            init();

            TimeSpan TimeToRun = new TimeSpan(0, 0, Convert.ToInt32(_INTERVAL));
            t = new Timer(TimerCallback, null, TimeToRun, TimeToRun);
            Console.Read();
        }
    }
}
