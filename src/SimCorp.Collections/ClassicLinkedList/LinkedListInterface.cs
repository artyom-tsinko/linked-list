namespace SimCorp.Collections.ClassicLinkedList
{

    public interface ILinkedList<TNode>
        where TNode: class, ILinkedListNode
    {
        TNode Add(string value);
        void Remove(TNode node);
        string[] ToArray();
        TNode? Find(string value);
    }

    public interface IDoublyLinkedListNode : ILinkedListNode
    {
        IDoublyLinkedListNode? Previous { get; internal set; }
        IDoublyLinkedListNode? Next { get; internal set; }
    }

    public interface ISinglyLinkedListNode : ILinkedListNode
    {
        ISinglyLinkedListNode? Next { get; internal set; }
    }

    public interface ILinkedListNode 
    {
        string Value { get; }

        internal bool BelongsTo(object container);
        internal void Invalidate();
    }

}
