using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Merlin.Concurrent
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    /// <seealso cref="System.Collections.IEnumerable" />
    public class ConcurrentList<T> : IEnumerable<T>, IEnumerable
    {
        private List<T> _list = new List<T>();
        private object _masterLock = new object();

        /// <summary>
        /// Adds an object to end of <see cref="ConcurrentList{T}"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(T item)
        {
            lock (_masterLock)
            {
                _list.Add(item);
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ConcurrentList{T}"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            lock (_masterLock)
            {
                _list.AddRange(collection);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            lock (_masterLock)
            {
                return _list.GetEnumerator();
            }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Remove(T item)
        {
            lock (_masterLock)
            {
                _list.Remove(item);
            }
        }

        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveAt(int index)
        {
            lock (_masterLock)
            {
                _list.RemoveAt(index);
            }
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <param name="match">The match.</param>
        public void RemoveAll(Predicate<T> match)
        {
            lock (_masterLock)
            {
                _list.RemoveAll(match);
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            lock (_masterLock)
            {
                _list.Clear();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (_masterLock)
            {
                return _list.GetEnumerator();
            }
        }
    }
}