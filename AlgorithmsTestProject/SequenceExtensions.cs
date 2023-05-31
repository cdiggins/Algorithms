namespace AlgorithmsTestProject;

public static class SequenceExtensions
{
    public static IEnumerable<T> Enumerate<T>(this ISequence<T> self)
        => self.GetIterator().Enumerate();

    public static IEnumerable<T> Enumerate<T>(this IIterator<T> self)
    {
        for (;self.HasValue(); self = self.GetNext())
            yield return self.GetElement();
    }
}