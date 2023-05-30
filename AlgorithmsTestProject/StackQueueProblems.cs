
namespace AlgorithmsTestProject
{
    public class Stack<T> : IStack<T>
    {
        public void Push(T x)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty { get; }
    }

    public class Queue<T> : IQueue<T>
    {
        public void Enqueue(T x)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty { get; }
    }

    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        public void Enqueue(int priority, T element)
        {
            throw new NotImplementedException();
        }

        public T PeekHighestPriority()
        {
            throw new NotImplementedException();
        }

        public T DequeueHighestPriority()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty => throw new NotImplementedException();
    }

    public class QueueFromStack<T> : IQueue<T>
    {
        public readonly Stack<T> S1 = new();
        public readonly Stack<T> S2 = new();

        public void Enqueue(T x)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty { get; }
    }

    public class StackFromQueue<T> : IStack<T>
    {
        public readonly Queue<T> Q1 = new();
        public readonly Queue<T> Q2 = new();
        public void Push(T x)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty { get; }
    }
}
