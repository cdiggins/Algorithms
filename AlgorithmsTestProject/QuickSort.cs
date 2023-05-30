using System.Diagnostics;
using System.Text;

namespace AlgorithmsTestProject
{
    public static class SimpleQuickSort
    {
        public static IEnumerable<T> QuickSort<T>(
            IEnumerable<T> input,
            Func<T, T, int> compare)
        {
            if (!input.Any()) return input;
            var pivot = input.First();
            var rest = input.Skip(1);
            if (!rest.Any()) return input;
            var leftPart = rest.Where(x => compare(x, pivot) <= 0);
            var rightPart = rest.Where(x => compare(x, pivot) > 0);
            var left = QuickSort(leftPart, compare);
            var right = QuickSort(rightPart, compare);
            return left.Append(pivot).Concat(right);
        }
    }

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

        public bool IsGreaterThanOrEqualAt(int i, int j)
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

            var pivotIndex = Partition(from, count);

            // Notice that we can leave the pivot alone: it is a single value 
            // and is therefore sorted.
            // Everything to the left is smaller, but unsorted
            // Everything to the right is bigger, but unsorted 
            Sort(from, pivotIndex);
            Sort(pivotIndex + 1, upTo);
        }

        public void CheckPartitionInvariant(int from, int upto, int i, int j, int p)
        {
            Debug.Assert(i >= from);
            Debug.Assert(j >= from);
            Debug.Assert(from < upto);
            Debug.Assert(i < upto);
            Debug.Assert(j < upto);
            for (var x = from; x < i; ++x)
            {
                Debug.Assert(IsGreaterThanOrEqualAt(p, x));
            }
            for (var x = j + 1; x < upto; ++x)
            {
                Debug.Assert(IsGreaterThanOrEqualAt(x, p));
            }
        }

        public void OutputPartitionState(string message, int from, int count, int i, int j, int p)
        {
            var sb = new StringBuilder();
            Debug.Assert(i >= from);

            sb.Append("[");
            for (var x = from; x < from + count; x++)
            {
                if (x > from) sb.Append(" ");
                if (x == i)
                    sb.Append("i=");
                if (x == j)
                    sb.Append("j=");
                if (x == p)
                    sb.Append("p=");
                sb.Append(Input[x]);
            }
            sb.Append("]");

            Debug.WriteLine(message);
            Debug.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Partitions a section of array
        /// into small and large values.
        /// The return result is the index where the right partition
        /// starts.
        /// All values to the left of that value are less than it,
        /// and all values to the right of the value are greater than or equal. 
        /// </summary>
        public int Partition(int from, int count)
        {
            // Top index (exclusive)
            var upTo = from + count;

            // i is one past the left partition end
            // In other words next candidate for left partition
            var i = from;

            // p is the pivot index
            var p = upTo - 1;

            // j is one before the right partition start
            // In other words next candidate for right partition
            var j = p - 1;

            var index = 0;
            while (i < j)
            {
                CheckPartitionInvariant(from, upTo, i, j, p);
                OutputPartitionState($"{index++}: Looking for a left value to swap with", from, count, i, j, p);

                if (IsGreaterThanAt(p, i))
                {
                    i += 1;
                }
                else
                {
                    // We are going to need to swap.

                    // Find the first value on the right side
                    // that should not be in the right partitions
                    while (IsGreaterThanOrEqualAt(j, p) && j > i)
                    {
                        CheckPartitionInvariant(from, upTo, i, j, p);
                        OutputPartitionState($"{index++}: Looking for a right value to swap with", from, count, i, j, p);

                        j -= 1;
                    }

                    if (i < j)
                    {
                        OutputPartitionState("About to swap", from, count, i, j, p);
                        Swap(i, j);
                        i += 1;
                        j -= 1;
                        OutputPartitionState("Swapped", from, count, i, j, p);
                    }
                }

                CheckPartitionInvariant(from, upTo, i, j, p);
            }

            Swap(j, p);
            p = j;

            OutputPartitionState("Final state", from, count, i, j, p);
            CheckPartitionInvariant(from, upTo, i, j, p);

            return p;
        }
    }
}