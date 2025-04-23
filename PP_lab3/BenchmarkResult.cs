using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_lab3
{
    public class BenchmarkResult
    {
        public int MatrixSize { get; set; }
        public int ThreadCount { get; set; }
        public long SequentialTimeMs { get; set; }
        public long ParallelTimeMs { get; set; }
        public double Speedup => (double)SequentialTimeMs / ParallelTimeMs;

        public override string ToString()
        {
            return $"  {MatrixSize}\t\t{SequentialTimeMs}\t\t{ThreadCount}\t\t{ParallelTimeMs}\t\t{Speedup:0.##}";
        }
    }
}
