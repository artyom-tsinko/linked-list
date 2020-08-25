using System;

namespace SimCorp.Collections.GenericLinkedList
{

    public abstract class LinkedListNode<TNode>
        where TNode : LinkedListNode<TNode>, new()
    {

        private LinkedList<TNode>? _container = default;
        private TNode? _prev = default;
        private TNode? _next = default;
        private string? _value = default;

        public string Value
        { 
            get => this._value is null ? throw new InvalidOperationException() : this._value;
        }


        // Prevents uncontrolled creation of other node types
        // TODO - make internal
        internal LinkedListNode() { }


        internal TNode PreviousInternal 
        {
            get => this._prev is null ? throw new InvalidOperationException() : this._prev;
        }


        internal TNode NextInternal
        {
            get => this._next is null ? throw new InvalidOperationException() : this._next;
        }


        internal static void AttachRoot(LinkedList<TNode> container, TNode root, string value)
        {
            if (container is null) { throw new ArgumentNullException(); }

            root._next = root;
            root._prev = root;
            root._container = container;
            root._value = value;
        }


        internal static void AttachNode(TNode prev, TNode target, string value)
        {
            if (prev._container is null) { throw new InvalidOperationException(); }

            var next = prev.NextInternal;

            prev._next = target;
            next._prev = target;

            target._next = next;
            target._prev = prev;
            target._container = prev._container;

            target._value = value;
        }


        internal static void RemoveNode(LinkedList<TNode> container, TNode target)
        {
            if (!object.ReferenceEquals(container, target._container)) { throw new InvalidOperationException(); }
            if (target._container is null) { throw new InvalidOperationException(); }

            var prev = target.PreviousInternal;
            var next = target.NextInternal;

            prev._next = next;
            next._prev = prev;

            target._next = null;
            target._prev = null;
            target._container = null;
            target._value = null;
        }


        protected bool IsRoot() 
        {
            if (this._container is null) { throw new InvalidOperationException(); }

            return object.ReferenceEquals(this._container.Root, this);
        }

    }

}
