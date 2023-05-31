using System.ComponentModel.DataAnnotations;

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

    public static IBinaryTree<T> ReplaceElement<T>(this IBinaryTree<T> root,
        IBinaryTree<T> source,
        IBinaryTree<T> target)
    {
        if (root == null)
            return null;
        if (root == source)
            return target;
        return new BinaryTree<T>(
            root.Value,
            root.Left.ReplaceElement(source, target),
            root.Right.ReplaceElement(source, target));
    }

    public static IBinaryTree<T> Map<T>(this IBinaryTree<T> root, Func<T, T> transform)
    {
        if (root == null)
            return null;
        return new BinaryTree<T>(
            transform(root.Value),
            root.Left.Map(transform),
            root.Right.Map(transform));
    }

    public static IBinaryTree<T> Filter<T>(this IBinaryTree<T> root, Func<T, bool> predicate)
    {
        if (root == null)
            return null;
        if (predicate(root.Value))
            return new BinaryTree<T>(
                root.Value,
                root.Left.Filter(predicate),
                root.Right.Filter(predicate));

        var next = root.Right;
        
        return new BinaryTree<T>(
                root.Value,
                root.Left.Filter(predicate),
                root.Right.Filter(predicate));
    }

    public static IBinaryTree<T> GetNextNode<T>(this IBinaryTree<T> root)
    {

    }

    public static bool IsLeftChild<T>(this IBinaryTree<T> root)
    {
    }

    public static IBinaryTree<T> GetLeftmostNode<T>(this IBinaryTree<T> root)
    {
        if (root?.Left == null)
            return root;
        return root.Left.GetLeftmostNode();
    }

    public static IBinaryTree<T> GetRightmostNode<T>(this IBinaryTree<T> root)
    {
        if (root?.Right == null)
            return root;
        return root.Right.GetRightmostNode();
    }

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