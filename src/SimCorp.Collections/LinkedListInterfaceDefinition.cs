namespace SimCorp.Collections
{


    public interface ILinkedList<TNode>
        where TNode : class, IListNode, new()
    {
        TNode Add(string? value);
        void Remove(TNode node);
        string?[] ToArray();
        TNode? Find(string value);
    }


    public interface ISinglyLinkedListNode : IListNode
    {
        public ISinglyLinkedListNode? Next { get; }
    }


    public interface IDoublyLinkedListNode : IListNode
    {
        public IDoublyLinkedListNode? Next { get; }
        public IDoublyLinkedListNode? Previous { get; }
    }


    public interface IListNode
    {
        string? Value { get; }
    }

}
