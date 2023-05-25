using Newtonsoft.Json.Linq;

namespace AlgorithmsTestProject;

public class ListToDynamicArrayAdapter<T, TIterator> 
    : IDynamicArray<T>
{
    public IList<T, TIterator> Adaptee { get; }
    
    public int Count 
    { 
        get
        {
            var cnt = 0;
            var iter = Adaptee.GetFirst();
            while (!Adaptee.AtEnd(iter))
            {
                iter = Adaptee.GetNext(iter);
                cnt++;
            }
            return cnt; 
        }
    }

    private TIterator _iteratorAt(int n)
    {
        var iter = Adaptee.GetFirst();
        while (n-- > 0)
        {
            iter = Adaptee.GetNext(iter);
        }

        return iter;
    }

    public T this[int index]
    {
        get
        {
            var iter = _iteratorAt(index);
            return Adaptee.GetElement(iter);
        }
        set
        {
            var iter = _iteratorAt(index);
            Adaptee.Insert(iter, value);
            Adaptee.Remove(iter);
        }
    }

    public void Add(T x)
    {
        Insert(Count, x);
    }

    public void Insert(int index, T item)
    {
        Adaptee.Insert(_iteratorAt(index), item);
    }

    public T Remove(int index)
    {
        var iter = _iteratorAt(index);
        var r = Adaptee.GetElement(iter);
        Adaptee.Remove(iter);
        return r;
    }
}