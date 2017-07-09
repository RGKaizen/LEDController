using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.Utils
{
    class AnimationThread : BackgroundWorker
    {
        public Boolean isOn { get; private set; }
        public delegate void ThreadFunction();
        ThreadFunction _tf = null;
        public AnimationThread(ThreadFunction tf)
        {
            WorkerSupportsCancellation = true;
            DoWork += new DoWorkEventHandler(this_DoWork);
            _tf = tf;
        }

        public bool Start() {
            if (!isOn && !IsBusy) 
            { 
                RunWorkerAsync(10);
                isOn = true;
            }

            if (IsBusy)
            { 
                return true;
            }

            return isOn;
        }

        public bool Stop()
        {
            if (isOn)
            {
                CancelAsync();
                isOn = false;
            }

            return !isOn;
        }

        private void this_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly. 
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;
            while (isOn)
            {
                _tf();
            }

            // If the operation was canceled by the user,  
            // set the DoWorkEventArgs.Cancel property to true. 
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }
    }
}
