using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static partial class ILinkedListTests
    {

        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Find_EmptyList_ShouldReturnNull) })]
        public static void Find_EmptyList_ShouldReturnNull(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Find_EmptyList_ShouldReturnNull_Test<ISinglyLinkedListNode>(l),
                l => Find_EmptyList_ShouldReturnNull_Test<IDoublyLinkedListNode>(l),
                l => Find_EmptyList_ShouldReturnNull_Test<ILinkedListNode>(l));

        }


        public static void Find_EmptyList_ShouldReturnNull_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            var node = list.Find("Jack Campbell");

            Assert.IsNull(node);
        }


        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Find_FilledList_NoMatchingValue_ShouldReturnNull) })]
        public static void Find_FilledList_NoMatchingValue_ShouldReturnNull(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Find_FilledList_NoMatchingValue_ShouldReturnNull_Test<ISinglyLinkedListNode>(l),
                l => Find_FilledList_NoMatchingValue_ShouldReturnNull_Test<IDoublyLinkedListNode>(l),
                l => Find_FilledList_NoMatchingValue_ShouldReturnNull_Test<ILinkedListNode>(l));

        }


        public static void Find_FilledList_NoMatchingValue_ShouldReturnNull_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            list.Add("Josephus Flavius");
            list.Add("Herodotus");
            list.Add("Tacitus");
            
            var node = list.Find("Alexander Argead");

            Assert.IsNull(node);
        }


        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Find_FilledList_ContainsMatchingValue_ShouldReturnNode) })]
        public static void Find_FilledList_ContainsMatchingValue_ShouldReturnNode(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Find_FilledList_ContainsMatchingValue_ShouldReturnNode_Test<ISinglyLinkedListNode>(l),
                l => Find_FilledList_ContainsMatchingValue_ShouldReturnNode_Test<IDoublyLinkedListNode>(l),
                l => Find_FilledList_ContainsMatchingValue_ShouldReturnNode_Test<ILinkedListNode>(l));

        }


        public static void Find_FilledList_ContainsMatchingValue_ShouldReturnNode_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            list.Add("Josephus Flavius");
            var targetNode = list.Add("Herodotus");
            list.Add("Tacitus");

            var foundNode = list.Find("Herodotus");

            Assert.AreSame(targetNode, foundNode);
        }


        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Find_FilledList_ContainsMultipleMatchingValues_ShouldReturnFirstMatchingNode) })]
        public static void Find_FilledList_ContainsMultipleMatchingValues_ShouldReturnFirstMatchingNode(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Find_FilledList_ContainsMultipleMatchingValues_ShouldReturnFirstMatchingNode_Test<ISinglyLinkedListNode>(l),
                l => Find_FilledList_ContainsMultipleMatchingValues_ShouldReturnFirstMatchingNode_Test<IDoublyLinkedListNode>(l),
                l => Find_FilledList_ContainsMultipleMatchingValues_ShouldReturnFirstMatchingNode_Test<ILinkedListNode>(l));

        }


        public static void Find_FilledList_ContainsMultipleMatchingValues_ShouldReturnFirstMatchingNode_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            list.Add("Josephus Flavius");
            var targetNode = list.Add("Herodotus");
            list.Add("Herodotus");
            list.Add("Herodotus");
            list.Add("Herodotus");
            list.Add("Tacitus");

            var foundNode = list.Find("Herodotus");

            Assert.AreSame(targetNode, foundNode);
        }

    }

}
