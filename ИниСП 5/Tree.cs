using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ИниСП_5
{
    public class Tree<T>
    {
        public Item<T> Root { get; set; }

        public void Insert(Item<T> inf)
        {
            Item<T> current = Root;
            Item<T> parrent = null;

            while (current != null)
            {
                parrent = current;
                if (inf.Key < current.Key)
                    current = current.Left;
                else current = current.Right;
            }
            if (parrent == null)
                Root = inf;
            else if (inf.Key < parrent.Key)
                parrent.Left = inf;
            else parrent.Right = inf;
        }
        public Item<T> Find(int key)
        {
            Item<T> current;
            current = Root;
            while ((current != null) && (current.Key != key))
            {
                if (key < current.Key)
                    current = current.Left;
                else
                    current = current.Right;
            }
            if (current != null)
            {
                return current;
            }
            throw new ArgumentNullException();
        }

        public void Remove(int key)
        {
            Item<T> p;
            Item<T> q = new Item<T>();
            p = Root;
            while ((p != null) && (p.Key != key))
            {
                q = p;
                if (key < p.Key)
                    p = p.Left;
                else
                    p = p.Right;
            }
            if (p != null)
            {
                if (p == Root)
                    q.Left = p;
                if ((p.Left == null) && (p.Right == null))
                    if (q.Left == p)
                        q.Left = null;
                    else
                        q.Right = null;
                else
                    if (p.Left == null)
                        if (q.Left == p)
                            q.Left = p.Right;
                        else
                            q.Right = p.Right;
                    else
                    {
                        Item<T> w;
                        w = p.Left;
                        if (w.Right == null)
                            w.Right = p.Right;
                        else
                        {
                            Item<T> v;
                            do
                            {
                                v = w;
                                w = w.Right;
                            }
                            while (w.Right != null);
                            v.Right = w.Left;
                            w.Left = p.Left;
                            w.Right = p.Right;
                        }
                        if (q.Left == p)
                            q.Left = w;
                        else
                            q.Right = w;
                    }
                if (p == Root)
                    Root = q.Left;
            }
        }
    } 
}
