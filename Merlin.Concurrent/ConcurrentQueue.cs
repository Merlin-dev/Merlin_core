using System.Collections.Generic;
using System.Linq;

namespace Merlin.Concurrent
{
    /// <summary>
    /// Represents a thread-safe queue of items.
    /// </summary>
    /// <typeparam name="T">The type of item.</typeparam>
    /// <remarks>
    /// All public and protected members of <see cref="ConcurrentList{T}"/> are thread-safe and may be used
    /// concurrently from multiple threads.
    /// </remarks>
    public class ConcurrentQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();
        private object _masterLock = new object();

        /// <summary>
        /// Determines wheter a sequence contains any elements.
        /// </summary>
        public bool Any()
        {
            lock (_masterLock)
            {
                return _queue.Any();
            }
        }

        /// <summary>
        /// Adds an object to the end of <see cref="ConcurrentQueue{T}"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            lock (_masterLock)
            {
                _queue.Enqueue(item);
            }
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="ConcurrentQueue{T}"/> without removing it.
        /// </summary>
        public T Peek()
        {
            lock (_masterLock)
            {
                return _queue.Peek();
            }
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="ConcurrentQueue{T}"/>.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            lock (_masterLock)
            {
                return _queue.Dequeue();
            }
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ConcurrentQueue{T}"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if contains the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T item)
        {
            lock (_masterLock)
            {
                return _queue.Contains(item);
            }
        }
    }
}