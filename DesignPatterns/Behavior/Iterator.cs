using System;

namespace DesignPatterns.Behavior
{
    // 迭代器抽象类
    public interface ITerator
    {
        bool MoveNext();
        Object GetCurrent();
        void Next();
        void Reset();
    }

    // 抽象聚合类
    public interface ICollection
    {
        ITerator GetIterator();
    }

    // 具体聚合类
    public class Collection : ICollection
    {
        readonly int[] _collection;
        public Collection()
        {
            _collection = new [] { 2, 4, 6, 8 };
        }

        public ITerator GetIterator()
        {
            return new Iterator(this);
        }

        public int Length => _collection.Length;

        public int GetElement(int index)
        {
            return _collection[index];
        }
    }

    // 具体迭代器类
    public class Iterator : ITerator
    {
        private readonly Collection _list;
        private int _index;

        public Iterator(Collection list)
        {
            _list = list;
            _index = 0;
        }


        public bool MoveNext()
        {
            return _index < _list.Length;
        }

        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }
    }
}