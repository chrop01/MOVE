﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Shared
{
   public class ErrorLogWriter
    {
        #region Methoden
        public bool WriteErrorLog(string message)
        {
            bool status = false;
            string LogDirectory = "MOVEErrorLog_";

            DateTime datetime = DateTime.Now;
            string logLine = BuildLogLine(datetime, message);
            LogDirectory = (LogDirectory + LogFileName(DateTime.Now) + ".txt");

            lock (typeof(ErrorLogWriter))
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(LogDirectory, true);
                    sw.WriteLine(logLine);
                    status = true;
                }
                catch
                {

                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
            return status;
        }

        private string BuildLogLine(DateTime datetime, string message)
        {
            StringBuilder logline = new StringBuilder();
            logline.Append(LogEntry(datetime));
            logline.Append(" \t");
            logline.Append(message);
            return logline.ToString();
        }

        public string LogEntry(DateTime datetime)
        {
            return datetime.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private string LogFileName(DateTime datetime)
        {
            return datetime.ToString("dd_MM_yyyy");
        }
    }
}
#endregion