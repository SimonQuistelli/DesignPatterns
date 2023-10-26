using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Iterator
{
    class IteratorTest
    {
        public static void TestIteratorDP()
        {
            Collection collection = new Collection();
            collection[0] = new Item("A");
            collection[1] = new Item("B");
            collection[2] = new Item("C");
            collection[3] = new Item("D");

            Iterator iterator = collection.CreateIterator();

            Item item = iterator.First();

            Console.WriteLine("Iterator First {0}", item.Name);

            item = iterator.Next();

            while (item != null)
            {
                Console.WriteLine("Iterator Next {0}", item.Name);
                item = iterator.Next();
            }
        }
    }

    public class Item
    {
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
        }
    }

    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    public class Collection : IAbstractCollection
    {
        private List<Item> _items;

        public Collection()
        {
            _items = new List<Item>();
        }
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count()
        {
            return _items.Count;
        }

        public Item this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }

    public interface IAbstractIterator
    {
        bool IsDone { get; }
        Item First();
        Item Next();
        Item Current();
    }

    public class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current;

        public bool IsDone
        {
            get { return (_current >= _collection.Count()) ? true : false; }
        }

        public Iterator(Collection collection)
        {
            _current = 0;
            _collection = collection;
        }
        public Item Current()
        {
            return _collection[_current];
        }

        public Item First()
        {
            _current = 0;
            return _collection[_current];
        }

        public Item Next()
        {
            _current++;

            if (!IsDone)
            {
                return _collection[_current];
            }
            else
            {
                return null;
            }
        }
    }
}
