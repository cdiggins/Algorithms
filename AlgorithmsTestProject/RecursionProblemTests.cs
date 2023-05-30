namespace AlgorithmsTestProject;

public static class RecursionProblemTests
{
    [Test]
    public static void TestSort()
    {
        var xs = new List<int>() { 1, 5, 4, 2, 3 };
        var ys = Sort(xs);
        Assert.AreEqual(new[] { 1,2,3,4,5}, ys);
    }

    public static void LoopDemoForEach<T>(IEnumerable<T> xs)
    {
        foreach (var x in xs)
            Console.WriteLine(x);
    }

    public static void LoopDemoWhile<T>(IEnumerable<T> xs)
    {
        using var e = xs.GetEnumerator();
        while (e.MoveNext())
        {
            Console.WriteLine(e.Current);
        }
    }

    public static void LoopDemoGoto<T>(IEnumerable<T> xs)
    {
        using var e = xs.GetEnumerator();
        loop:
        if (!e.MoveNext())
            return;
        Console.WriteLine(e.Current);
        goto loop;
    }

    public static void LoopDemoDoWhile<T>(IEnumerable<T> xs)
    {
        using var e = xs.GetEnumerator();
        if (e.MoveNext())
        {
            do
            {
                Console.WriteLine(e.Current);
            } 
            while (e.MoveNext());
        }
    }

    public static void LoopDemoFor<T>(IEnumerable<T> xs)
    {
        using var e = xs.GetEnumerator();
        for (var x = e.Current; e.MoveNext(); x = e.Current)
        {
            Console.WriteLine(x);
        }
    }

    public static void RecurseDemo<T>(IEnumerable<T> xs)
    {
        if (!xs.Any())
            return;
        Console.WriteLine(xs.First());
        RecurseDemo(xs.Skip(1));
    }

    [Test]
    public static void TestMerge()
    {
        var xs = new[] { 1, 4, 6 };
        var ys = new[] { 2, 3, 5 };
        var zs = RecursionProblems.Merge(xs, ys);
        Assert.AreEqual(new[] { 1,2,3,4,5,6}, zs);
    }


    public static TAcc Aggregate<TAcc, T>(IIterator<T> iter, TAcc accumulator,
        Func<TAcc, T, TAcc> func)
    {
        if (!iter.HasValue())
            return accumulator;
        return func(
            Aggregate(iter.GetNext(), accumulator, func),
            iter.GetElement());
    }

    public static TOutput BinaryRecursion<TInput, TOutput>(TInput input,
        Func<TInput, bool> termination,
        Func<TInput, TOutput> map,
        Func<TInput, (TInput, TInput)> split,
        Func<TInput, TOutput, TOutput, TOutput> join)
    {
        if (termination(input))
            return map(input);
        var (part1, part2) = split(input);
        var a = BinaryRecursion(part1, termination, map, split, join);
        var b = BinaryRecursion(part2, termination, map, split, join);
        return join(input, a, b);
    }

    public static IEnumerable<int> Sort(IEnumerable<int> input)
    {
        return BinaryRecursion(
            input,
            xs => xs.Count() < 2,
            xs => xs,
            xs => (
                xs.Skip(1).Where(x => x < xs.First()),
                xs.Skip(1).Where(x => x >= xs.First())),
            (xs, a, b) => a.Append(xs.First()).Concat(b));
    }

    public static IEnumerable<int> Sort2(IEnumerable<int> input)
    {
        return BinaryRecursion(
            input,
            xs => xs.Count() < 2,
            xs => xs,
            xs => (
                xs.Take(xs.Count() / 2),
                xs.Skip(xs.Count() / 2)),
            (xs, a, b) => RecursionProblems.Merge(a, b));
    }
}