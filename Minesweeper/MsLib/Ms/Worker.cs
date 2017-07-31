using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MsLib
{
    public class Worker : BackgroundWorker
    {
        Tile t;
        Queue<MineButton> buttons;
        public Worker(Tile t)
        {
            this.t = t;
            ProgressChanged += Thread_ProgressChanged;
            DoWork += Thread_DoWork;
            RunWorkerCompleted += Thread_RunWorkerCompleted;
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (this.CancellationPending) {   e.Cancel = true; }
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //mb.checkQueue(buttons);
        }
    }
}
