namespace AlgorithmsTestProject;

public static class QuickSortTests
{
    public static int[][] Inputs = ArrayProblemsTests.TestInputs;

    public static bool IsSorted(int[] input)
    {
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] < input[i - 1])
                return false;
        }

        return true;
    }

    [Test]
    public static void SpecialTest()
    {
        var xs = new[] { 3, 5, 2, 1 };
        TestQuickSort(xs);
    }

    [Test, TestCaseSource(nameof(Inputs))]
    public static void TestQuickSort(int[] input)
    {
        Console.WriteLine(string.Join(",", input));
        var qs = new QuickSort<int>(input, ArrayProblemsTests.Compare);
        Console.WriteLine(string.Join(",", input));
        Assert.IsTrue(IsSorted(input));
    }
}