#pragma warning disable NUnit2005
namespace AlgorithmsTestProject;

public static class ArrayProblemsTests
{
    public static int[] EmptyArray 
        = Array.Empty<int>();
    
    public static int[] ArrayOfOne 
        = { 1 };

    public static int[] TwoOnes
        = { 1, 1 };

    public static int[] ThreeOnes
        = { 1, 1, 1 };

    public static int[] Alternating
        = { 1, 0, 1, 0, 1 };

    public static int[] ArrayToTen 
        = Enumerable.Range(1, 10).ToArray();
    
    public static int[] ReverseArrayToTen 
        = ArrayToTen.OrderByDescending(x => x).ToArray();

    public static int[] RepeatedArray
        = Enumerable.Repeat(9, 100).ToArray();

    public static IEnumerable<T> Generate<T>(T seed, Func<T, T> gen)
    {
        while (true)
        {
            yield return seed;
            seed = gen(seed);
        }
    }

    public static IEnumerable<T> Generate<T>(T seed1, T seed2, Func<T, T, T> gen)
    {
        yield return seed1;
        while (true)
        {
            yield return seed2;
            var old = seed2;
            seed2 = gen(seed1, seed2);
        }
    }

    public static IEnumerable<int> PseudoRandom()
        => Generate(1337, x => x ^ (x >> 3) + (x << 29));

    public static int[] SomeRandomInts
        = PseudoRandom().Take(5).ToArray();

    public static int[] HandPicked
        = { 99, 1, 5 };

    public static int[] First5Fibonnaci
        = Generate(0, 1, (x, y) => x + y).Take(10).ToArray();

    public static int[][] TestInputs =
    {
        EmptyArray,
        ArrayOfOne,
        TwoOnes,
        ThreeOnes,
        Alternating,
        ArrayToTen,
        ReverseArrayToTen,
        HandPicked,
        RepeatedArray,
        First5Fibonnaci,
        SomeRandomInts,
    };

    [Test]
    [TestCaseSource(nameof(TestInputs))]
    public static void AreEqualTest(int[] input)
    {
        Assert.That(input, Is.EqualTo(input));

        foreach (var tmp in TestInputs)
        {
            var expected = input.SequenceEqual(tmp);
            Assert.That(ArrayProblems.AreArraysEqual(input, tmp), Is.EqualTo(expected));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestInputs))]
    public static void SwapTest(int[] input)
    {
        if (input.Length < 2)
        {
            Assert.Throws<Exception>(() => ArrayProblems.Swap(input, 0, 1));
        }
        else
        {
            var tmp1 = input[0];
            var tmp2 = input[1];
            Assert.AreEqual(tmp1, input[0]);
            Assert.AreEqual(tmp2, input[1]);
            ArrayProblems.Swap(input, 0, 1);
            Assert.AreEqual(tmp1, input[1]);
            Assert.AreEqual(tmp2, input[0]);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestInputs))]
    public static void FirstElementTest(int[] input)
    {
        if (input.Length < 1)
        {
            Assert.Throws<Exception>(() => ArrayProblems.Swap(input, 0, 1));
        }
        else
        {
            Assert.AreEqual(input[0], ArrayProblems.FirstElement(input));
        }
    }

    [Test]
    public static void LastElementTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void MiddleElementTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void ReverseTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void MinTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void MaxTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void IndexOfMinTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void IndexOfMaxTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void IndexOfTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void IndexOfTest1()
    {
        Assert.Fail();
    }

    [Test]
    public static void CountTest()
    {
        Assert.Fail();
    }

    [Test]
    public static void CountTest1()
    {
        Assert.Fail();
    }

    [Test]
    public static void HasDuplicatesTest()
    {
        Assert.Fail();
    }

    [Test]
    [TestCaseSource(nameof(TestInputs))]
    public static void OutputContents(int[] input)
    {
        Helper.OutputContents(input);
    }
}