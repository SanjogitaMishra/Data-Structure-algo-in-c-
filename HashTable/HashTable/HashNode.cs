using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class HashNode<K, V>
    {
        private K key;
        private V value;
        private HashNode<K, V> next;

        public HashNode(K key, V value)
        {
            this.Key = key;
            this.value = value;
            this.Next = null;
        }

        // properties
        public K Key { get => key; set => key = value; }
        public V Value { get => this.value; set => this.value = value; }
        public HashNode<K, V> Next { get => next; set => next = value; }

    }
}
