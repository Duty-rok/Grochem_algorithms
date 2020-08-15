using System;
using System.Collections;
using System.Collections.Generic;

namespace greedy_algorithm
{
    class Plenty<T>:IEnumerable
    {
        protected List<T> _items = new List<T>();
        public Plenty() { }

        public Plenty(params T[] massive)
        {
            foreach (T obj in massive)
                if (!_items.Contains(obj))
                    _items.Add(obj);
        }
        public int Count => _items.Count;
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        public static Plenty<T> operator +(Plenty<T> plnt1, Plenty<T> plnt2)
        {
            Plenty<T> rezult = new Plenty<T>();
            foreach (T obj in plnt1._items)
                if (!rezult._items.Contains(obj))
                    rezult._items.Add(obj);
            foreach (T obj in plnt2._items)
                if (!rezult._items.Contains(obj))
                    rezult._items.Add(obj);
            return rezult;
        }
        public static Plenty<T> operator *(Plenty<T> plnt1, Plenty<T> plnt2)
        {
            Plenty<T> rezult = new Plenty<T>();
            foreach (T obj in plnt1._items)
                if (plnt2._items.Contains(obj))
                    rezult._items.Add(obj);
            return rezult;
        }
        public static Plenty<T> operator -(Plenty<T> plnt1, Plenty<T> plnt2)
        {
            Plenty<T> rezult = new Plenty<T>();
            foreach (T obj in plnt1._items)
                if (!plnt2._items.Contains(obj))
                    rezult._items.Add(obj);
            return rezult;
        }
        public void Add(params T[] massive)
        {
            foreach (T obj in massive)
                if (!_items.Contains(obj))
                    _items.Add(obj);
        }
        public void Add(T obj)
        {
            if (!_items.Contains(obj))
                _items.Add(obj);
        }
        public void Remove(T obj)
        {
            if (!_items.Contains(obj))
                throw new Exception($"PlentyNotHaveObject {obj}");
            _items.Remove(obj);
        }
        public void Remove(params T[] massive)
        {
            foreach (T obj in massive)
                if (!_items.Contains(obj))
                    throw new Exception($"PlentyNotHaveObject {obj}");
                else
                    _items.Remove(obj);
        }
    }
}
