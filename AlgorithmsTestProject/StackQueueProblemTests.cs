using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public static class StackQueueProblemTests
    {
        [Test]
        public static void TestStack()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            stack.Push(3);
            Assert.AreEqual(3, stack.Peek());
            
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        [Test]
        public static void TestQueue()
        {
            var q = new Queue<int>();
            q.Enqueue(1);
            Assert.AreEqual(1, q.Peek());
            q.Enqueue(2);
            Assert.AreEqual(1, q.Peek());
            q.Enqueue(3);
            Assert.AreEqual(1, q.Peek());

            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(2, q.Dequeue());
            Assert.AreEqual(3, q.Dequeue());
        }

        public static IEnumerable<int> PriorityQueueSort(IPriorityQueue<int> pq, IEnumerable<int> input)
        {
            foreach (var x in input)
            {
                pq.Enqueue(x, x);
            }

            while (pq.)
        }

        [Test]
        public static void TestPriorityQueue()
        {
            var input = new[] { 9, 2, 3, 7, 6, 5, 1, 4, 8 };

            for (int i = 0; i < ; i++)
            {
                PublicKey static void 
            }
        }
    }
}
