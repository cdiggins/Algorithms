using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public static class CombinationsTest
    {
        public static bool AreSetsSame(List<int> a, List<int> b)
        {
            if (a.Count != b.Count) return false;
            var asorted = a.OrderBy(x => x);
            var bsorted = b.OrderBy(x => x);
            return asorted.SequenceEqual(bsorted);
        }

        public static bool DoesOutputSetContain(IEnumerable<List<int>> outputSet, List<int> member)
        {
            foreach (var output in outputSet)
            {
                if (AreSetsSame(output, member))
                    return true;
            }

            return false;
        }

        [Test]
        public static void TestGenerateCombinations()
        {
            var testInput = new[] { 1, 3, 5 };
            var output = GenerateCombinations(testInput);
            
            // How do I validate that the output is valid? 
            // Maybe check that it contains a result I expect? 

            // I know that it should have three lists of length one 

            // Expected results=
            // [], [1], [3], [5], [1,3], [1,5], [3, 5], [1, 3, 5]
            // 1 of length 0,
            // 3 of length 1,
            // 3 of length 2,
            // 1 of length 3. 
            // Total count = 8

            var expectedResults = new List<List<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 3 },
                new List<int> { 5 },
                new List<int> { 1, 3 },
                new List<int> { 1, 5 },
                new List<int> { 3, 5 },
                new List<int> { 1, 3, 5 },
            };

            foreach (var expectedResult in expectedResults)
            {
                Assert.IsTrue(DoesOutputSetContain(output, expectedResult));
            }
        }

        public static void OutputResults(IEnumerable<List<int>> output)
        {
            foreach (var combination in output)
            {
                Console.WriteLine("[" + string.Join(",", combination) + "]");
            }
        }

        [Test]
        public static void ViewTestOutput()
        {
            var testInput = new[] { 1, 3, 5, 7 };
            var combinations = GenerateCombinations(testInput);
            OutputResults(combinations);
        }

        [Test]
        public static void ViewTestOutput2()
        {
            var testInput = new[] { 1, 3, 5, 7 };
            var combinations = GenerateCombinations2(testInput);
            OutputResults(combinations);
        }

        [Test]
        public static void ViewTestOutputWrong()
        {
            var testInput = new[] { 1, 3, 5, 7 };
            var combinations = GenerateCombinationsWrong(new List<int>(), testInput);
            OutputResults(combinations);
        }

        public static void GenerateCombinations(
            int[] input, 
            int index, 
            List<int> previous, 
            List<List<int>> combinations)
        {
            DebugCount++;
            if (index >= input.Length)
                return;
            GenerateCombinations(input, index + 1, previous, combinations);
            var tmp = previous.ToList();
            tmp.Add(input[index]);
            combinations.Add(tmp);
            GenerateCombinations(input, index + 1, tmp, combinations);
        }

        public static IEnumerable<List<int>> GenerateCombinations(int[] input)
        {
            var combinations = new List<List<int>>();
            GenerateCombinations(input, 0, new List<int>(), combinations);
            return combinations;
        }

        public static IEnumerable<List<int>> GenerateCombinationsWrong(
            IEnumerable<int> current, 
            IEnumerable<int> remaining)
        {
            yield return current.ToList();

            foreach (var x in remaining)
            {
                // Make a copy of the current list
                var currentCopy = current.ToList();

                currentCopy.Add(x);
                var remainingCopy = remaining.ToList();
                remainingCopy.Remove(x);

                foreach (var xs in GenerateCombinationsWrong(currentCopy, remainingCopy))
                    yield return xs;
            }
        }

        public static IEnumerable<List<int>> GenerateCombinations2(int[] input)
        {
            var count = Helper.Pow2(input.Length);
            for (var i = 0; i < count; ++i)
            {
                yield return ChooseInts(i, input);
            }
        }

        public static List<int> ChooseInts(int index, int[] input)
        {
            if (input.Length > 31)
                throw new Exception("Too many inputs");

            var result = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (Helper.HasBitSet(index, i))
                    result.Add(input[i]);
            }
            return result;
        }

        private static int DebugCount = 0;

        public static void GenerateSumCombinations(
            int[] input,
            int sum,
            int index,
            List<int> previous,
            List<List<int>> combinations)
        {
            DebugCount++;
            if (previous.Sum() > sum)
                return;
            if (index >= input.Length)
                return;
            GenerateSumCombinations(input, sum, index + 1, previous, combinations);
            var tmp = previous.ToList();
            tmp.Add(input[index]);
            if (tmp.Sum() == sum)
                combinations.Add(tmp);
            GenerateSumCombinations(input, sum, index + 1, tmp, combinations);
        }

        public static IEnumerable<List<int>> GenerateSumCombinations(int[] input, int sum)
        {
            var combinations = new List<List<int>>();
            GenerateSumCombinations(input, sum, 0, new List<int>(), combinations);
            return combinations;
        }

        [Test]
        public static void TestSumCombinations()
        {

            var testInput = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            var target = 15;

            DebugCount = 0;
            var result0 = GenerateCombinations(testInput)
                .Where(input => input.Sum() == target);
            Console.WriteLine($"Using sum combinations with brute force:");
            Console.WriteLine($"function called {DebugCount} times");
            OutputResults(result0);

            DebugCount = 0;
            var result1 = GenerateSumCombinations(testInput, target);
            Console.WriteLine($"Using sum combinations with backtracking:");
            Console.WriteLine($"function called {DebugCount} times");
            OutputResults(result1);
        }
    }
}
