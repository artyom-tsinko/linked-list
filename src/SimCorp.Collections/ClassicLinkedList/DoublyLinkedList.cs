namespace SimCorp.Collections.ClassicLinkedList
{

    public sealed class DoublyLinkedList : LinkedList<IDoublyLinkedListNode>
    {
        
        protected override IDoublyLinkedListNode CreateNode(string value)
        {
            return new DoublyLinkedListNode(value, this);
        }

        protected override IDoublyLinkedListNode? GetNext(IDoublyLinkedListNode current)
        {
            return current.Next;
        }

        protected override IDoublyLinkedListNode? GetPrevious(IDoublyLinkedListNode current)
        {
            return current.Previous;
        }

        protected override void LinkNodes(IDoublyLinkedListNode? prev, IDoublyLinkedListNode? next)
        {
            if (prev != null) { prev.Next = next; }
            if (next != null) { next.Previous = prev; }
        }

    }

}
