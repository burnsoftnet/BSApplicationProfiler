using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using BurnSoft.Universal;
namespace BSAP_SubAppMonitor
{
    class Program
    {
        private static int _PID;
        private static void init()
        {
            bool didexist = false;
            BSOtherObjects obj = new BSOtherObjects();
            _PID = Convert.ToInt32(obj.GetCommand("pid", 0,ref didexist));

            if (_PID ==0 ) {
                Console.WriteLine("Main PID missing!");
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
        static void Main(string[] args)
        {
            init();

        }
    }
}
