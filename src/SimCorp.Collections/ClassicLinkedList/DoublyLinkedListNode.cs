namespace SimCorp.Collections.ClassicLinkedList
{

    public sealed class DoublyLinkedListNode : LinkedListNode, IDoublyLinkedListNode
    {

        internal DoublyLinkedListNode(string value, object container) : base(value, container) { }

        private IDoublyLinkedListNode? _prev;
        private IDoublyLinkedListNode? _next;

        IDoublyLinkedListNode? IDoublyLinkedListNode.Previous 
        {
            get { this.ThrowIfInvalidated(); return this._prev; } 
            set { this.ThrowIfInvalidated(); this._prev = value; }
        }

        IDoublyLinkedListNode? IDoublyLinkedListNode.Next
        {
            get { this.ThrowIfInvalidated(); return this._next; }
            set { this.ThrowIfInvalidated(); this._next = value; }
        }

        protected override void Invalidate()
        {
            this._next = null;
            this._prev = null;
        }

    }

}
