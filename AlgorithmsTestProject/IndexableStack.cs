namespace AlgorithmsTestProject;

public class FastStack<T> : IStack<T>
{
    public Buffer Current { get; set; } = new Buffer();

    public class Buffer 
    {
        public T[] Values { get; }
        public int Capacity => Values.Length;
        public int Count { get; set; }
        public T this[int index]
        {
            get => Values[index];
            set => Values[index] = value;
        }
        public Buffer Next { get; set; }
        public bool IsFull => Count == Capacity;
        public bool IsEmpty => Capacity == 0;

        public Buffer(Buffer next = null)
        {
            if (next != null)
                Values = new T[next.Capacity * 2];
            else
                Values = new T[16];
            Next = next;
        }

        public void Add(T value)
            => Values[Count++] = value;

        public T Remove()
            => Values[--Count];
    }

    public void Push(T x)
    {
        if (Current == null || Current.IsFull)
            Current = new Buffer(Current);
        Current.Add(x);
    }

    public T Pop()
    {
        if (Current.IsEmpty)
            Current = Current.Next;
        return Current.Remove();
    }

    public T Peek()
    {
        var tmp = Pop();
        Push(tmp);
        return tmp;
    }

    public bool IsEmpty 
        => Current == null || (Current.IsEmpty && Current.Next == null);
}

public static class FastStackTests
{
    [Test]
    public static void TestFastStack()
    {
        var stack = new FastStack<int>();
        stack.Push(1);
        Assert.AreEqual(1, stack.Peek());
        stack.Push(2);
        Assert.AreEqual(2, stack.Peek());
        stack.Push(3);
        Assert.AreEqual(3, stack.Peek());

        Assert.AreEqual(3, stack.Pop());
        Assert.AreEqual(2, stack.Pop());
        Assert.AreEqual(1, stack.Pop());
    }
}