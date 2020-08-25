namespace SimCorp.Collections.GenericLinkedList
{

    public sealed class DoublyLinkedListNode : LinkedListNode<DoublyLinkedListNode>
    {
        
        public DoublyLinkedListNode? Previous => !this.IsRoot() ? this.PreviousInternal : default;
        public DoublyLinkedListNode? Next => !this.NextInternal.IsRoot() ? this.NextInternal : default;

    }

}
