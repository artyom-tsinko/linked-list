using System;

namespace SimCorp.Collections.ClassicLinkedList
{

    public class SinglyLinkedList: LinkedList<ISinglyLinkedListNode>, ILinkedList<ILinkedListNode>
    {

        protected override ISinglyLinkedListNode CreateNode(string value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }

            return new SinglyLinkedListNode(value, this);
        }

        /// <summary>
        /// The cost is O(1)
        /// </summary>
        protected override ISinglyLinkedListNode? GetNext(ISinglyLinkedListNode current)
        {
            if (current is null) { throw new ArgumentNullException(nameof(current)); }

            return current.Next;
        }

        /// <summary>
        /// The cost is O(N)
        /// </summary>
        protected override ISinglyLinkedListNode? GetPrevious(ISinglyLinkedListNode current)
        {
            if (current is null) { throw new ArgumentNullException(nameof(current)); }

            return this.Find(node => object.ReferenceEquals(node.Next, current));
        }

        protected override void LinkNodes(ISinglyLinkedListNode? prev, ISinglyLinkedListNode? next)
        {
            if (prev != null) { prev.Next = next; }
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
            var castedNode = node as ISinglyLinkedListNode;
            if (castedNode is null) { throw new InvalidOperationException("Node does not belong to this list"); }

            base.Remove(castedNode);
        }

    }

}
