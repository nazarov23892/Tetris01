using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    public class WinformTimer : ITetrisTimer
    {
        private const int DEFAULT_INTERVAL_MS = 1000;
        public event TetrisTimerElapseEventHandler Tick;
        private readonly System.Windows.Forms.Timer timer = null;
        public WinformTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = DEFAULT_INTERVAL_MS;
            timer.Stop();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Tick != null)
            {
                this.Tick(this);
            }
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Dispose()
        {
            timer.Dispose();
        }

        public int GetInterval()
        {
            return this.timer.Interval;
        }

        public void SetInterval(int millisecons)
        {
            this.timer.Interval = millisecons;
        }
    }
}
