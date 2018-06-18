using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Universal;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace BSAP_SubProcessMonitor
{
    class modMain
    {
        long SESSION_ID;
        long APP_PROJECT_MAIN_PROCESS_ID;
        string APP_PATH;
        bool USELOCAL;
        private bool _UPDATEDSESSION;

        public long getAppProjectMainProcessSQLIte(string process_name, ref bool HasLogs)
        {
            long lAns = 0;
            try
            {
                string SQL = "Select id, haslogs from app_project_main_process where process_name='" + process_name + "' COLLATE NOCASE";
                BurnSoft.BSSqliteDatabase Obj = new BurnSoft.BSSqliteDatabase();
                if (Obj.ConnectDB == 0)
                {
                    SQLiteCommand CMD = new SQLiteCommand(SQL, Obj.Conn);
                    SQLiteDataReader RS = default(SQLiteDataReader);
                    RS = CMD.ExecuteReader;
                    while (RS.Read)
                    {
                        lAns = RS("id");
                        HasLogs = Convert10ToBool(RS("haslogs"));
                    }
                    RS.Close();
                    RS = null;
                    CMD = null;
                    Obj.CloseDB();
                }
                Obj = null;
            }
            catch (Exception ex)
            {
                LogError("modMain.getAppProjectMainProcessSQLite", ex.Message.ToString);
            }
            return lAns;
        }

        static void Main(string[] args)
        {

        }
    }
}
