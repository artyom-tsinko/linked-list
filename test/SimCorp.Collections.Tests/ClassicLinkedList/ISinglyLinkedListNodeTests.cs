using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static class ISinglyLinkedListNodeTests
    {

        [Test]
        public static void Next_SingleNodeInList_ShouldBeNull()
        {
            var list = new SinglyLinkedList() as ILinkedList<ISinglyLinkedListNode>;

            const string nodeValue = "Phillip Farmer";

            var node = list.Add(nodeValue);

            Assert.IsNull(node.Next);
        }


        [Test]
        public static void Next_TailNode_ShouldBeNull()
        {
            var list = new SinglyLinkedList() as ILinkedList<ISinglyLinkedListNode>;

            const string nodeValue = "Phillip Farmer";

            list.Add(nodeValue);
            list.Add(nodeValue);
            list.Add(nodeValue);

            var node = list.Add(nodeValue);

            Assert.IsNull(node.Next);
        }


        [Test]
        public static void Next_MiddleNode_ShouldReturnNextNode()
        {
            var list = new SinglyLinkedList() as ILinkedList<ISinglyLinkedListNode>;

            const string nodeValue = "Michael Moorcock";

            list.Add(nodeValue);

            var currNode = list.Add(nodeValue);
            var nextNode = list.Add(nodeValue);

            Assert.AreSame(currNode.Next, nextNode);
        }

    }

}
