namespace SimCorp.Collections.GenericLinkedList
{

    public interface ILinkedList<TNode>
        where TNode : LinkedListNode<TNode>, new()
    {
        TNode Add(string value);
        void Remove(TNode node);
        string[] ToArray();
        TNode? Find(string value);
    }

}
