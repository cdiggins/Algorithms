using System.Security.Cryptography.X509Certificates;

namespace AlgorithmsTestProject
{
    public static class LinkedListExercises
    {
        public static int Count<T>(this IList<T> self)
        {
            return self.Enumerate().Count();
        }

        /*public static void Prepend<T>(this IList<T>T x)
        void Append(T x)
        T GetAt(int index)
        void SetAt(int index, T element)
        void Swap(Iterator<T> a, Iterator<T> b)
        IList<T> Reverse()
        */
        public static IEnumerable<T> Enumerate<T>(this IList<T> self)
        {
            for (var iter = self.GetIterator(); 
                 iter.HasValue(); 
                 iter = iter.GetNext())
            {
                yield return iter.GetElement();
            }
        }
    }
}
