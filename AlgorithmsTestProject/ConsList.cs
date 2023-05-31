namespace AlgorithmsTestProject;

public class ConsList<T> : IConsList<T>
{
    /// <summary>
    /// A read only property containing the value at the head of the list
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// A pointer to the rest of the list 
    /// </summary>
    public IConsList<T> Rest { get; }
    
    /// <summary>
    /// Computed property: returns true, if this is a reference to empty list
    /// </summary>
    public bool IsEmpty 
        => this == Empty;
    
    /// <summary>
    /// A static field containing a special value representing an empty list
    /// </summary>
    public static IConsList<T> Empty = new ConsList<T>();
    
    /// <summary>
    /// Constructor: sets the value and rest fields. 
    /// </summary>
    public ConsList(T value, IConsList<T> rest)
        => (Value, Rest) = (value, rest);

    /// <summary>
    /// Default constructor is private. Intended to be used
    /// only by the Empty. 
    /// </summary>
    private ConsList()
        : this(default, null)
    { }
}

public static class ConsListExtensions
{
    public static IConsList<T> Prepend<T>(
        this IConsList<T> self, T value)
        => new ConsList<T>(value, self);

    public static IConsList<T> Reverse<T>(this IConsList<T> self)
    {
        var r = Nil<T>();
        for (;!self.IsEmpty; self = self.Rest)
            r = r.Prepend(self.Value);
        return r;
    }
    
    public static IConsList<T2> ReverseSelect<T1, T2>(this IConsList<T1> self, 
        Func<T1, T2> transform)
    {
        var r = Nil<T2>();
        for (; !self.IsEmpty; self = self.Rest)
            r = r.Prepend(transform(self.Value));
        return r;
    }

    public static IConsList<T> ReverseFilter<T>(this IConsList<T> self, 
        Func<T, bool> predicate)
    {
        var r = Nil<T>();
        for (; !self.IsEmpty; self = self.Rest)
            if (predicate(self.Value))
                r = r.Prepend(self.Value);
        return r;
    }

    public static IConsList<T> Filter<T>(this IConsList<T> self,
        Func<T, bool> predicate)
    {
        return self.ReverseFilter(predicate).Reverse();
    }

    public static IConsList<T2> Select<T1, T2>(this IConsList<T1> self, Func<T1, T2> transform)
        => self.ReverseSelect(transform).Reverse();

    public static T GetLast<T>(this IConsList<T> self)
        => self.Reverse().Value;

    public static IConsList<T> SwapFirstTwo<T>(this IConsList<T> self)
        => self.Rest.Rest.Prepend(self.Value).Prepend(self.NextValue());

    public static IConsList<T> Nil<T>()
        => ConsList<T>.Empty;

    public static IConsList<T> Cons<T>(this T value)
        => Nil<T>().Prepend(value);

    public static T NextValue<T>(this IConsList<T> self)
        => self.Rest.Value;

    public static IConsList<T> Append<T>(
        this IConsList<T> self, T value)
        => self.Reverse().Prepend(value).Reverse();

    public static IConsList<T> Skip<T>(
        this IConsList<T> self, int n)
    {
        for (; n > 0; n--)
            self = self.Rest;
        return self;
    }

    public static T GetElement<T>(this IConsList<T> self, int n)
        => self.Skip(n).Value;

    public static TAcc Aggregate<TAcc, T>(
        this IConsList<T> self, 
        TAcc acc, 
        Func<TAcc, T, TAcc> f)
    {
        for (; !self.IsEmpty; self = self.Rest)
            acc = f(acc, self.Value);
        return acc;
    }

    public static IStack<T> ToStack<T>(this IConsList<T> self)
        => new StackFromConsList<T>(self);

    public static IIterator<T> ToIterator<T>(this IConsList<T> self)
        => new ConsListIterator<T>(self);

    public static ISequence<T> ToSequence<T>(this IConsList<T> self)
        => new ConsListSequence<T>(self);

    public static IEnumerable<T> ToEnumerable<T>(this IConsList<T> self)
    {
        for (; !self.IsEmpty; self = self.Rest)
            yield return self.Value;
    }

    public static IConsList<T> ToConsList<T>(this IEnumerable<T> self)
        => self.Aggregate(ConsList<T>.Empty, Prepend).Reverse();

    public static IConsList<T> ToConsList<T>(this ISequence<T> self)
        => self.Enumerate().ToConsList();
}

public class StackFromConsList<T> : IStack<T>
{
    private IConsList<T> _list;

    public StackFromConsList(IConsList<T> list = null)
        => _list = list ?? ConsList<T>.Empty;

    public void Push(T x)
        => _list = _list.Prepend(x);

    public T Pop()
    {
        var r = Peek();
        _list = _list.Rest;
        return r;
    }

    public T Peek()
        => _list.Value;

    public bool IsEmpty 
        => _list.IsEmpty;
}

public class ConsListIterator<T> : IIterator<T>
{
    private readonly IConsList<T> _list;

    public ConsListIterator(IConsList<T> list)
        => _list = list;

    public T GetElement() 
        => _list.Value;

    public bool HasValue()
        => !_list.IsEmpty;

    public IIterator<T> GetNext()
        => new ConsListIterator<T>(_list.Rest);
}

public class ConsListSequence<T> : ISequence<T>
{
    public IIterator<T> Iterator { get; }

    public ConsListSequence(IConsList<T> list)
        => Iterator = new ConsListIterator<T>(list);

    public IIterator<T> GetIterator()
        => Iterator;
}

public class ConsIntegerRange : IConsList<int>
{
    public int From { get; }
    public int Count { get; }

    public ConsIntegerRange(int from, int count)
        => (From, Count) = (from, count);

    public int Value
        => From;
    
    public bool IsEmpty 
        => Count == 0;

    public IConsList<int> Rest
        => new ConsIntegerRange(From + 1, Count - 1);
}

