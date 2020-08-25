using System;
using System.Collections.Generic;

namespace SimCorp.Collections.ClassicLinkedList
{


    public abstract class LinkedList<TNode> : ILinkedList<TNode>
        where TNode : class, ILinkedListNode
    {

        // TODO - turn into properties
        protected TNode? _head;
        protected TNode? _tail;

        public TNode Add(string value)
        {
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


        public void Remove(TNode target)
        {
            if (!target.BelongsTo(this)) { throw new InvalidOperationException(); }

            var prev = this.GetPrevious(target);

            if (prev is null) { throw new InvalidOperationException(); }

            this.LinkNodes(prev, this.GetNext(target));
            target.Invalidate();
        }


        public TNode? Find(string value) 
        {
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
