using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public interface IArray<T>
    {
        T this[int index]
        {
            get;
            set;
        }
        int Count { get; }
    }

    public interface IDynamicArray<T> : IArray<T>
    {
        void Add(T item);
    }

    public class Array<T> : IDynamicArray<T>
    {
        public Array()
        {
            internalArray = Array.Empty<T>();
        }
        
        private T[] internalArray; 

        public T this[int index]
        {
            get
            {
                return internalArray[index];
            }
            set 
            {
                internalArray[index] = value;
            }
        }

        public int Count
        {
            get; 
            private set;
        }

        public void Add(T x)
        {
            Count += 1;
            if (Count >= internalArray.Length)
            {
                var copy = new T[internalArray.Length + 10];
                Array.Copy(internalArray, copy, internalArray.Length);
                internalArray = copy;
            }
            internalArray[Count - 1] = x;
        }
    }

    public static class MyTest
    {
        [Test]
        public static void TestMyArray()
        {
            Array<int> myArray = new Array<int>();
            for (var i=0; i < 1000000; ++i)
                myArray.Add(i);
            Console.WriteLine($"The count of my array is {myArray.Count}");
            Console.WriteLine($"The element at 0 is {myArray[0]}");
        }
    }
}
