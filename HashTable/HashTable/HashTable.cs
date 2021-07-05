using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class HashTable<K, V>
    {
        // bucketArray is used to store of HashNode in chains
        private List<HashNode<K, V>> bucketArray;
        // Current capacity of array list
        private int numberOfBuckets;
        // Current size of array list
        private int size;

        public HashTable()
        {
            bucketArray = new List<HashNode<K, V>>();
            numberOfBuckets = 10;
            size = 0;

            // Create empty chains
            for (int i = 0; i < numberOfBuckets; i++)
                bucketArray.Add(null);
        }

        // return the current size of hashtable
        public int Size() { return size; }
        public bool IsEmpty() { return Size() == 0; }

        private int GetBucketIndex(K key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % numberOfBuckets;
            // key.GetHashCode() coule be negative.
            index = index < 0 ? index * -1 : index;
            return index;
        }

        // Adds a key value pair to hash
        public void Insert(K key, V value)
        {
            // Find head of chain for given key
            int bucketIndex = GetBucketIndex(key);
            HashNode<K, V> head = bucketArray[bucketIndex];

            // Check if key is already present
            while (head != null)
            {
                if (head.Key.Equals(key))
                {
                    head.Value = value;
                    return;
                }
                head = head.Next;
            }


            head = bucketArray[bucketIndex];
            HashNode<K, V> newNode = new HashNode<K, V>(key, value);
            newNode.Next = head;
            bucketArray.Insert(bucketIndex, newNode);
            // Insert key in chain
            size++;

            // If load factor goes beyond threshold, then
            // double hash table size
            if ((1.0 * size) / numberOfBuckets >= 0.7)
            {
                List<HashNode<K, V>> temprory = bucketArray;
                bucketArray = new List<HashNode<K, V>>();
                numberOfBuckets = 2 * numberOfBuckets;
                size = 0;
                for (int i = 0; i < numberOfBuckets; i++)
                    bucketArray.Add(null);

                foreach (HashNode<K, V> headNode in temprory)
                {
                    HashNode<K, V> tempHead = headNode;
                    while (tempHead != null)
                    {
                        Insert(tempHead.Key, tempHead.Value);
                        tempHead = tempHead.Next;
                    }
                }
            }

        }

        // Method to remove a given key
        public V Delete(K key)
        {
            V value = default(V);
            // Apply hash function to find index for given key
            int bucketIndex = GetBucketIndex(key);

            // Get head of chain
            HashNode<K, V> headNode = bucketArray[bucketIndex];
            // Search for key in its chain
            HashNode<K, V> previousNode = null;

            // check for very first Node
            if (headNode != null && headNode.Key.Equals(key))
            {
                bucketArray[bucketIndex] = headNode.Next;
                value = headNode.Value;
                size--;
                return value;
            }

            // check if index is empty the nothing deleted and returns default
            if (headNode == null)
                return value;

            previousNode = headNode;
            headNode = headNode.Next;

            // loop through all Nodes and check keys than remove it and returns value of deleted key
            while (headNode != null)
            {
                if (headNode.Key.Equals(key))
                {
                    value = headNode.Value;
                    previousNode.Next = headNode.Next;
                    size--;
                    break;
                }

                previousNode = headNode;
                headNode = headNode.Next;
            }

            return value;
        }
        // return true for a given value if found in hashtable
        public bool Contains(V value)
        {
            bool flag = false;
            // traversing hashtable
            foreach (HashNode<K, V> headNode in bucketArray)
            {
                // traversing HashNodes on currentIndex of hashtable
                HashNode<K, V> tempHead = headNode;
                while (tempHead != null)
                {
                    if (tempHead.Value.Equals(value))
                    {
                        flag = true;
                        return flag;
                    }
                    tempHead = tempHead.Next;
                }
            }

            return flag;
        }
        // Returns value for a key
        public V GetValue(K key)
        {
            // Find head of chain for given key
            int bucketIndex = GetBucketIndex(key);
            HashNode<K, V> head = bucketArray[bucketIndex];

            // Search key in chain
            while (head != null)
            {
                if (head.Key.Equals(key))
                    return head.Value;
                head = head.Next;
            }

            // If key not found
            return default(V);// Returns value for a key

        }

        // returns key-value pair one by one from hashtable 
        public IEnumerable<KeyValuePair<K, V>> Iterator()
        {
            // traversing hashtable
            foreach (HashNode<K, V> headNode in bucketArray)
            {
                // traversing HashNodes on currentIndex of hashtable
                HashNode<K, V> tempHead = headNode;
                while (tempHead != null)
                {
                    yield return new KeyValuePair<K, V>(tempHead.Key, tempHead.Value);
                    tempHead = tempHead.Next;
                }
            }
        }
        // print all the key value pair present in hashtable
        public void Traverse()
        {
            Console.WriteLine("\tKey\tValue");
            foreach (var item in Iterator())
            {
                Console.WriteLine("\t" + item.Key + "\t" + item.Value);
            }
        }
    }
}
