namespace AlgorithmsTestProject
{
    public static class ArraySortTests
    {
        public static string[] Sorts =
        {
            nameof(ArraySortProblems.BlockSort),
            nameof(ArraySortProblems.BubbleSort),
            nameof(ArraySortProblems.CocktailSort),
            nameof(ArraySortProblems.HeapSort),
            nameof(ArraySortProblems.IntroSort),
            nameof(ArraySortProblems.MergeSort),
            nameof(ArraySortProblems.MySort1),
            nameof(ArraySortProblems.MySort2),
            nameof(ArraySortProblems.QuickSort),
            nameof(ArraySortProblems.ShuffleSort),
            nameof(ArraySortProblems.BogoSort),
            nameof(ArraySortProblems.DoNothingSort),
            nameof(ArraySortProblems.EvilSort),
            nameof(ArraySortProblems.GnomeSort),
            nameof(ArraySortProblems.SelectionSort)
        };
            
        public static Action<int[]> GetSortingAlgorithm(string name)
        {
            var type = typeof(ArraySortProblems);
            var method = type.GetMethod(name);
            return (input) => method.Invoke(null, new[] { input });
        }

        public static int[][] Inputs = ArrayProblemsTests.TestInputs;
            
        public static bool IsSorted(int[] input)
        {
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i - 1] > input[i])
                    return false;
            }
            return true;
        }

        public static IEnumerable<TestCaseData> TestCaseData()
        {
            return Sorts.SelectMany(
                sort => Inputs.Select(
                    input => new TestCaseData(sort, input)));
        }

        [Test, TestCaseSource(nameof(TestCaseData))]
        public static void SortTest(string sortName, int[] input)
        {
            var algo = GetSortingAlgorithm(sortName);
            algo(input);
            Assert.IsTrue(IsSorted(input));
        }
    }
}
