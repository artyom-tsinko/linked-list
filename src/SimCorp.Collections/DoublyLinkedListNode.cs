namespace SimCorp.Collections
{

    public sealed class DoublyLinkedListNode : LinkedListNode<DoublyLinkedListNode>
    {

        public DoublyLinkedListNode? Next => !this.NextInternal.IsRoot() ? this.NextInternal : default;
        public DoublyLinkedListNode? Previous => !this.IsRoot() ? this.PreviousInternal : default;

    }

}
