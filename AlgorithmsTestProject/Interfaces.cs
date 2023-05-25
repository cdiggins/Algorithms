namespace AlgorithmsTestProject;


public interface IStack<T>
{
    void Push(T x);
    T Pop();
    T Peek();
    bool IsEmpty { get; }
}

public interface IQueue<T>
{
    void Enqueue(T x);
    T Dequeue();
    T Peek();
    bool IsEmpty { get; }
}

public interface IDeque<T>
{
    void PushFront(T x);
    T PeekFront();
    T PopFront();
    void PushBack(T x);
    T PeekBack();
    T PopBack();
    bool IsEmpty { get; }
}

public interface IArray<T>
{
    int Count { get; }
    T this[int index] { get; set; }
}

public interface IDynamicArray<T> : IArray<T>
{
    void Add(T x);
    void Insert(int index, T item);
    T Remove(int index);
}

public interface IPriorityQueue<T>
{
    void Enqueue(int priority, T element);
    T PeekHighestPriority();
    T DequeueHighestPriority();
}

public interface IIterator<T>
{
    T GetElement();
    bool HasValue();
    IIterator<T> GetNext();
}

public interface ISequence<T>
{
    IIterator<T> GetIterator();
}

public interface ISequence<T, TIterator>
{
    T GetElement(TIterator iter);
    bool AtEnd(TIterator iter);
    TIterator GetFirst();
    TIterator GetNext(TIterator iter);
}

public interface IList<T, TIterator>
    : ISequence<T, TIterator>
{
    TIterator Insert(TIterator iterator, T item);
    TIterator Remove(TIterator iterator);
}

public interface ITree<T>
{
    T Value { get; }
    IEnumerable<ITree<T>> Subtrees { get; }
}

public interface ITree<T, TNode>
{
    T GetValue(TNode node);
    IEnumerable<TNode> GetChildren(TNode node);
}

public interface IBinaryTree<T> : ITree<T>
{
    IBinaryTree<T> Left { get; }
    IBinaryTree<T> Right { get; }
}

public interface IBinaryTree<T, TNode> : ITree<T, TNode>
{
    TNode GetLeft(TNode node);
    TNode GetRight(TNode node);
}

public interface IGraph<T, TEdge, TNode>
{
    IEnumerable<TEdge> Edges { get; }
    IEnumerable<TNode> Nodes { get; }
    IEnumerable<TEdge> GetOutgoingEdges(TNode node);
    TNode GetSourceNode(TEdge edge);
    TNode GetTargetNode(TEdge edge);
    T GetValue(TNode node);
}

public interface IMap<TKey, TValue>
{
    TValue GetValue(TKey key);
}

public interface IMapContainer<TKey, TValue>
    : IMap<TKey, TValue>
{
    void Add(TKey key, TValue value);
    void Remove(TKey key);
}

public interface ISet<T>
{
    bool Contains(T x);
}

public interface ISetContainer<T>
    : ISet<T>
{
    void Add(T x);
    void Remove(T x);
}

public interface IMultiSet<T>
{
    int CountOf(T x);
}

public interface IMultiSetContainer<T>
    : ISetContainer<T>, IMultiSet<T>
{
}

public interface IStream<T>
{
    bool AtEnd { get; }
    T Read();
}

public interface IOutputStream<T>
{
    void Close();
    void Write(T x); 
}