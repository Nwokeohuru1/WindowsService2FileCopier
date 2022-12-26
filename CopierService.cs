using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService2FileCopier
{
    public partial class CopierService : ServiceBase
    {
        public CopierService()
        {
            InitializeComponent();
        }
        public void ondebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            int timeinterval =Convert.ToInt32( ConfigurationManager.AppSettings["Timeinterval"]);
            MoveFilesLogic move = new MoveFilesLogic();
            System.Timers.Timer timer = new System.Timers.Timer(timeinterval);
            timer.Start();
            timer.AutoReset = true;
            timer.Elapsed += move.Moove;
        }

       
        protected override void OnStop()
        {
        }
    }
}
