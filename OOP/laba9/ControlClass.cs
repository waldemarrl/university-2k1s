using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Linq;

namespace laba9
{
    interface IOrderedDictionary<Tkey, TValue>
    {
        void Add(Tkey key, TValue value);
        void Remove(Tkey key);
    }

    class ConcurrentBag<TKey, TValue> : IOrderedDictionary<TKey, TValue>
    {
        private Data[] _data;
        private int _count;
        private int _index;
        public ConcurrentBag(int _count)
        {
            _data = new Data[_count];
            _index = -1;
        }
        public void Add(TKey key, TValue value)
        {
            if (_index == _data.Length - 1)
            {
                throw new Exception("List is full");
            }
            _data[++_index] = new Data(key, value);
        }
        public void Remove(TKey key)
        {
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i].Key.Equals(key))
                {
                    for (int j = i; j < _data.Length - 1; j++)
                    {
                        _data[j] = _data[j + 1];
                    }
                    _index--;
                    return;
                }
            }
            throw new Exception("Key not found");
        }
        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    if (_data[i].Key.Equals(key))
                    {
                        return _data[i].Value;
                    }
                }
                throw new Exception("Key not found");
            }
            set
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    if (_data[i].Key.Equals(key))
                    {
                        _data[i].Value = value;
                        return;
                    }
                }
                throw new Exception("Key not found");
            }
        }
        class Data
        { 
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Data(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
            public override string ToString() => $"Key: {Key}, Value: {Value}";
        }
    }
}
