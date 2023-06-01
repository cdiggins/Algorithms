namespace AlgorithmsTestProject;

public class FunctionalArray<T>
    : IReadOnlyArray<T>
{
    public int Count { get; }
    private Func<int, T> _func { get; }
    public T this[int index] => _func(index);

    public FunctionalArray(int count, Func<int, T> func)
        => (Count, _func) = (count, func);
}

public static class ReadOnlyArrayExtensions
{
    public static IReadOnlyArray<T> Select<T>(
        this int count, Func<int, T> f)
        => new FunctionalArray<T>(count, f);

    public static IReadOnlyArray<T2> Select<T1, T2>(
        this IReadOnlyArray<T1> self, Func<T1, T2> f)
        => self.Count.Select(n => f(self[n]));
}