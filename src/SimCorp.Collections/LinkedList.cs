using System;
using System.Collections.Generic;

namespace SimCorp.Collections
{

    public sealed class LinkedList<TNode> : ILinkedList<TNode>
        where TNode : LinkedListNode<TNode>, new()
    {

        internal TNode? Root { get; private set; } = default;


        public TNode Add(string? value)
        {
            var node = new TNode();
            
            // the list was empty, adding new root
            if (this.Root is null)
            {
                LinkedListNode<TNode>.AttachRoot(this, node, value);
                this.Root = node;
            }
            else
            {
                // attach node to the end of the list
                LinkedListNode<TNode>.AttachNode(this.Root.PreviousInternal, node, value);
            }

            return node;
        }


        public void Remove(TNode node)
        {
            // TODO - removed node is not in the list

            var next = node.NextInternal;

            // update root node, if necessary
            // if removed node is a root node - next node should become a new root
            if (object.ReferenceEquals(node, this.Root)) 
            {
                // If next node is still a root - there was a single root element...
                this.Root = !object.ReferenceEquals(this.Root, next)
                    ? next
                    // ... and new root should be null.
                    : default;
            }

            // cleanup node refrences and remove node from list
            LinkedListNode<TNode>.RemoveNode(this, node);
        }


        public string?[] ToArray()
        {
            // TODO - enhance performance
            var items = new List<string?>();

            foreach (var nodeValue in LinkedList<TNode>.Select(this.Root, n => n.Value))
            {
                items.Add(nodeValue);
            }

            return items.ToArray();
        }


        public TNode? Find(string search)
        {
            foreach (var node in LinkedList<TNode>.Select(this.Root, n => n))
            {
                if (string.Equals(search, node.Value, StringComparison.Ordinal)) { return node; }
            }

            return null;
        }


        private static IEnumerable<T> Select<T>(TNode? root, Func<TNode, T> selector)
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
