namespace SimCorp.Collections.GenericLinkedList
{

    public sealed class SinglyLinkedListNode : LinkedListNode<SinglyLinkedListNode>
    {

        public SinglyLinkedListNode? Next => !this.NextInternal.IsRoot() ? this.NextInternal : default;

    }

}
