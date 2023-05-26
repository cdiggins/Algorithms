using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace AlgorithmsTestProject
{
    public static class LinkedListTests
    {
        public static IList<int> CreateTestData()
        {
            var list = new LinkedList<int>();
            list.Prepend(3);
            list.Prepend(2);
            list.Prepend(1);
            return list;
        }

        public static void OutputList<T>(IList<T> xs)
        {
            foreach (var x in xs.Enumerate())
                Console.WriteLine(x);
        }

        [Test]
        public static void TestCount()
        {
            var list = CreateTestData();
            OutputList(list);
            Assert.AreEqual(3, list.Count());
        }

        public static bool CompareListWithArray<T>(IList<T> xs, T[] array)
        {
            return xs.Enumerate().SequenceEqual(array);
        }

        public static LinkedList<T> CreateListFromArray<T>(T[] array)
        {
            var tmp = new LinkedList<T>();
            foreach (var x in array.Reverse())
                tmp.Prepend(x);
            return tmp;
        }

        public static void TestPrepend()
        {

        }

        [Test]
        public static void TestAppend()
        {
            var list = new LinkedList<int>();
            list.Append(3);
            list.Append(2);
            list.Append(1);
            OutputList(list);
        }

        [Test]
        public static void TestGetAt()
        {
            var list = CreateTestData();
            var tmp = list.GetAt(1);
            Assert.AreEqual(2, tmp);
        }

        public static void TestSetAt()
        {
        }

        public static void TestSwap()
        {
        }

        public static void TestReverse()
        {
        }

        public static void TestEnumerate()
        {
        }
    }
}
