namespace AlgorithmsTestProject;


/*
 * 
public class DynamicArrayToListAdapter<T> : IList<T, int>
{
    public T GetElement(int iter) 
        => throw new NotImplementedException();
    public bool AtEnd(int iter) 
        => throw new NotImplementedException();
    public int GetFirst() 
        => throw new NotImplementedException();
    public int GetNext(int iter) 
        => throw new NotImplementedException();
    public int Add(int iterator, T item) 
        => throw new NotImplementedException();
    public int Remove(int iterator) 
        => throw new NotImplementedException();
}
 */

public class DynamicArrayToListAdapter<T> : IList<T, int>
{
    public IDynamicArray<T> Adaptee { get; }

    public DynamicArrayToListAdapter(IDynamicArray<T> adaptee)
        => Adaptee = adaptee;

    public T GetElement(int iter) 
        => Adaptee[iter];

    public bool AtEnd(int iter) 
        => iter >= Adaptee.Count;

    public int GetFirst() 
        => 0;

    public int GetNext(int iter) 
        => iter + 1;

    public int Insert(int iterator, T item)
    {
        Adaptee.Insert(iterator, item);
        return iterator;
    }

    public int Remove(int iterator)
    {
        Adaptee.Remove(iterator);
        return iterator;
    }
}