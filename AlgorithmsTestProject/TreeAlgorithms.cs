namespace AlgorithmsTestProject;

public static class TreeAlgorithms
{
    public static IBinaryTree<T> CreateTree<T>(this T value, IBinaryTree<T> left, IBinaryTree<T> right)
        => new BinaryTree<T>(value, left, right);

    public static IBinaryTree<T> LeftRotation<T>(this IBinaryTree<T> tree)
        => CreateTree(
            tree.Right.Value,
            CreateTree(
                tree.Value,
                tree.Left, 
                tree.Right.Left),
            tree.Right.Right);

    public static IBinaryTree<T> RightRotation<T>(this IBinaryTree<T> tree)
        => CreateTree(
            tree.Left.Value,
            tree.Left.Left,
            CreateTree(
                tree.Value,
                tree.Left.Right,
                tree.Right));

    /*
    public static IEnumerable<T> BreadthFirstSearch<T>(
        T root,
        Func<T, IEnumerable<T>> getChildren)
    {
        var q = new LinkedListQueue<T>();
        q.Enqueue(root);
        while (!q.IsEmpty)
        {
            var current = q.Dequeue();
            yield return current;
            foreach (var child in getChildren(current))
                q.Enqueue(child);
        }
    }

    public static IEnumerable<T> DepthFirstSearch<T>(
        T root,
        Func<T, IEnumerable<T>> getChildren)
    {
        var s = new Stack<T>();
        s.Push(root);
        while (!s.IsEmpty)
        {
            var current = s.Pop();
            foreach (var child in getChildren(current))
                s.Push(child);
            yield return current;
        }
    }
    */
}