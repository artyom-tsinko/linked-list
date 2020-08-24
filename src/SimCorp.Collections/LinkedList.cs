using System;
using System.Collections.Generic;

namespace SimCorp.Collections
{
    public sealed class LinkedList<TNode>
        where TNode : LinkedListNode<TNode>, new()
    {

        internal TNode Root { get; private set; } = default;

        public TNode Add(string value)
        {
            var node = new TNode();

            // the list was empty, adding new root
            if (this.Root is null)
            {
                node.NextInternal = node;
                node.PrevInternal = node;

                this.Root = node;
            }
            else
            {
                node.NextInternal = this.Root;
                node.PrevInternal = this.Root.PrevInternal;
                this.Root.PrevInternal.NextInternal = node;
                this.Root.PrevInternal = node;
            }

            node.AttachTo(this, value);

            return node;
        }

        public void Remove(TNode node)
        {
            // TODO - removed node is not in the list

            var prev = node.PrevInternal;
            var next = node.NextInternal;

            prev.NextInternal = next;
            next.PrevInternal = prev;

            // if node was a root node - next node should become a new root
            if (object.ReferenceEquals(node, this.Root))
            {
                this.Root = next;
            }

            // if node is still the same root (means there was a single root node in the list)
            // the new root should be null
            if (object.ReferenceEquals(node, this.Root))
            {
                this.Root = null;
            }

            node.RemoveFrom(this);

        }

        public string[] GetValues()
        {
            // TODO - enhance performance
            var items = new List<string>();

            foreach (var nodeValue in LinkedList<TNode>.Select(this.Root, n => n.Value))
            {
                items.Add(nodeValue);
            }

            return items.ToArray();
        }


        public TNode FindNode(string nodeValue, StringComparison comparison = StringComparison.Ordinal)
        {
            return this.FindNode(v => string.Equals(v, nodeValue, comparison));
        }

        public TNode FindNode(Func<string, bool> predicate)
        {
            foreach (var node in LinkedList<TNode>.Select(this.Root, n => n))
            {
                if (predicate(node.Value)) { return node; }
            }

            return null;
        }


        private static IEnumerable<T> Select<T>(TNode root, Func<TNode, T> selector)
        {
            if (root is null) { yield break; };

            var node = root;
            do
            {
                yield return selector(node);
                node = node.NextInternal;
            }
            while (!object.ReferenceEquals(node, root));
        }

    }

}
