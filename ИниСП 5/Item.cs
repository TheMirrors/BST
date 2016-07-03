using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ИниСП_5
{
    public class Item<T>
    {
        public T Value { get; set; }
        public int Key { get; set; }
        public Item<T> Left { get; set; }
        public Item<T> Right { get; set; }

        public static implicit operator Item<T>(T value)
        {
            return new Item<T> { Value = value };
        }

        public static explicit operator T(Item<T> item)
        {
            return item.Value;
        } 

    }
}
