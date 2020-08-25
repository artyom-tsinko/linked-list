using System;

namespace SimCorp.Collections.GenericLinkedList
{

    /// <summary>
    /// Represents node for <see cref="LinkedList{TNode}"/>.
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the list node. Depending on definition,
    /// can represent either uni- or bi-directional linked list.
    /// </typeparam>
    public abstract class LinkedListNode<TNode>
        where TNode : LinkedListNode<TNode>
    {

        private object? _container = default;
        private TNode? _prev = default;
        private TNode? _next = default;
        private string? _value;

        /// <summary>
        /// The value of the node. Throws <see cref="InvalidOperationException"/>
        /// if node is detached (removed) from the list.
        /// </summary>
        public string Value
        { 
            get { ThrowIfInvalidated(); if (this._value is null) { throw new InvalidOperationException("Inconsistent state"); } return this._value; }
        }

        internal TNode? PreviousInternal
        {
            get { this.ThrowIfInvalidated(); return this._prev; }
            set { this.ThrowIfInvalidated(); this._prev = value; }
        }

        internal TNode? NextInternal
        {
            get { this.ThrowIfInvalidated(); return this._next; }
            set { this.ThrowIfInvalidated(); this._next = value; }
        }

        /// <summary>
        /// Prevents uncontrolled creation of other node types.
        /// </summary>
        internal LinkedListNode() {}

        /// <summary>
        /// Invalidates node, detaches it from container.
        /// No further operations are possible on this node after invalidation.
        /// </summary>
        internal void Initialize(object container, string value)
        {
            this._container = container;
            this._value = value;
        }

        /// <summary>
        /// Invalidates node, detaches it from container.
        /// No further operations are possible on this node after invalidation.
        /// </summary>
        internal void Invalidate()
        {
            this._container = null;
            this._next = null;
            this._prev = null;
        }

        /// <summary>
        /// Detects whether node belongs (is attached to) <paramref name="targetContainer"/>.
        /// </summary>
        internal bool BelongsTo(object targetContainer)
        {
            if (targetContainer is null) { throw new ArgumentNullException(nameof(targetContainer)); }
            this.ThrowIfInvalidated();

            return object.ReferenceEquals(this._container, targetContainer);
        }

        private void ThrowIfInvalidated()
        {
            if (this._container is null) { throw new InvalidOperationException("Node is invalidated"); }
        }

    }

}
