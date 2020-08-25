using System;
using System.Collections.Generic;

namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Base implemnetation of the <see cref="ILinkedList{TNode}"/>.
    /// Provides basic functionality to build linked lists
    /// with various navigation schemas based on <typeparamref name="TNode"/>.
    /// </summary>
    public abstract class LinkedList<TNode> : ILinkedList<TNode>
        where TNode : class, ILinkedListNode
    {

        private TNode? _head = default;
        private TNode? _tail = default;

        /// <summary>
        /// Adds node with specified <paramref name="value"/> to the end of the list
        /// </summary>
        /// <remarks>
        /// Operation cost is O(1).
        /// </remarks>
        public TNode Add(string value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }

            var node = this.CreateNode(value);

            if (this._head is null && this._tail is null)
            {
                this._head = node;
                this._tail = node;
            }
            else
            {
                this.LinkNodes(this._tail, node);
                this._tail = node;
            }

            return node;
        }

        /// <summary>
        /// Removes <paramref name="target"/> node from list.
        /// Throws <see cref="InvalidOperationException"/> if node does not belong to this list.
        /// </summary>
        /// <remarks>
        /// Operation cost depends on <see cref="GetPrevious"/> implementation, 
        /// varies from O(1) to O(N).
        /// </remarks>
        public void Remove(TNode target)
        {
            if (target is null) { throw new ArgumentNullException(nameof(target)); }
            if (!target.BelongsTo(this)) { throw new InvalidOperationException("Node does not belong to this list"); }

            var prev = this.GetPrevious(target);
            var next = this.GetNext(target);
            
            this.LinkNodes(prev, next);

            // target was current head
            if (prev is null)
            {
                this._head = next;
            }

            // target was current tail
            if (next is null) 
            {
                this._tail = prev;
            }

            target.Invalidate();
        }

        /// <summary>
        /// Looks for a <see cref="TNode"/> in the list which value equals <paramref name="search"/>.
        /// </summary>
        /// <remarks>
        /// Operation cost is O(N).
        /// </remarks>
        /// <returns>
        /// <see cref="TNode"/> if found, null otherwise.
        /// </returns>
        public TNode? Find(string search) 
        {
            if (search is null) { throw new ArgumentNullException(nameof(search)); }
            return this.Find(node => string.Equals(search, node.Value, StringComparison.Ordinal));
        }

        /// <summary>
        /// Traverses given list from head to tail and 
        /// returns its node values as array.
        /// </summary>
        public string[] ToArray()
        {
            var items = new List<string>();

            foreach (var value in this.Select(n => n.Value))
            {
                items.Add(value);
            }

            return items.ToArray();
        }

        /// <summary>
        /// Creates <typeparamref name="TNode"/> instance, 
        /// acts as a factory method.
        /// </summary>
        protected abstract TNode CreateNode(string value);

        /// <summary>
        /// Links <paramref name="prev"/> and <paramref name="next"/> nodes
        /// based on node navigation scheme.
        /// If any of nodes is null, corresponded property is set to null.
        /// </summary>
        /// <remarks>
        /// For uni-directional navigation scheme <paramref name="next"/>
        /// is set as next of <paramref name="prev"/>.
        /// For bi-directional navigation, corresponded next and prev
        /// properties of both nodes should be set.
        /// </remarks>
        protected abstract void LinkNodes(TNode? prev, TNode? next);

        /// <summary>
        /// Returns node next to <paramref name="current"/>.
        /// </summary>
        /// <remarks>
        /// Operation cost is O(1) to O(N), depending on implementation.
        /// </remarks>
        protected abstract TNode? GetNext(TNode current);

        /// <summary>
        /// Returns node previous to <paramref name="current"/>.
        /// </summary>
        /// <remarks>
        /// Operation cost is O(1) to O(N), depending on implementation.
        /// </remarks>
        protected abstract TNode? GetPrevious(TNode current);

        /// <summary>
        /// Looks for a <see cref="TNode"/> in the list based on <paramref name="predicate"/> condition.
        /// </summary>
        /// <remarks>
        /// Operation cost is O(N).
        /// </remarks>
        /// <returns>
        /// <see cref="TNode"/> if found, null otherwise.
        /// </returns>
        protected TNode? Find(Func<TNode, bool> predicate) 
        {
            if (predicate is null) { throw new ArgumentNullException(nameof(predicate)); }

            foreach (var node in this.Select(n => n))
            {
                if (predicate(node))
                {
                    return node;
                }
            }

            return default;
        }

        private IEnumerable<T> Select<T>(Func<TNode, T> selector)
        {
            TNode? node = this._head;
            while (node != null) 
            { 
                yield return selector(node);
                node = this.GetNext(node);
            }
        }

    }

}
