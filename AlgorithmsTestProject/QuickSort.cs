using System.Diagnostics;

namespace AlgorithmsTestProject
{
    public class QuickSort<T>
    {
        public System.Collections.Generic.IList<T> Input { get; }
        public Func<T, T, int> Compare { get; }

        public QuickSort(
            System.Collections.Generic.IList<T> input, 
            Func<T, T, int> compare)
        {
            Input = input;
            Compare = compare;
            Sort(0, Input.Count);
        }

        public void Swap(int a, int b)
        {
            (Input[a],Input[b]) = (Input[b], Input[a]);
        }

        public bool IsGreaterThan(T a, T b)
        {
            return Compare(a, b) > 0;
        }

        public bool IsGreaterThanOrEqual(T a, T b)
        {
            return Compare(a, b) >= 0;
        }

        public bool IsGreaterThanAt(int i, int j)
        {
            return IsGreaterThan(Input[i], Input[j]); 
        }

        public bool IsGreaterThanAtOrEqual(int i, int j)
        {
            return IsGreaterThanOrEqual(Input[i], Input[j]);
        }

        public void TwoWaySort(int a, int b)
        {
            if (IsGreaterThanAt(a, b))
            {
                Swap(a, b);
            }
        }

        public void Sort(int from, int upTo)
        {
            var count = upTo - from;

            // Base case: When the count is 0 or 1, we are already sorted 
            if (count < 2)
                return;

            // A small optimization: sorting two items is much simpler
            if (count == 2)
            {
                TwoWaySort(from, from + 1);
                return;
            }

            var pivotIndex = Partition(from, upTo);

#if DEBUG            
            CheckPartitionInvariant(pivotIndex, from, upTo);
#endif

            // Notice that we can leave the pivot alone: it is a single value 
            // and is therefore sorted.
            // Everything to the left is smaller, but unsorted
            // Everything to the right is bigger, but unsorted 
            Sort(from, pivotIndex - 1);
            Sort(pivotIndex + 1, upTo);
        }

        public void CheckPartitionInvariant(int pivotIndex, int from, int upTo)
        {
            Debug.Assert(pivotIndex >= from);
            Debug.Assert(pivotIndex < upTo);
            for (var i = 0; i < upTo; i++)
            {
                if (i < pivotIndex)
                {
                    //Debug.Assert(IsGreaterThanAtOrEqual(pivotIndex, i));
                }
                else if (i > pivotIndex)
                {
                    //Debug.Assert(IsGreaterThanAtOrEqual(i, pivotIndex));
                }
            }
        }

        /// <summary>
        /// Partitions a section of array
        /// into small and large values.
        /// The return result is the index where the partition
        /// starts. All values to the left of that value are less than it,
        /// and all values to the right of the value are greater than or equal. 
        /// </summary>
        public int Partition(int from, int upTo)
        {
            var i = from;
            var j = upTo - 1;
            var pivot = Input[j];

            // The right partition 

            // Move the i value up (left partition)
            // Move the j value down (right partition)
            // Make sure that everything on 
            while (i < j)
            {
                // Is a value in the left greater than pivot? 
                if (IsGreaterThan(Input[i], pivot))
                {
                    // We are going to have to find a value to swap it with
                    // We do this by finding a value in the right partition
                    // that does not belong. So while values above or equal to a[j]
                    // are correct, decrement j
                    while (IsGreaterThanOrEqual(Input[j], pivot))
                    {
                        j -= 1;

                        // Make sure we don't go past i. 
                        // If we get to i then 
                        // I could have combined this with the invariant
                        if (j == i)
                            break;
                    }

                    // Make sure we aren't done completely 
                    if (i != j)
                    {
                        // We not have a candidate to swap with. 
                        // value at i is greater than candidate
                        // value at j is less than candidate
                        Debug.Assert(IsGreaterThanAt(i, j));

                        Swap(i, j);
                        // We now know that a[j] is greater than or equal to pivot 
                        // Because it is the old a[i].
                        // So we can decrement the right partition index
                        j -= 1; 
                    }
                }

                if (i != j)
                    i += 1; 
            }

            Debug.Assert(i == j);
            Swap(i + 1, upTo-1);
            return i;
        }
    }
}