using NUnit.Framework.Internal;

namespace AlgorithmsTestProject;

public abstract class BaseArray<T> : IDynamicArray<T>
{
    private const int InitialCapacity = 16;
    protected T[] _array = new T[InitialCapacity];
    private int Capacity => _array.Length;
    public int Count { get; protected set; }

    protected abstract int ComputeNewSize(int oldCapacity, int desiredCount);

    private void Resize(int size)
    {
        var old = _array;
        _array = new T[size];
        Array.Copy(old, _array, Count);
    }

    public T this[int index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    public void Add(T x)
    {
        Count += 1;
        if (Count > Capacity)
        {
            Resize(ComputeNewSize(Capacity, Count));
        }
        this[Count-1] = x;
    }

    public void Insert(int index, T item)
        => throw new NotImplementedException();
    
    public void Remove(int index)
        => throw new NotImplementedException();
}

public class DynamicArray<T> : BaseArray<T>
{
    protected override int ComputeNewSize(int oldCapacity, int desiredCount)
    {
        while (oldCapacity < desiredCount)
        {
            oldCapacity *= 2;
        }

        return oldCapacity;
    }
}

public class DynamicArrayAddOne<T> : BaseArray<T>
{
    protected override int ComputeNewSize(int oldCapacity, int desiredCount)
    {
        while (oldCapacity < desiredCount)
        {
            oldCapacity += 1;
        }

        return oldCapacity;
    }
}

public class DynamicArrayAdd100<T> : BaseArray<T>
{
    protected override int ComputeNewSize(int oldCapacity, int desiredCount)
    {
        while (oldCapacity < desiredCount)
        {
            oldCapacity += 100;
        }

        return oldCapacity;
    }
}

public static class DynamicArrayTests
{
    public static void OutputResults(List<Benchmarks.TestResult> results)
    {
        for (var i=1; i < results.Count; ++i)
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