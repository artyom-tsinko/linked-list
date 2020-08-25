using System;

namespace SimCorp.Collections.ClassicLinkedList
{

    internal abstract class LinkedListNode : ILinkedListNode
    {

        private object? _container;
        private readonly string _value;

        protected LinkedListNode(string value, object container)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }
            if (container is null) { throw new ArgumentNullException(nameof(container)); }

            this._value = value;
            this._container = container;
        }

        public string Value 
        {
            get { this.ThrowIfInvalidated(); return this._value; } 
        }

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

        bool ILinkedListNode.BelongsTo(object targetContainer)
        {
            if (targetContainer is null) { throw new ArgumentNullException(nameof(targetContainer)); }
            this.ThrowIfInvalidated();

            return object.ReferenceEquals(this._container, targetContainer);
        }

        void ILinkedListNode.Invalidate()
        {
            this.InvalidateInternal();
        }

    }

}
