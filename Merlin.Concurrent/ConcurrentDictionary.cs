using System.Collections.Generic;
using System.Linq;

namespace Merlin.Concurrent
{
    /// <summary>
    /// Represents a thread-safe collection of keys and values
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <remarks>
    /// All public and protected members of <see cref="ConcurrentDictionary{TKey,TValue}"/> are thread-safe and may be used
    /// concurrently from multiple threads.
    /// </remarks>
    public class ConcurrentDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
        private object _masterLock = new object();

        /// <summary>
        /// Gets or sets the <see cref="TValue"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="TValue"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns>The value.</returns>
        public TValue this[TKey key]
        {
            get
            {
                lock (_masterLock)
                {
                    return _dictionary[key];
                }
            }
            set
            {
                lock (_masterLock)
                {
                    _dictionary[key] = value;
                }
            }
        }

        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(TKey key)
        {
            lock (_masterLock)
            {
                return _dictionary.ContainsKey(key);
            }
        }

        /// <summary>
        /// Determines whether the specified key contains value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key contains value; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsValue(TValue key)
        {
            lock (_masterLock)
            {
                return _dictionary.ContainsValue(key);
            }
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            lock (_masterLock)
            {
                return _dictionary.Remove(key);
            }
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public TKey[] Keys
        {
            get
            {
                lock (_masterLock)
                {
                    return _dictionary.Keys.ToArray();
                }
            }
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public TValue[] Values
        {
            get
            {
                lock (_masterLock)
                {
                    return _dictionary.Values.ToArray();
                }
            }
        }
    }
}