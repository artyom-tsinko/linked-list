namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Represents <see cref="DoublyLinkedList"/> list node type 
    /// for bi-directional (back and forth) linked list.
    /// </summary>
    internal sealed class DoublyLinkedListNode : LinkedListNode, IDoublyLinkedListNode
    {

        private IDoublyLinkedListNode? _prev;
        private IDoublyLinkedListNode? _next;

        /// <inheritdoc/>
        internal DoublyLinkedListNode(string value, object container) : base(value, container) { }

        /// <inheritdoc/>
        IDoublyLinkedListNode? IDoublyLinkedListNode.Previous 
        {
            get { this.ThrowIfInvalidated(); return this._prev; } 
            set { this.ThrowIfInvalidated(); this._prev = value; }
        }

        /// <inheritdoc/>
        IDoublyLinkedListNode? IDoublyLinkedListNode.Next
        {
            get { this.ThrowIfInvalidated(); return this._next; }
            set { this.ThrowIfInvalidated(); this._next = value; }
        }

        /// <summary>
        /// Cleans up refrences to next and previous 
        /// nodes in the list.
        /// </summary>
        protected override void Invalidate()
        {
            this._next = null;
            this._prev = null;
        }

    }

}
