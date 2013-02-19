using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera.Core.Benchmark
{
    public class Benchmarker
    {
        private static Dictionary<string, Stopwatch> sm_stopwatches;

        static Benchmarker()
        {
            sm_stopwatches = new Dictionary<string, Stopwatch>();
        }

        public static void Start(string name)
        {
            sm_stopwatches.Add(name, Stopwatch.StartNew());
        }

        public static void Stop(string name)
        {
            Stopwatch stopWatch;
            sm_stopwatches.TryGetValue(name, out stopWatch);

            if(stopWatch != null) stopWatch.Stop();
        }

        public static long EllapsedMilliseconds(string name)
        {
            Stopwatch stopWatch;
            sm_stopwatches.TryGetValue(name, out stopWatch);

            return stopWatch == null ? -1 : stopWatch.ElapsedMilliseconds;
        }
    }
}
