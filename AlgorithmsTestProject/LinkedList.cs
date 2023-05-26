namespace AlgorithmsTestProject;


/// <summary>
/// A classic single linked list implementation.
/// </summary>
public class LinkedList<T> : IList<T>
{
    public class Iterator : IIterator<T>
    {
        public Node Node { get; }

        public Iterator(Node node)
            => Node = node;

        public T GetElement()
            => Node.Next.Value;

        public bool HasValue()
            => Node.Next != null;

        public IIterator<T> GetNext()
            => new Iterator(Node.Next);
    }

    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value, Node next)
            => (Value, Next) = (value, next);
    }

    private Node _head = new(default, null);

    public IIterator<T> GetIterator() => new Iterator(_head);

    public IIterator<T> Insert(IIterator<T> iterator, T item)
    {
        if (iterator is Iterator iter)
        {
            iter.Node.Next = new Node(item, iter.Node.Next);
            return iter;
        }
        throw new Exception("Invalid iterator type");
    }

    public IIterator<T> Remove(IIterator<T> iterator)
    {
        if (iterator is Iterator iter)
        {
            iter.Node.Next = iter.Node.Next.Next;
            return iter;
        }
        throw new Exception("Invalid iterator type");
    }
}

public interface IImmutableList<T> 
    : ISequence<T>
{
    IImmutableList<T> Add(T item);
    IImmutableList<T> Remove(IIterator<T> at);
}