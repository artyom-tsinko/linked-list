namespace SimCorp.Collections.GenericLinkedList
{

    /// <summary>
    /// Represents <see cref="LinkedList{TNode}"/> node type 
    /// for uni-directional (forward-only) linked list.
    /// </summary>
    public sealed class SinglyLinkedListNode : LinkedListNode<SinglyLinkedListNode>
    {

        public SinglyLinkedListNode? Next => this.NextInternal;

    }

}
