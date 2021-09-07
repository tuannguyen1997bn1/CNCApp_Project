using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC12.Model
{
    public class Timing
    {
        TimeSpan start = new TimeSpan(0);
        TimeSpan _duration = new TimeSpan(0);
      

        public TimeSpan Duration => _duration;
        public void Stop()
        {
            _duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(start);
        }
        public void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            start = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
    }
}
