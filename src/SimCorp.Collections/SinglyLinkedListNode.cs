namespace SimCorp.Collections
{

    public sealed class SinglyLinkedListNode : LinkedListNode<SinglyLinkedListNode>
    {
        public SinglyLinkedListNode Next => this.NextInternal;
    }

}
