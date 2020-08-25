namespace SimCorp.Collections.GenericLinkedList
{

    /// <summary>
    /// Represents <see cref="LinkedList{TNode}"/> node type 
    /// for bi-directional linked list.
    /// </summary>
    public sealed class DoublyLinkedListNode : LinkedListNode<DoublyLinkedListNode>
    {

        public DoublyLinkedListNode? Previous => this.PreviousInternal;
        public DoublyLinkedListNode? Next => this.NextInternal;

    }

}
