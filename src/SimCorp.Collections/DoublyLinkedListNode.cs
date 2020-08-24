namespace SimCorp.Collections
{

    public sealed class DoublyLinkedListNode : LinkedListNode<DoublyLinkedListNode>, IDoublyLinkedListNode
    {
        
        public IDoublyLinkedListNode? Previous => !this.IsRoot() ? this.PreviousInternal : default;
        public IDoublyLinkedListNode? Next => !this.NextInternal.IsRoot() ? this.NextInternal : default;

    }

}
