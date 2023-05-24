namespace AlgorithmsTestProject;

public static class Helper
{
    public static void OutputContents<T>(IEnumerable<T> xs)
    {
        foreach (var x in xs)
        {
            Console.Write(x);
            Console.Write(' ');
        }
        Console.WriteLine();
    }

    public static bool HasBitSet(int n, int bitIndex)
    {
        var mask = 0x1 << bitIndex;
        return (n & mask) != 0;
    }

    public static int CountBits(int n)
    {
        var sum = 0;
        for (var i = 0; i < 31; i++)
        {
            sum += HasBitSet(n, i) ? 1 : 0;
        }

        return sum;
    }

    public static bool IsPowerOfTwo(int n)
    {
        return CountBits(n) == 1;
    }

    public static int SumPowersOfTwo(int n)
    {
        var sum = 0;
        for (var i = 0; i < n; ++i)
        {
            if (IsPowerOfTwo(i))
                sum += i;
        }

        return sum;
    }

    public static int Pow2(int n)
        => 1 << n;

    public static int Log2(int n)
        => (int)Math.Ceiling(Math.Log2(n));

    public static int SumPowersOfTwoUsingLog(int n)
    {
        var sum = 0;
        for (var i = 0; i < Log2(n); ++i)
        {
            sum += Pow2(i);
        }
        return sum;
    }

    [Test]
    public static void TestSumPowersOfTwoUsingLog()
    {
        for (var i = 0; i < 66; ++i)
        {
            var a = SumPowersOfTwo(i);
            var b = SumPowersOfTwoUsingLog(i);
            Assert.AreEqual(a, b);
            Console.WriteLine($"Sums of first {i} powers of two = {b}");
        }
    }
        
    [Test]
    public static void TestSumPowersOfTwo()
    {
        for (var i = 0; i < 66; ++i)
        {
            Console.WriteLine($"Sums of first {i} powers of two = {SumPowersOfTwo(i)}");
        }
    }
}