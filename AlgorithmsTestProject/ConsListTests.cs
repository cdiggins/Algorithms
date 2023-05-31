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

        [Test]
        public static void MyTestConcat()
        {
            var xs = new[] { 1, 2, 3 };
            Output(xs.ToConsList());
            var ys = new[] { 4, 5 };
            Output(ys.ToConsList());
            var zs = MyConcat(xs.ToConsList(), ys.ToConsList());
            Output(zs);
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

    }
}
