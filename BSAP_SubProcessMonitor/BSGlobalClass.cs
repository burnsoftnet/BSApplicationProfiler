using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace BurnSoft
{
    class BSSqliteDatabase
    {
        private string MyConnectionString => String.Format(
            "Server={0};user id={1};password={2};persist security info=true;database={3}",
            ConfigurationManager.AppSettings["DB_HOST"], ConfigurationManager.AppSettings["DB_UID"],
            ConfigurationManager.AppSettings["DB_PWD"], ConfigurationManager.AppSettings["DB_NAME"]);
        /// <summary>
        /// Main Class Name for error dumping.
        /// </summary>
        private string ClassLocation => "BurnSoft.BSDatabase";

        /// <summary>
        /// General Error Message Format getting the ClassLocation property and appending it to the sLocation and also appended it 
        /// to the ex.message, this was done to allow you narrow down the location of were the error occured.
        /// </summary>
        /// <param name="sLocation">Sub or Function Name</param>
        /// <param name="ex">Exception</param>
        /// <returns>string Class.SubOrFunction - Error Message</returns>
        /// <example>serror = ErrorMessage("getDBVersion", ex);</example>
        /// <remarks>copy and fill in the blank - ErrorMessage("", ex);</remarks>
        private string ErrorMessage(string sLocation, Exception ex)
        {
            return $"{ClassLocation}.{sLocation} - {ex.Message}";
        }

        public MySqlConnection Conn;
        public int ConnectDB(out string errMsg)
        {
            int iAns = 0;
            errMsg = @"";
            try
            {
                Conn = new MySqlConnection(MyConnectionString);
                Conn.Open();
            }
            catch (Exception e)
            {
                errMsg = ErrorMessage("ConnectDB", e);
                iAns = System.Runtime.InteropServices.Marshal.GetExceptionCode();
            }
            return iAns;
        }

        public void CloseDB()
        {
            if (Conn.State != ConnectionState.Closed)
            {
                Conn.Close();
            }
            Conn = null;
        }

        public void ConnExe(string SQL, out string errMsg)
        {
            errMsg = @"";
            string errMsgConn = @"";
            try
            {
                if (ConnectDB(out errMsgConn) == 0)
                {
                    MySqlCommand CMD = new MySqlCommand();
                    CMD.CommandText = SQL;
                    CMD.Connection = Conn;
                    CMD.ExecuteNonQuery();
                    CMD.Connection.Close();
                    CMD = null;
                    CloseDB();
                }
                else
                {
                    throw new Exception(errMsgConn);
                }
            }
            catch (Exception e)
            {
                errMsg = ErrorMessage("ConnExe", e);
            }
        }
    }
}
