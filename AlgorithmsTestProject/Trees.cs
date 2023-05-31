namespace AlgorithmsTestProject
{
    // Implements an unsorted immutable binary tree. 
    public class Tree<T> : IBinaryTree<T>
    {
        // This is the constructor
        public Tree(T value, IBinaryTree<T> left, IBinaryTree<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        // This read-only property contains the value associated with the root of the tree.
        public T Value { get; }

        // This property is part of the ITree interface. It is computed on demand.  
        public IEnumerable<ITree<T>> Subtrees
            => new[] { Left, Right };
        
        // This read only property is assigned in construction, and represents the left sub-tree.
        public IBinaryTree<T> Left { get; }
        
        // This read only property is assigned in construction, and represents the right sub-tree.
        public IBinaryTree<T> Right { get; }
    }
}
