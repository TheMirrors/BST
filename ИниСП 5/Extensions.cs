using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ИниСП_5
{
    public static class TreeHelper
    {
        public static void Inorder<T>(Item<T> root)
        {
            if (root != null)
            {
                Inorder(root.Left);
                Console.Write(root.Value + " ");
                Inorder(root.Right);
            }
        }

        public static void Preorder<T>(Item<T> root)
        {
            if (root != null)
            {
                Console.Write(root.Value + " ");
                Preorder(root.Left);
                Preorder(root.Right);
            }
        }

        public static void Postorder<T>(Item<T> root)
        {
            if (root != null)
            {
                Postorder(root.Left);
                Postorder(root.Right);
                Console.Write(root.Value + " ");
            }
        }

        public static void Print<T>(this Tree<T> tree, Action<Item<T>> Act)
        {
            Item<T> value;
            value = tree.Root;
            if (value == null)
                throw new ArgumentNullException();
            Act(value);
            Console.WriteLine();
        }
    }
}
