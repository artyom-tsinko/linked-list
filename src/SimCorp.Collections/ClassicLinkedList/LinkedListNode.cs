using System;

namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Represents node for <see cref="LinkedList{TNode}"/>.
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the list node. Depending on definition,
    /// can represent either uni- or bi-directional linked list.
    /// </typeparam>
    internal abstract class LinkedListNode : ILinkedListNode
    {

        private object? _container;
        private readonly string _value;

        /// <summary>
        /// The value of the node. Throws <see cref="InvalidOperationException"/>
        /// if node is detached (removed) from the list.
        /// </summary>
        public string Value 
        {
            get { this.ThrowIfInvalidated(); return this._value; } 
        }

        /// <summary>
        /// Detects whether node belongs (is attached to) <paramref name="targetContainer"/>.
        /// </summary>
        bool ILinkedListNode.BelongsTo(object targetContainer)
        {
            if (targetContainer is null) { throw new ArgumentNullException(nameof(targetContainer)); }
            this.ThrowIfInvalidated();

            return object.ReferenceEquals(this._container, targetContainer);
        }

        /// <summary>
        /// Invalidates node, detaches it from container.
        /// No further operations are possible on this node after invalidation.
        /// </summary>
        void ILinkedListNode.Invalidate()
        {
            this.InvalidateInternal();
        }

        /// <summary>
        /// Creates list node instance, sets its <paramref name="value"/> 
        /// and binds it to <paramref name="container"/>.
        /// </summary>
        protected LinkedListNode(string value, object container)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }
            if (container is null) { throw new ArgumentNullException(nameof(container)); }

            this._value = value;
            this._container = container;
        }

        /// <summary>
        /// Detaches node from list.
        /// Implementation should clean-up references to
        /// other nodes in the list.
        /// </summary>
        protected abstract void Invalidate();

        protected void ThrowIfInvalidated() 
        { 
            if (this._container is null) { throw new InvalidOperationException("Node is invalidated"); }
        }

        private void InvalidateInternal() 
        {
            this._container = null;
            this.Invalidate();
        }

    }

}
