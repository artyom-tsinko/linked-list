using System;

namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Represents uni-directional (forward-only) linked list.
    /// </summary>
    public sealed class SinglyLinkedList: LinkedList<ISinglyLinkedListNode>, ILinkedList<ILinkedListNode>
    {
        
        /// <inheritdoc/>
        ILinkedListNode ILinkedList<ILinkedListNode>.Add(string value)
        {
            return this.Add(value);
        }

        /// <inheritdoc/>
        ILinkedListNode? ILinkedList<ILinkedListNode>.Find(string value)
        {
            return this.Find(value);
        }

        /// <inheritdoc/>
        public void Remove(ILinkedListNode node)
        {
            var castedNode = node as ISinglyLinkedListNode;
            if (castedNode is null) { throw new InvalidOperationException("Node does not belong to this list"); }

            base.Remove(castedNode);
        }

        /// <inheritdoc/>
        protected override ISinglyLinkedListNode CreateNode(string value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }

            return new SinglyLinkedListNode(value, this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <remarks>
        /// Operation cost is O(1).
        /// </remarks>
        protected override ISinglyLinkedListNode? GetNext(ISinglyLinkedListNode current)
        {
            if (current is null) { throw new ArgumentNullException(nameof(current)); }

            return current.Next;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <remarks>
        /// Operation cost is O(N).
        /// </remarks>
        protected override ISinglyLinkedListNode? GetPrevious(ISinglyLinkedListNode current)
        {
            if (current is null) { throw new ArgumentNullException(nameof(current)); }

            return this.Find(node => object.ReferenceEquals(node.Next, current));
        }

        /// <inheritdoc/>
        protected override void LinkNodes(ISinglyLinkedListNode? prev, ISinglyLinkedListNode? next)
        {
            if (prev != null) { prev.Next = next; }
        }

    }

}
