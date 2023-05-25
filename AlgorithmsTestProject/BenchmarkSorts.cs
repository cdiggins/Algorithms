namespace AlgorithmsTestProject
{
    public static class BenchmarkSorts
    {
        public static int[] GenerateInputs(int n)
        {
            var input = new int[n];
            var prev = 457;
            for (var i = 0; i < n; i++)
            {
                prev = input[i] = unchecked(i ^ ((prev % 3) ^ (prev * 57)));
            }

            return input;
        }

        [Test]
        public static void BenchmarkMySort()
        {
            var results = Benchmarks.RunBenchmark(GenerateInputs,
                ArraySortProblems.MySort1);
            DynamicArrayTests.OutputResults(results);
        }

        [Test]
        public static void BenchmarkBubbleSort()
        {
            var results = Benchmarks.RunBenchmark(GenerateInputs,
                ArraySortProblems.BubbleSort);
            DynamicArrayTests.OutputResults(results);
        }
    }

}
