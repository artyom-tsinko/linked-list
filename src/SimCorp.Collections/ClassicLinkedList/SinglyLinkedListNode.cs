namespace SimCorp.Collections.ClassicLinkedList
{

    public class SinglyLinkedListNode : LinkedListNode, ISinglyLinkedListNode
    {

        private ISinglyLinkedListNode? _next;

        internal SinglyLinkedListNode(string value, object container): base(value, container) { }

        ISinglyLinkedListNode? ISinglyLinkedListNode.Next
        {
            get { this.ThrowIfInvalidated(); return this._next; }
            set { this.ThrowIfInvalidated(); this._next = value; }
        }

        protected override void Invalidate()
        {
            this._next = null;
        }

    }

}
