using System.Xml.Linq;

namespace gen
{
    public class Tree<T>
    {
        private Node<T> root;
        public void Add(T data) // Добавить в дерево новый node
        {
            root = AddNode(root, data);
        }
        private Node<T> AddNode(Node<T> cur, T data)
        {
            if (cur == null)
            {
                Node<T> newNode = new Node<T>();
                newNode.Data = data;
                newNode.Left = null;
                newNode.Right = null;
                return newNode;
            }

            if (Comparer<T>.Default.Compare(cur.Data, data) > 0)
            {
                cur.Left = AddNode(cur.Left, data);
            }
            else
            {
                cur.Right = AddNode(cur.Right, data);
            }

            return cur;
        }
        public void Print(bool direction = false) // Показать дерево
        {
            //direction == true 1234567
            if (direction)
                PrintPr(root);
            else
                PrintRev(root);
            //direction == false 7654321

        }
        private void PrintPr(Node<T> node)
        {
            if (node != null)
            {
                PrintPr(node.Left);
                Console.Write(node.Data + " ");
                PrintPr(node.Right);
            }
        }

        private void PrintRev(Node<T> node)
        {
            if (node != null)
            {
                PrintRev(node.Right);
                Console.Write(node.Data + " ");
                PrintRev(node.Left);
            }
        }
        public bool Contains(T value)
        {
            return ContainsRecursive(root, value);
        }
        private bool ContainsRecursive(Node<T> node, T value)
        {
            if (node == null)
                return false;

            if (node == value)
                return true;

            if (ContainsRecursive(node.Left, value))
                return true;
            if (ContainsRecursive(node.Right, value))
                return true;

            return false;
        }
        private class Node<T>
        {
            public Node<T> Right { get; set; }
            public Node<T> Left { get; set; }
            public T Data { get; set; }

            public static bool operator ==(Node<T> node, T data) => node.Data.Equals(data);
            public static bool operator !=(Node<T> node, T data) => !node.Data.Equals(data);
        }
    }
}
