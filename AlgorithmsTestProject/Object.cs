namespace AlgorithmsTestProject;

public class Object : IMap<string, object>
{
    public Object(ISequence<(string, dynamic)> keyValues)
    {
        foreach (var kv in keyValues.Enumerate())
            _members.Add(kv.Item1, kv.Item2);
    }

    public dynamic GetValue(string key)
        => _members.GetValue(key);

    private SlowMap<string, dynamic> _members = new();
}

public static class ObjectDemo
{
    [Test]
    public void MyObjectTest
    {

    }

}