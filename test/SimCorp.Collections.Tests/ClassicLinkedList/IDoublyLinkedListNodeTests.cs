using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static class IDoublyLinkedListNodeTests
    {

        [Test]
        public static void NextAndPrevious_SingleNodeInList_ShouldBeNull()
        {
            var list = new DoublyLinkedList() as ILinkedList<IDoublyLinkedListNode>;

            const string nodeValue = "Phillip Farmer";

            var node = list.Add(nodeValue);

            Assert.IsNull(node.Next);
            Assert.IsNull(node.Previous);
        }


        [Test]
        public static void NextAndPrevious_TailNode_NextShouldBeNull()
        {
            var list = new DoublyLinkedList() as ILinkedList<IDoublyLinkedListNode>;

            const string nodeValue = "Phillip Farmer";

            list.Add(nodeValue);
            list.Add(nodeValue);
            var prev = list.Add(nodeValue);

            var node = list.Add(nodeValue);

            Assert.IsNull(node.Next);
            Assert.AreSame(prev, node.Previous);
        }

        [Test]
        public static void NextAndPrevious_HeadNode_PrevShouldBeNull()
        {
            var list = new DoublyLinkedList() as ILinkedList<IDoublyLinkedListNode>;

            const string nodeValue = "Phillip Farmer";

            var node = list.Add(nodeValue);
            var next = list.Add(nodeValue);
            list.Add(nodeValue);

            Assert.IsNull(node.Previous);
            Assert.AreSame(next, node.Next);
        }


        [Test]
        public static void NextAndPrevious_MiddleNode_ShouldHaveCorrectNextAndPrevNodes()
        {
            var list = new DoublyLinkedList() as ILinkedList<IDoublyLinkedListNode>;

            const string nodeValue = "Michael Moorcock";

            var prevNode = list.Add(nodeValue);
            var currNode = list.Add(nodeValue);
            var nextNode = list.Add(nodeValue);

            Assert.AreSame(currNode.Next, nextNode);
            Assert.AreSame(currNode.Previous, prevNode);
        }

    }

}
