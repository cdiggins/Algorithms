using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public static class ConsListTests
    {
        public static void Output<T>(IConsList<T> xs)
        {
            foreach (var x in xs.ToEnumerable())
            {
                Console.WriteLine(x);
            }
        }

        [Test]
        public static void ConsListTest()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var r = ConsList<int>.Empty;
            foreach (var x in xs)
            {
                r = r.Prepend(x);
            }
            Output(r);
            Assert.AreEqual(xs.Reverse(), r.ToEnumerable());
            Assert.AreEqual(xs, r.Reverse().ToEnumerable());
        }

        public static void TestInsert()
        {

        }
    }


    public static class ConsListProblems
    {
        public static IConsList<T> InsertBefore<T>(this IConsList<T> self, 
            int index, T value)
        {
            throw new NotImplementedException();
        }

        public static IConsList<T> RemoveAt<T>(this IConsList<T> self, 
            int index, T value)
        {
            throw new NotImplementedException();
        }
     }

}
