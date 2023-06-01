using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace AlgorithmsTestProject;

public static class TreeAlgorithmTests
{
    public static int Compare(int a, int b)
        => a < b ? -1 : a > b ? 1 : 0;

    [Test]
    public static void TestHeapInsertion()
    {
        IBinaryTree<int> tmp = new BinaryTree<int>(10, null, null);
        TreeAlgorithms.OutputTree(tmp);

        foreach (var x in new[] { 20, 5, 21, 4, 22, 6, 8, 13, 14, 2, 3, 9, 12, 5, 7, 16, 1, 15 })
            tmp = tmp.InsertHeap(x, Compare);
        TreeAlgorithms.OutputTree(tmp);

        Console.WriteLine("Values in reverse order");
        while (tmp != null)
        {
            Console.WriteLine(tmp.Value);
            tmp = tmp.ExtractHeap(Compare);
        }
    }

    public static void Shuffle<T>(T[] xs)
    {
        var rng = new Random(99);
        for (var i = 0; i < xs.Length; ++i)
        {
            var j = rng.Next(xs.Length);
            (xs[i], xs[j]) = (xs[j], xs[i]);
        }
    }

    public static int[] CreateRandomArray(int n)
    {
        var xs = Enumerable.Range(0, n).ToArray();
        Shuffle(xs);
        return xs;
    }


    public static IEnumerable<int> HeapSort(IEnumerable<int> input)
    {
        var list = input.ToList();
        var heap = new BinaryTree<int>(list[0]) as IBinaryTree<int>;
        for (var i=1; i <list.Count; ++i) 
            heap = heap.InsertHeap(list[i], Compare);
        OutputTreeStats(heap);
        while (heap != null)
        {
            yield return heap.Value;
            heap = heap.ExtractHeap(Compare);
        }
    }

    public static void OutputTreeStats<T>(ITree<T> self)
    {
        var cnt = self.Count();
        var avgDepth = self.AverageDepth();
        var maxDepth = self.MaxDepth();
        Console.WriteLine(
            $"Tree has {cnt} nodes, with an average depth of {avgDepth:0.##} and max depth of {maxDepth}");
    }

    [Test]
    public static void TestMyHeapSort()
    {
        var input = CreateRandomArray(1000 * 1000);
        var sw = Stopwatch.StartNew();
        var output = HeapSort(input).ToList();
        Console.WriteLine($"Elapsed time for heap sort: {sw.Elapsed.TotalSeconds:0.####}");
        sw = Stopwatch.StartNew();
        var expected = input.OrderByDescending(x => x).ToList();
        Console.WriteLine($"Elapsed time for LINQ sort: {sw.Elapsed.TotalSeconds:0.####}");
        Assert.AreEqual(expected, output);
    }
}