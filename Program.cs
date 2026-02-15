namespace _08._02._2026DZ
{
        public class Tree<T> where T : IComparable<T>
        {
            private class Node
            {
                public T Value { get; set; }
                public Node Left { get; set; }
                public Node Right { get; set; }
                public Node(T value)
                {
                    Value = value;
                    Left = null;
                    Right = null;
                }
            }
            private Node root;
            public Tree()
            {
                root = null;
            }
            public void Add(T data)
            {
                if (root == null)
                {
                    root = new Node(data);
                    return;
                }
                Node current = root;
                while (true)
                {
                    int cmp = current.Value.CompareTo(data);
                    if (cmp == 0) return; 

                    if (cmp > 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new Node(data);
                            return;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node(data);
                            return;
                        }
                        current = current.Right;
                    }
                }
            }
            public void AddRecursive(T data)
            {
                root = InsertRecursive(root, data);
            }
            private Node InsertRecursive(Node node, T data)
            {
                if (node == null)
                    return new Node(data);
                int cmp = node.Value.CompareTo(data);

                if (cmp == 0)
                    return node;  

                if (cmp > 0)
                    node.Left = InsertRecursive(node.Left, data);
                else
                    node.Right = InsertRecursive(node.Right, data);

                return node;
            }
            public bool Search(T data)
            {
                Node current = root;
                while (current != null)
                {
                    int cmp = current.Value.CompareTo(data);
                    if (cmp == 0)
                        return true;
                    if (cmp > 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
                return false;
            }
            public void PrintAscending()
            {
                PrintInOrder(root);
                Console.WriteLine();
            }
            private void PrintInOrder(Node node)
            {
                if (node == null) return;
                PrintInOrder(node.Left);
                Console.Write(node.Value + " ");
                PrintInOrder(node.Right);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Tree<int> tree = new Tree<int>();
                tree.Add(8);
                tree.Add(3);
                tree.Add(10);
                tree.Add(1);
                tree.Add(6);
                tree.AddRecursive(14);  
                tree.AddRecursive(4);
                Console.WriteLine("Дерево за зростанням:");
                tree.PrintAscending();
                Console.WriteLine("\nПошук елементів:");
                Console.WriteLine("Є 6?   " + tree.Search(6));
                Console.WriteLine("Є 7?   " + tree.Search(7));
                Console.WriteLine("Є 10?  " + tree.Search(10));
                Console.WriteLine("Є 999? " + tree.Search(999));
            }
        }
}