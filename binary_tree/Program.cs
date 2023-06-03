// Сортировка массива с помощью бинарного дерева

namespace PlantBinaryTree
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node insert(Node root, int v)
        /*Вставка значения в дерево*/
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }

        public void show(Node root)
        /* Обход дерева в глубину с выводом значений*/
        {
            if (root == null)
            {
                return;
            }

            show(root.left);
            Console.Write($"{root.value} ");
            show(root.right);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree tree = new Tree();
            int SIZE = 20;
            int[] a = new int[SIZE];

            // Сгенерируем массив чисел для заполнения

            Random random = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                a[i] = random.Next(100);
            }

            Console.Write("Сгенерированные значения:  ");
            foreach (int value in a)
            {
                Console.Write($"{value} ");
            }

            Console.WriteLine();

            // Заполним бинарное дерево значениями

            for (int i = 0; i < SIZE; i++)
            {
                root = tree.insert(root, a[i]);
            }

            // Выведем бинарное дерево обходом в глубину
            Console.Write("Значения бинарного дерева: ");

            tree.show(root);

        }
    }
}