using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public static class DynamicArrayTests
    {   
        [Test]
        public static void TestInsert()
        {
            var xs = new[] { 1, 5 };
            var ys = new[] { 2, 3, 4 };
            var expected = new[] { 1, 2, 3, 4, 5 };
            var da = new DynamicArray<int>();
            da.Add(1);
            da.Add(5);
            da.Insert(1, 4);
            da.Insert(1, 3);
            da.Insert(1, 2);

            for (var i = 0; i < da.Count; i++)
            {
                Assert.AreEqual(i + 1, da[i]);
            }
        }

        public static void OutputResults(List<Benchmarks.TestResult> results)
        {
            for (var i = 1; i < results.Count; ++i)
            {
                var result = results[i];
                var currSec = result.Elapsed.TotalSeconds;
                var prevSec = results[i - 1].Elapsed.TotalSeconds;
                var multiplier = prevSec > 0 ? currSec / prevSec : 0;
                Console.WriteLine($"N = {result.Input}, Seconds = {currSec:0.####} multiplier = {multiplier:0.##}");
            }
        }

        public static int TestDynamicArray(IDynamicArray<int> array, int n)
        {
            for (var i = 0; i < n; ++i)
                array.Add(i);
            return array.Count;
        }

        public static void TestDynamicArray(IDynamicArray<int> array)
        {
            var results = Benchmarks.RunBenchmark(
                n => n,
                n => TestDynamicArray(array, n)).ToList();
            OutputResults(results);
        }

        [Test]
        public static void TestDynamicArrayAddOne()
        {
            Console.WriteLine("Test results for add one dynamic array");
            TestDynamicArray(new DynamicArrayAddOne<int>());
        }

        [Test]
        public static void TestDynamicArrayAdd100()
        {
            Console.WriteLine("Test results for add 100 dynamic array");
            TestDynamicArray(new DynamicArrayAdd100<int>());
        }

        [Test]
        public static void TestDynamicArrayDoubling()
        {
            Console.WriteLine("Test results for doubling dynamic array");
            TestDynamicArray(new DynamicArray<int>());
        }
    }
}
