namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Represents <see cref="SinglyLinkedList"/> list node type 
    /// for uni-directional (forward-only) linked list.
    /// </summary>
    internal sealed class SinglyLinkedListNode : LinkedListNode, ISinglyLinkedListNode
    {

        private ISinglyLinkedListNode? _next;

        /// <inheritdoc/>
        ISinglyLinkedListNode? ISinglyLinkedListNode.Next
        {
            get { this.ThrowIfInvalidated(); return this._next; }
            set { this.ThrowIfInvalidated(); this._next = value; }
        }

        /// <inheritdoc/>
        internal SinglyLinkedListNode(string value, object container): base(value, container) { }

        /// <summary>
        /// Cleans up refrences to next node in the list.
        /// </summary>
        protected override void Invalidate()
        {
            this._next = null;
        }

    }

}
