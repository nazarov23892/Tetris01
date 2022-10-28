using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public delegate void TetrisTimerElapseEventHandler(ITetrisTimer sender);

    public interface ITetrisTimer: IDisposable
    {
        int GetInterval();
        void SetInterval(int millisecons);
        void Stop();
        void Start();

        event TetrisTimerElapseEventHandler Tick;
    }
}
