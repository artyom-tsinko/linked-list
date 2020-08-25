using System;

namespace SimCorp.Collections.ClassicLinkedList
{

    public sealed class DoublyLinkedList : LinkedList<IDoublyLinkedListNode>, ILinkedList<ILinkedListNode>
    {

        protected override IDoublyLinkedListNode CreateNode(string value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }

            return new DoublyLinkedListNode(value, this);
        }

        /// <summary>
        /// The cost is O(1)
        /// </summary>
        protected override IDoublyLinkedListNode? GetNext(IDoublyLinkedListNode current)
        {
            if (current is null) { throw new ArgumentNullException(nameof(current)); }

            return current.Next;
        }

        /// <summary>
        /// The cost is O(1)
        /// </summary>
        protected override IDoublyLinkedListNode? GetPrevious(IDoublyLinkedListNode current)
        {
            if (current is null) { throw new ArgumentNullException(nameof(current)); }

            return current.Previous;
        }

        protected override void LinkNodes(IDoublyLinkedListNode? prev, IDoublyLinkedListNode? next)
        {
            if (prev != null) { prev.Next = next; }
            if (next != null) { next.Previous = prev; }
        }


        
        ILinkedListNode ILinkedList<ILinkedListNode>.Add(string value)
        {
            return this.Add(value);
        }

        ILinkedListNode? ILinkedList<ILinkedListNode>.Find(string value)
        {
            return this.Find(value);
        }

        public void Remove(ILinkedListNode node)
        {
            var castedNode = node as IDoublyLinkedListNode;
            if (castedNode is null) { throw new InvalidOperationException("Node does not belong to this list"); }

            base.Remove(castedNode);
        }
        
    }

}
