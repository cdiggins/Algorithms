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
            var r = xs.ToConsList();
            Output(r);
            Assert.AreEqual(xs.Reverse(), r.ToEnumerable());
            Assert.AreEqual(xs, r.Reverse().ToEnumerable());
        }

        public static void TestInsert()
        {

        }

        public static void TestRemove()
        {

        }

    }
}
