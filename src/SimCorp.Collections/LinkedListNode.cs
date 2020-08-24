using System;

namespace SimCorp.Collections
{

    public abstract class LinkedListNode<TNode> : IListNode
        where TNode : LinkedListNode<TNode>, new()
    {

        private LinkedList<TNode>? _container = default;
        private TNode? _prev = default;
        private TNode? _next = default;


        public string? Value { get; private set; }


        // Prevents uncontrolled creation of other node types
        internal LinkedListNode() { }


        internal TNode PreviousInternal 
        {
            get => this._prev is null ? throw new InvalidOperationException() : this._prev;
        }


        internal TNode NextInternal
        {
            get => this._next is null ? throw new InvalidOperationException() : this._next;
        }


        internal static void AttachRoot(LinkedList<TNode> container, TNode root, string? value)
        {
            if (container is null) { throw new ArgumentNullException(); }

            root._next = root;
            root._prev = root;
            root._container = container;
            root.Value = value;
        }


        internal static void AttachNode(TNode left, TNode target, string? value)
        {
            if (left._container is null) { throw new InvalidOperationException(); }

            var right = left.NextInternal;

            left._next = target;
            right._prev = target;

            target._next = right;
            target._prev = left;
            target._container = left._container;

            target.Value = value;
        }


        internal static void RemoveNode(LinkedList<TNode> container, TNode target)
        {
            if (!object.ReferenceEquals(container, target._container)) { throw new InvalidOperationException(); }
            if (target._container is null) { throw new InvalidOperationException(); }

            var left = target.PreviousInternal;
            var right = target.NextInternal;

            left._next = right;
            right._prev = left;

            target._next = null;
            target._prev = null;
            target._container = null;
        }


        protected bool IsRoot() 
        {
            if (this._container is null) { throw new InvalidOperationException(); }

            return Object.ReferenceEquals(this._container.Root, this);
        }

    }

}
