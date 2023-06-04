using System.Diagnostics;
using System.Text;

namespace AlgorithmsTestProject
{
    public class MyKey
    {
        public MyKey(string s)
        {
            MyString = s;
        }

        public readonly string MyString;

        public override int GetHashCode()
        {
            var sum = 0;
            for (var i=0; i < MyString.Length; ++i)
                sum = sum * 100 + MyString[i];
            return sum;
        }

        public override bool Equals(object obj)
        {
            return obj is MyKey other && other.MyString == MyString;
        }
    }

    public static class HashMapTest
    {
        public static Random Rng = new Random();

        public static char RandomLetter()
        {
            return (char)('a' + Rng.Next(26));
        }

        public static string RandomString()
        {
            var sb = new StringBuilder();
            sb.Append('a');
            for (var i = 0; i < 50000; ++i)
            {
                sb.Append(RandomLetter());
            }
            return sb.ToString();
        }

        public static IEnumerable<string> GeneratInputStrings()
        {
            for (var i = 0; i < 1000; ++i)
                yield return RandomString();
        }

        [Test]
        public static void TestHash()
        {
            var input = GeneratInputStrings().Take(10000).ToArray();
            foreach (var s in input.Take(10))
            {
                //Console.WriteLine(s);
            }
            var keys = input.Select(x => new MyKey(x)).ToArray();

            {
                Console.WriteLine($"Creating a dictionary with my naive hash function");
                var sw = Stopwatch.StartNew();
                var d = new Dictionary<MyKey, bool>();
                foreach (var k in keys)
                {
                    if (!d.ContainsKey(k))
                        d.Add(k, true);
                }

                Console.WriteLine($"Time to insert {keys.Length} items was {sw.Elapsed.TotalMilliseconds:0.####}ms");
            }
            {
                Console.WriteLine($"Creating a dictionary with default hash function");
                var sw = Stopwatch.StartNew();
                var d = new Dictionary<string, bool>();
                foreach (var k in keys)
                {
                    if (!d.ContainsKey(k.MyString))
                        d.Add(k.MyString, true);
                }

                Console.WriteLine($"Time to insert {keys.Length} items was {sw.Elapsed.TotalMilliseconds:0.####}ms");
            }
        }
    }
}
