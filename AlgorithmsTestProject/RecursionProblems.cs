
namespace AlgorithmsTestProject
{
    public static class RecursionProblems
    {
        public static int Factorial(int n)
        {
            throw new NotImplementedException();
        }

        public static int Fibonnaci(int n)
        {
            throw new NotImplementedException();
        }

        public static void ReverseArray<T>(T[] array, int n = 0)
        {
            throw new NotImplementedException();
        }

        public static int Count<T>(IIterator<T> iterator)
        {
            throw new NotImplementedException();
        }

        public static IIterator<T> GetLast<T>(IIterator<T> iterator)
        {
            throw new NotImplementedException();
        }

        public static int Sum(IIterator<int> iterator)
        {
            throw new NotImplementedException();
        }

        public static IList<T> Reverse<T>(IList<T> xs)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<int> MergeSort(IEnumerable<int> values)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<int> Merge(
            IEnumerable<int> xs, 
            IEnumerable<int> ys)
        {
            foreach (var x in xs)
            {
                while (ys.Any() && ys.First() < x)
                {
                    yield return ys.First();
                    ys = ys.Skip(1);
                }

                yield return x;
            }
        }
    }
}
