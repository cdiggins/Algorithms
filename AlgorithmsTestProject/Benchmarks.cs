using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public class Benchmarks
    {
        public class TestResult
        {
            public TimeSpan Elapsed { get; set; }
            public int Input { get; set; }
        }

        public static TimeSpan Max = TimeSpan.FromSeconds(1.5);

        public static List<TestResult> RunBenchmark<TInput>(
            Func<int, TInput> funcInput,
            Action<TInput> func)
        {
            var results = new List<TestResult>();
            for (var i = 2; i < int.MaxValue; i *= 2)
            {
                var input = funcInput(i);
                var sw = Stopwatch.StartNew();
                func(input);
                sw.Stop();
                var result = new TestResult()
                {
                    Elapsed = sw.Elapsed,
                    Input = i,
                };
                results.Add(result);
                if (sw.Elapsed > Max)
                    break;
            }
            return results;
        }
    }
}
