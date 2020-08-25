using System;

namespace SimCorp.Collections.ClassicLinkedList
{

    public abstract class LinkedListNode : ILinkedListNode
    {

        private object? _container;
        private readonly string _value;

        protected LinkedListNode(string value, object container)
        {
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
            this.ThrowIfInvalidated();

            return object.ReferenceEquals(this._container, targetContainer);
        }

        void ILinkedListNode.Invalidate()
        {
            this.InvalidateInternal();
        }

    }

}
