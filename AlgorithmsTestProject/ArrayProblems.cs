using System.Text;

namespace AlgorithmsTestProject;

public static class ArrayProblems
{
    public static bool AreArraysEqual<T>(T[] xs, T[] ys)
    {
        if (xs.Length != ys.Length) return false;
        for (var i = 0; i < xs.Length; i++)
        {
            if (!xs[i].Equals(ys[i]))
                return false;
        }

        return true;
    }

    public static void Swap<T>(T[] xs, int a, int b)
    {
        var tmp = xs[a];
        xs[a] = xs[b];
        xs[b] = tmp;
    }

    public static T FirstElement<T>(T[] xs)
    {
        return xs[0];
    }

    public static T LastElement<T>(T[] xs)
    {
        return xs[xs.Length - 1];
    }

    public static T MiddleElement<T>(T[] xs)
    {
        return xs[xs.Length / 2];
    }

    public static void Reverse<T>(T[] xs)
    {
        // Consider what would happen if I went to the end.
        for (var i = 0; i < xs.Length / 2; ++i)
        {
            // A common pattern: xs.Length - 1 - i
            // means ith item from the last
            Swap(xs, i, xs.Length - 1 - i);
        }
    }

    public static int CountElement<T>(T[] xs, T element)
    {
        var sum = 0;
        for (var i=0; i < xs.Length; ++i)
            if (xs[i].Equals(element))
                sum++;
        return sum;
    }

    public static string ToCommaDelimitedString<T>(T[] xs)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < xs.Length; ++i)
        {
            if (i > 0) sb.Append(',');
            sb.Append(xs[i].ToString());
        }
        return sb.ToString();
    }

    // Bonus problems

    public static int Count<T>(T[] xs, Func<T, bool> predicate)
    {
        var sum = 0;
        for (var i = 0; i < xs.Length; ++i)
            if (predicate(xs[i]))
                sum++;
        return sum;
    }

    public static T Min<T>(T[] xs, Func<T, T, int> comparer)
    {
        var min = xs[0];
        for (var i = 1; i < xs.Length; ++i)
            if (comparer(xs[i], min) < 0)
                min = xs[i];
        return min;
    }

    public static T Max<T>(T[] xs, Func<T, T, int> comparer)
    {
        var max = xs[0];
        for (var i = 1; i < xs.Length; ++i)
            if (comparer(xs[i], max) > 0)
                max = xs[i];
        return max;
    }

    public static bool HasDuplicates<T>(T[] xs)
    {
        return xs.Distinct().Count() != xs.Length;
    }
}