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
        Array.Copy(old, _array, old.Length);
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
    {
        var oldCount = Count;
        Add(item);
        Array.Copy(_array, index, _array, index + 1, oldCount - index);
        this[index] = item;
    }

    public T Remove(int index)
    {
        var r = this[index];
        Array.Copy(_array, index + 1, _array, index, Count - index + 1);
        Count -= 1;
        return r;
    }
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
