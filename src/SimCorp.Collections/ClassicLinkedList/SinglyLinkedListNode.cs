namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Represents <see cref="SinglyLinkedList"/> list node type 
    /// for uni-directional (forward-only) linked list.
    /// </summary>
    internal sealed class SinglyLinkedListNode : LinkedListNode, ISinglyLinkedListNode
    {

        private ISinglyLinkedListNode? _next;

        ISinglyLinkedListNode? ISinglyLinkedListNode.Next
        {
            get { this.ThrowIfInvalidated(); return this._next; }
            set { this.ThrowIfInvalidated(); this._next = value; }
        }

        internal SinglyLinkedListNode(string value, object container): base(value, container) { }

        protected override void Invalidate()
        {
            this._next = null;
        }

    }

}
