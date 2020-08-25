using System;
using System.Collections.Generic;

namespace SimCorp.Collections.ClassicLinkedList
{


    public abstract class LinkedList<TNode> : ILinkedList<TNode>
        where TNode : class, ILinkedListNode
    {

        private TNode? _head = default;
        private TNode? _tail = default;

        /// <summary>
        /// The cost is O(1)
        /// </summary>
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
        /// The cost depends on <see cref="GetPrevious"/> implementation, varies from O(1) to O(N)
        /// </summary>
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
        /// The cost is O(N)
        /// </summary>
        public TNode? Find(string value) 
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }
            return this.Find(node => string.Equals(value, node.Value, StringComparison.Ordinal));
        }


        public string[] ToArray()
        {
            var items = new List<string>();

            foreach (var value in this.Select(n => n.Value))
            {
                items.Add(value);
            }

            return items.ToArray();
        }


        protected abstract TNode CreateNode(string value);
        protected abstract void LinkNodes(TNode? prev, TNode? next);
        protected abstract TNode? GetNext(TNode current);
        protected abstract TNode? GetPrevious(TNode current);


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
