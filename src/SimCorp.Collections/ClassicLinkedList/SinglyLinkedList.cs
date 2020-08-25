namespace SimCorp.Collections.ClassicLinkedList
{

    public class SinglyLinkedList: LinkedList<ISinglyLinkedListNode>
    {

        protected override ISinglyLinkedListNode CreateNode(string value)
        {
            return new SinglyLinkedListNode(value, this);
        }

        protected override ISinglyLinkedListNode? GetNext(ISinglyLinkedListNode current)
        {
            return current.Next;
        }

        protected override ISinglyLinkedListNode? GetPrevious(ISinglyLinkedListNode current)
        {
            return this.Find(node => object.ReferenceEquals(node.Next, current));
        }

        protected override void LinkNodes(ISinglyLinkedListNode? prev, ISinglyLinkedListNode? next)
        {
            if (prev != null) { prev.Next = next; }
        }

    }

}
