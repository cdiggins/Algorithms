namespace AlgorithmsTestProject
{
    public static class ConsListTests
    {
        public static void Output<T>(IConsList<T> xs)
        {
            foreach (var x in xs.ToEnumerable())
            {
                Console.Write(x);
                Console.Write(";");
            }
            Console.WriteLine();
        }

        public static IConsList<T> MyConcat<T>(IConsList<T> xs, IConsList<T> ys)
        {
            var r = ys;
            foreach (var x in xs.Reverse().ToEnumerable())
                r = r.Prepend(x);
            return r;
        }

        public static IConsList<T> MyRemove<T>(IConsList<T> xs, int n)
        {
            Console.WriteLine($"Calling my remove at the {n} index ");
            Output(xs);

            Console.WriteLine($"First {n} elements are");
            var left = MyTake(xs, n);
            Output(left);

            Console.WriteLine($"After {n}+1 elements are");
            var right = xs.Skip(n + 1);
            Output(right);

            return MyConcat(left, right);
        }

        public static IConsList<T> MyInsert<T>(IConsList<T> xs, int n, T x)
        {
            Console.WriteLine("Calling my insert");
            Output(xs);
            var left = MyTake(xs, n);

            Console.WriteLine($"First {n} elements is:");
            Output(left);

            var right = xs.Skip(n);

            Console.WriteLine($"Elements after {n} is:");
            Output(right);

            Console.WriteLine($"Prepending the value to be inserted {x}");
            right = right.Prepend(x);
            Output(right);

            var result = MyConcat(left, right);
            Console.WriteLine("Result of concatenation is");
            Output(result);

            return result;
        }

        public static IConsList<T> MyTake<T>(IConsList<T> xs, int n)
        {
            var r = ConsList<T>.Empty;
            for (var i = 0; i < n; ++i)
            {
                r = r.Prepend(xs.Value);
                xs = xs.Rest;
            }

            return r.Reverse();
        }

        [Test]
        public static void MyTestConcat()
        {
            var xs = new[] { 1, 2, 3 };
            Output(xs.ToConsList());
            var ys = new[] { 4, 5 };
            Output(ys.ToConsList());
            var zs = MyConcat(xs.ToConsList(), ys.ToConsList());
            Output(zs);
            Assert.AreEqual(new[] { 1, 2, 3, 4, 5},zs.ToEnumerable());
        }

        [Test]
        public static void ConsListTest()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var r = xs.ToConsList();
            Output(r);
            Assert.AreEqual(xs, r.ToEnumerable());
            Assert.AreEqual(xs, r.ToEnumerable());
        }

        [Test]
        public static void MyTakeTest()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var r = xs.ToConsList();
            var tk = MyTake(r, 3);
            Output(tk);
            Assert.AreEqual(new[] {1, 2, 3}, tk.ToEnumerable());
        }

        [Test]
        public static void TestInsert()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var exp = new[] { 1, 2, 2, 3, 4, 5 };
            var r = xs.ToConsList();
            var output = r.InsertBefore(2, 2);
            Assert.AreEqual(exp, output.ToEnumerable());
        }

        [Test]
        public static void TestRemove()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var exp = new[] { 1, 2, 4, 5 };
            var r = xs.ToConsList();
            var output = r.RemoveAt(2);
            Assert.AreEqual(exp, output.ToEnumerable());
        }

        [Test]
        public static void MyTestRemove()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var exp = new[] { 1, 2, 4, 5 };
            var r = xs.ToConsList();
            var output = MyRemove(r, 2);
            Output(output);
            Assert.AreEqual(exp, output.ToEnumerable());
        }

        [Test]
        public static void MyTestInsert()
        {
            var xs = new[] { 1, 2, 3, 4, 5 };
            var exp = new[] { 1, 2, 9, 3, 4, 5 };
            var r = xs.ToConsList();
            var output = MyInsert(r, 2, 9);
            Output(output);
            Assert.AreEqual(exp, output.ToEnumerable());
        }

    }
}
