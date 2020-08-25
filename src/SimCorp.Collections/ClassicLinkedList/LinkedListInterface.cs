namespace SimCorp.Collections.ClassicLinkedList
{

    /// <summary>
    /// Basic interface representing linked list with nodes 
    /// of <typeparamref name="TNode"/> type. 
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the list node.
    /// Based on node type, list navigation could be uni- or bi/multi-directional.
    /// </typeparam>
    public interface ILinkedList<TNode>
        where TNode: class, ILinkedListNode
    {

        /// <summary>
        /// Creates <typeparamref name="TNode"/> with <paramref name="value"/> value
        /// and adds itto the end of the list.
        /// </summary>
        /// <remarks>
        /// Expected operation cost is O(1),
        /// but depends on implementation.
        /// </remarks>
        TNode Add(string value);

        /// <summary>
        /// Removes <paramref name="node"/> from list.
        /// </summary>
        /// <remarks>
        /// <paramref name="node"/> should be create by the list via
        /// <see cref="Add(string)"/> method, otherwise exception should be thrown.
        /// Expected operation cost is from O(1) to O(N),
        /// depending on implementation.
        /// </remarks>
        /// <param name="node"></param>
        void Remove(TNode node);

        /// <summary>
        /// Traverses given list from head to tail and 
        /// returns its node values as array.
        /// </summary>
        string[] ToArray();

        /// <summary>
        /// Looks for a <see cref="TNode"/> in the list which value equals <paramref name="search"/>.
        /// </summary>
        /// <remarks>
        /// Expected operation cost is from O(1) to O(N),
        /// depending on implementation.
        /// </remarks>
        /// <returns>
        /// <see cref="TNode"/> if found, null otherwise.
        /// </returns>
        TNode? Find(string value);

    }

    /// <summary>
    /// Bi-directional navigation list node type 
    /// for <see cref="ILinkedList{TNode}"/>.
    /// </summary>
    public interface IDoublyLinkedListNode : ILinkedListNode
    {

        /// <summary>
        /// Previous node in navigation sequence. Could be null
        /// if current node is a list head.
        /// </summary>
        IDoublyLinkedListNode? Previous { get; internal set; }

        /// <summary>
        /// Next node in navigation sequence. Could be null
        /// if current node is a list tail.
        /// </summary>
        IDoublyLinkedListNode? Next { get; internal set; }

    }

    /// <summary>
    /// Uni-directional (forward-only) navigation list node type 
    /// for <see cref="ILinkedList{TNode}"/>.
    /// </summary>
    public interface ISinglyLinkedListNode : ILinkedListNode
    {

        /// <summary>
        /// Next node in navigation sequence. Could be null
        /// if current node is a list tail.
        /// </summary>
        ISinglyLinkedListNode? Next { get; internal set; }

    }

    /// <summary>
    /// Base node type for <see cref="ILinkedList{TNode}"/>.
    /// Provides only value accessor with no navigation.
    /// </summary>
    public interface ILinkedListNode 
    {

        /// <summary>
        /// The value of the node. Throws <see cref="InvalidOperationException"/>
        /// if node is detached (removed) from the list.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Detects whether node belongs (is attached to) <paramref name="targetContainer"/>.
        /// </summary>
        internal bool BelongsTo(object container);

        /// <summary>
        /// Invalidates node, detaches it from container.
        /// No further operations are possible on this node after invalidation.
        /// </summary>
        internal void Invalidate();

    }

}
