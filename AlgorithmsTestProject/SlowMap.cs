namespace AlgorithmsTestProject;

public class SlowMap<TKey, TValue> : IMapContainer<TKey, TValue>
{
    public IList<(TKey, TValue)> KeyValues 
        = new LinkedList<(TKey, TValue)>();

    public TValue GetValue(TKey key)
    {
        foreach (var kv in KeyValues.Enumerate())
            if (kv.Item1.Equals(key))
                return kv.Item2;
        throw new Exception($"Key {key} not found");
    }

    public void Add(TKey key, TValue value)
    {
        KeyValues.Append((key, value));
    }

    public void Remove(TKey key)
    {
        for (var iter = KeyValues.GetIterator();
             iter.HasValue();
             iter = iter.GetNext())
        {
            if (iter.GetElement().Item1.Equals(key))
            {
                KeyValues.Remove(iter);
                return;
            }
        }

        throw new Exception($"Key {key} not found");
    }
}