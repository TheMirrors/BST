using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ИниСП_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var _tree = new Tree<string>();
            Action<Item<string>> Act;
            Console.WriteLine("| 1 - Insert   |\n| 2 - Traverse |\n| 3 - Find     |\n| 4 - Remove   |\n| 0 - Exit     |");
            for (; ; )
            {
                Console.Write("----------------\nOperation : ");
                string sel = Console.ReadLine();
                string _key;
                int _Key;
                var _inf = new Item<string>();
                switch (sel)
                {
                    case "1":
                        Console.Write("String = ");
                        _inf.Value = Console.ReadLine();
                        Console.Write("Key = ");
                        _key = Console.ReadLine();
                        _inf.Key = int.Parse(_key);
                        _tree.Insert(_inf);
                        continue;
                    case "2":
                        try
                        {
                            Console.Write("1 -- Inorder\n2 -- Preorder\n3 -- Postorder\n4 -- Root Value\n");
                            Console.Write("Choose number: ");
                            sel = Console.ReadLine();
                            switch (sel)
                            {
                                case "1":
                                    Act = TreeHelper.Inorder;
                                    break;
                                case "2":
                                    Act = TreeHelper.Preorder;
                                    break;
                                case "3":
                                    Act = TreeHelper.Postorder;
                                    break;
                                case "4":
                                    Act = t => { t = _tree.Root; Console.Write("Tree.Root = {0}", t.Value); };
                                    break;
                                default:
                                    Console.WriteLine("Wrong number, try again");
                                    continue;
                            }
                            _tree.Print(Act);
                            continue;
                        }
                        catch
                        {
                            Console.WriteLine("Tree is empty");
                            continue;
                        }
                    case "3":
                        try
                        {
                            Console.Write("Key = ");
                            _key = Console.ReadLine();
                            _Key = int.Parse(_key);
                            _inf = _tree.Find(_Key);
                            if (_inf != null)
                                Console.WriteLine("Str = {0}, Key = {1}", _inf.Value, _inf.Key);
                            else
                                Console.WriteLine("Nothing found");
                            continue;
                        }
                        catch
                        {
                            Console.WriteLine("Nothing found");
                            continue;
                        }
                    case "4":
                        Console.Write("Key = ");
                        _key = Console.ReadLine();
                        _Key = int.Parse(_key);
                        _tree.Remove(_Key);
                        continue;
                    case "0":   
                        Environment.Exit(0);
                        continue;
                    default:
                        Console.WriteLine("Choose smth...");
                        break;
                }
            }
        }
    }
}
