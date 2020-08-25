using System;
using System.Collections.Generic;

namespace SimCorp.Collections.GenericLinkedList
{

    /// <summary>
    /// Generic linked list data structure implementation. 
    /// Uses bi-directional-linked linked list on the background
    /// allowing O(1) operation costs 
    /// for <see cref="Add(string)"/> and <see cref="Remove(TNode)"/> operations.
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the list node. Depending on definition,
    /// can represent either uni- or bi-directional linked list.
    /// </typeparam>
    /// <remarks>
    /// Usage samples:
    /// 
    /// Following creates bi-directional linked list:
    /// var list = new GenericLinkedList.LinkedList<DoublyLinkedListNode>();
    /// 
    /// Following creates uni-directional (forward only) linked list:
    /// var list = new GenericLinkedList.LinkedList<SinglyLinkedListNode>();
    /// </remarks>
    public sealed class LinkedList<TNode>
        where TNode : LinkedListNode<TNode>, new()
    {

        private TNode? _head;
        private TNode? _tail;

        /// <summary>
        /// Adds node with specified <paramref name="value"/> to the end of the list.
        /// Acts as the factory for <typeparamref name="TNode"/>.
        /// </summary>
        /// <remarks>
        /// Operation cost is O(1).
        /// </remarks>
        public TNode Add(string value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }

            var node = new TNode();

            // state init, hacky :-(
            node.Initialize(this, value);

            if (this._head is null && this._tail is null)
            {
                this._head = node;
                this._tail = node;
            }
            else
            {
                if (this._tail is null) { throw new InvalidOperationException(); }

                LinkedList<TNode>.LinkNodes(this._tail, node);
                this._tail = node;
            }

            return node;
        }

        /// <summary>
        /// Removes <paramref name="target"/> node from list.
        /// Throws <see cref="InvalidOperationException"/> if node does not belong to this list.
        /// </summary>
        /// <remarks>
        /// Operation cost is O(1).
        /// </remarks>
        public void Remove(TNode target)
        {
            if (target is null) { throw new ArgumentNullException(nameof(target)); }
            if (!target.BelongsTo(this)) { throw new InvalidOperationException("Node does not belong to this list"); }

            var prev = target.PreviousInternal;
            var next = target.NextInternal;

            LinkedList<TNode>.LinkNodes(prev, next);

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
        /// Traverses given list from head to tail and 
        /// returns its node values as array.
        /// </summary>
        public string[] ToArray()
        {
            var items = new List<string>();

            foreach (var nodeValue in LinkedList<TNode>.Select(this._head, n => n.Value))
            {
                items.Add(nodeValue);
            }

            return items.ToArray();
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

            foreach (var node in LinkedList<TNode>.Select(this._head, n => n))
            {
                if (string.Equals(search, node.Value, StringComparison.Ordinal)) { return node; }
            }

            return null;
        }

        /// <summary>
        /// Iterator, traverses each items in the list starting from <see cref="_head"/>.
        /// </summary>
        private static IEnumerable<T> Select<T>(TNode? head, Func<TNode, T> selector)
        {
            TNode? node = head;

            while (node != null)
            {
                yield return selector(node);
                node = node.NextInternal;
            }
        }

        /// <summary>
        /// Links <paramref name="prev"/> and <paramref name="next"/> nodes.
        /// If any of nodes is null, corresponded property is set to null.
        /// </summary>
        private static void LinkNodes(TNode? prev, TNode? next)
        {
            if (prev != null) { prev.NextInternal = next; }
            if (next != null) { next.PreviousInternal = prev; }
        }

    }

}
