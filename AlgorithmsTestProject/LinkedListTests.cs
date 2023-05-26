using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Test]
        public static void TestCount()
        {
            var list = CreateTestData();
            Assert.AreEqual(3, list.Count());
        }

        public static void TestPrepend()
        {
        }

        public static void TestAppend()
        {
        }

        public static void TestGetAt()
        {
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
