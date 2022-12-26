using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace WindowsService2FileCopier
{
    internal class MoveFilesLogic
    {
        public void Moove(object sender, System.Timers.ElapsedEventArgs e)
        {

            string Sourcepath = ConfigurationManager.AppSettings["Sourcefolder"]; //*@"C:\Temp\Source\";
            string Destpath = ConfigurationManager.AppSettings["Destinationfolder"];  //*@"C:\Temp\Destination\";
            string fulldest;

            if (!Directory.Exists(Sourcepath))
            {
                Directory.CreateDirectory(Sourcepath);
            }
            if (!Directory.Exists(Destpath))
            {
                Directory.CreateDirectory(Destpath);
            }
            string[] filename = Directory.GetFiles(Sourcepath);

            {
                foreach (string item in filename)
                {
                    try
                    {

                        {
                            fulldest = Path.Combine(Destpath, Path.GetFileName(item));
                            File.Move(item, fulldest);
                            //File.Copy(item, fulldest);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex.Message);
                    }

                }
            }

        }
        public void WriteLog(string text)
        {
            string Log = @"C:\Temp\Log";
            if (!Directory.Exists(Log))
            {
                Directory.CreateDirectory(Log);
            }
            string logfile = Path.Combine(Log, "log.txt");
            File.AppendAllText(logfile, text);

        }
    }


    
}
