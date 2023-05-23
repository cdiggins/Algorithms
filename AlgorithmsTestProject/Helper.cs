namespace AlgorithmsTestProject;

public static class Helper
{
    public static void OutputContents<T>(IEnumerable<T> xs)
    {
        foreach (var x in xs)
        {
            Console.Write(x);
            Console.Write(' ');
        }
        Console.WriteLine();
    }
}