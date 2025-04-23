using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace PP_lab3
{
    public static class Program
    {
        private static readonly Random Random = new Random();
        private const int BenchmarkRuns = 5;

        private static long RunBenchmark(Func<Matrix> multiplicationMethod, string methodName)
        {
            long totalTime = 0;
            for (int i = 0; i < BenchmarkRuns; i++)
            {
                var timer = Stopwatch.StartNew();
                var result = multiplicationMethod();
                timer.Stop();
                totalTime += timer.ElapsedMilliseconds;
            }

            long averageTime = totalTime / BenchmarkRuns;
            Console.WriteLine($"{methodName} avg time: {averageTime} ms");
            return averageTime;
        }

        private static void PrintResults(List<BenchmarkResult> results)
        {
            Console.WriteLine("\nResults:");
            Console.WriteLine("Matrix Size   Sequential Time   Thread Count   Parallel Time   Speedup\n");

            foreach (var group in results.GroupBy(r => r.MatrixSize))
            {
                foreach (var result in group)
                {
                    Console.WriteLine(result);
                }
                Console.WriteLine("\n");
            }
        }

        public static void Main()
        {
            // Parameters
            int[] matrixSizes = { 100, 200, 300 };
            int[] threadCounts = { 1, 2, 4, 8, 16, 32, 64, 128, 256 , 512};

            var results = new List<BenchmarkResult>();

            foreach (int size in matrixSizes)
            {
                Console.WriteLine($"\nMatrix size {size}x{size}");
                Matrix a = new Matrix(size, size);
                Matrix b = new Matrix(size, size);
                a.FillRandom(Random);
                b.FillRandom(Random);

                long sequentialTime = RunBenchmark(() => MatrixMultiplier.MultiplySequential(a, b), "Sequential");

                foreach (int threads in threadCounts)
                {
                    long parallelTime = RunBenchmark(() => MatrixMultiplier.MultiplyParallel(a, b, threads), $"Parallel, {threads} threads, ");

                    results.Add(new BenchmarkResult
                    {
                        MatrixSize = size,
                        ThreadCount = threads,
                        SequentialTimeMs = sequentialTime,
                        ParallelTimeMs = parallelTime
                    });
                }
            }
            PrintResults(results);
        }    
    }
}