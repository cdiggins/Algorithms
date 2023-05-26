using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal.Execution;

namespace IntroAlgoData
{
    public static class Generators
    {
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> self, 
            Func<T, bool> predicate)
        {
            foreach (var x in self)
                if (predicate(x)) 
                    yield return x;
        }

        public static IEnumerable<T2> Select<T1, T2>(
            this IEnumerable<T1> self, 
            Func<T1, T2> map)
        {
            foreach (var x in self)
                yield return map(x);
        }

        public static TAcc Aggregate<T, TAcc>(
            this IEnumerable<T> self, 
            TAcc acc, Func<TAcc, T, TAcc> reducer)
        {
            foreach (var x in self)
                acc = reducer(acc, x);
            return acc;
        }

        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> self,
            Func<T, int, bool> predicate)
        {
            var i = 0;
            foreach (var x in self)
                if (predicate(x, i++))
                    yield return x;
        }

        public static IEnumerable<T2> Select<T1, T2>(
            this IEnumerable<T1> self,
            Func<T1, int, T2> map)
        {
            var i = 0;
            foreach (var x in self)
                yield return map(x, i++);
        }

        public static TAcc Aggregate<T, TAcc>(
            this IEnumerable<T> self,
            TAcc acc, Func<TAcc, T, int, TAcc> reducer)
        {
            var i = 0;
            foreach (var x in self)
                acc = reducer(acc, x, i++);
            return acc;
        }

        public static IEnumerable<T3> Zip<T1, T2, T3>(this IEnumerable<T1> self, IEnumerable<T2> other, Func<T1, T2, T3> zip)
        {
            using var e1 = self.GetEnumerator();
            using var e2 = other.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return zip(e1.Current, e2.Current);
            }
        }
        
    }
}
