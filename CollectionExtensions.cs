using System.Collections.Generic;

namespace System.Extensions
{
    public static class CollectionExtensions
    {
        #region ICollection

        /// <summary>
        /// Determines whether the collection is null or empty.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <returns>True if the collection is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<TSource>(this ICollection<TSource> collection)
        {
            return collection == null || collection.Count == 0;
        }

        #endregion

        #region IDictionary

        /// <summary>
        /// Adds a range of key-value pairs to the dictionary.
        /// </summary>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> values)
        {
            foreach (var kvp in values)
            {
                dictionary.TryAdd(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Removes entries from the dictionary based on a predicate and returns the number of removed items.
        /// </summary>
        public static int RemoveWhere<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Predicate<TValue> predicate)
        {
            var keysToRemove = new List<TKey>();

            foreach (var kvp in dictionary)
            {
                if (predicate(kvp.Value))
                {
                    keysToRemove.Add(kvp.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                dictionary.Remove(key);
            }

            return keysToRemove.Count;
        }

        /// <summary>
        /// Increments the integer value associated with a key by a specified amount.
        /// </summary>
        public static int Sum<TKey>(this IDictionary<TKey, int> dictionary, TKey key, int increment = 1)
        {
            if (!dictionary.TryGetValue(key, out int value))
            {
                dictionary.Add(key, increment);
                return increment;
            }

            value += increment;
            dictionary[key] = value;
            return value;
        }

        /// <summary>
        /// Increments the float value associated with a key by a specified amount.
        /// </summary>
        public static float Sum<TKey>(this IDictionary<TKey, float> dictionary, TKey key, float increment = 1)
        {
            if (!dictionary.TryGetValue(key, out float value))
            {
                dictionary.Add(key, increment);
                return increment;
            }

            value += increment;
            dictionary[key] = value;
            return value;
        }

        /// <summary>
        /// Attempts to add a key-value pair to the dictionary.
        /// </summary>
        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                return false;
            }

            dictionary.Add(key, value);
            return true;
        }

        /// <summary>
        /// Updates an existing key-value pair or adds it if the key does not exist.
        /// </summary>
        public static void Update<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Updates or adds a range of key-value pairs to the dictionary.
        /// </summary>
        public static void UpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> values)
        {
            foreach (var kvp in values)
            {
                dictionary.Update(kvp.Key, kvp.Value);
            }
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// Concatenates all elements in the collection into a single string.
        /// </summary>
        public static string Concat<TSource>(this IEnumerable<TSource> collection)
        {
            return string.Concat(collection);
        }

        /// <summary>
        /// Joins all elements in the collection into a single string, separated by the specified separator.
        /// </summary>
        public static string Join<TSource>(this IEnumerable<TSource> collection, string separator)
        {
            return string.Join(separator, collection);
        }

        /// <summary>
        /// Executes the specified action for each element in the collection.
        /// </summary>
        public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// Executes the specified action for each value in the collection of key-value pairs.
        /// </summary>
        public static void ForEach<TSource>(this IEnumerable<KeyValuePair<TSource, TSource>> collection, Action<TSource> action)
        {
            foreach (var pair in collection)
            {
                action(pair.Value);
            }
        }

        /// <summary>
        /// Executes the specified action for each key in the collection of key-value pairs.
        /// </summary>
        public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, Action<TKey> action)
        {
            foreach (var pair in collection)
            {
                action(pair.Key);
            }
        }

        /// <summary>
        /// Executes the specified action for each value in the collection of key-value pairs.
        /// </summary>
        public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, Action<TValue> action)
        {
            foreach (var pair in collection)
            {
                action(pair.Value);
            }
        }

        /// <summary>
        /// Executes the specified action for each key-value pair in the collection.
        /// </summary>
        public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, Action<TKey, TValue> action)
        {
            foreach (var pair in collection)
            {
                action(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Returns the first element in the collection.
        /// </summary>
        public static TSource Peek<TSource>(this IEnumerable<TSource> collection)
        {
            using (var enumerator = collection.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }
        }

        /// <summary>
        /// Determines whether all elements in the collection are true.
        /// </summary>
        public static bool TrueForAll(this IEnumerable<bool> collection)
        {
            foreach (var item in collection)
            {
                if (!item)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region HashSet

        /// <summary>
        /// Adds a range of elements to the hash set.
        /// </summary>
        public static void AddRange<TSource>(this HashSet<TSource> hashSet, IEnumerable<TSource> collection)
        {
            if (collection == null)
            {
                return;
            }

            hashSet.UnionWith(collection);
        }

        /// <summary>
        /// Splits a string by the specified separators and adds the resulting elements to the hash set.
        /// </summary>
        public static void AddRange(this HashSet<string> hashSet, string str, params char[] separators)
        {
            string[] items = str.TrySplit(separators);
            hashSet.AddRange(items);
        }

        #endregion

        #region List

        /// <summary>
        /// Splits a string by the specified separators and adds the resulting elements to the list.
        /// </summary>
        public static void AddRange(this List<string> list, string str, params char[] separators)
        {
            string[] items = str.TrySplit(separators);
            list.AddRange(items);
        }

        /// <summary>
        /// Gets the first element of the list.
        /// </summary>
        public static TSource GetFirst<TSource>(this IList<TSource> list)
        {
            if (list.Count == 0)
            {
                return default;
            }

            return list[0];
        }

        /// <summary>
        /// Gets the last element of the list.
        /// </summary>
        public static TSource GetLast<TSource>(this IList<TSource> list)
        {
            int count = list.Count;

            if (count == 0)
            {
                return default;
            }

            return list[count - 1];
        }

        /// <summary>
        /// Removes the first element from the list.
        /// </summary>
        public static void RemoveFirst<TSource>(this IList<TSource> list)
        {
            if (list.Count == 0)
            {
                return;
            }

            list.RemoveAt(0);
        }

        /// <summary>
        /// Removes the last element from the list.
        /// </summary>
        public static void RemoveLast<TSource>(this IList<TSource> list)
        {
            int count = list.Count;

            if (count == 0)
            {
                return;
            }

            list.RemoveAt(count - 1);
        }

        /// <summary>
        /// Determines whether all elements in the list are true.
        /// </summary>
        public static bool TrueForAll(this List<bool> list)
        {
            return list.TrueForAll(value => value);
        }

        /// <summary>
        /// Attempts to get the value at the specified index in the list.
        /// </summary>
        public static bool TryGetValue<TSource>(this IList<TSource> list, int index, out TSource result)
        {
            result = default;

            if (index < 0 || index >= list.Count)
            {
                return false;
            }

            result = list[index];
            return true;
        }

        #endregion

        #region Queue

        /// <summary>
        /// Attempts to peek at the first element in the queue.
        /// </summary>
        public static TSource TryPeek<TSource>(this Queue<TSource> queue)
        {
            if (queue.Count == 0)
            {
                return default;
            }

            return queue.Peek();
        }

        /// <summary>
        /// Attempts to dequeue the first element from the queue.
        /// </summary>
        public static TSource TryDequeue<TSource>(this Queue<TSource> queue)
        {
            if (queue.Count == 0)
            {
                return default;
            }

            return queue.Dequeue();
        }

        #endregion

        #region Stack

        /// <summary>
        /// Attempts to peek at the top element in the stack.
        /// </summary>
        public static TSource TryPeek<TSource>(this Stack<TSource> stack)
        {
            if (stack.Count == 0)
            {
                return default;
            }

            return stack.Peek();
        }

        /// <summary>
        /// Attempts to pop the top element from the stack.
        /// </summary>
        public static TSource TryPop<TSource>(this Stack<TSource> stack)
        {
            if (stack.Count == 0)
            {
                return default;
            }

            return stack.Pop();
        }

        #endregion
    }
}
