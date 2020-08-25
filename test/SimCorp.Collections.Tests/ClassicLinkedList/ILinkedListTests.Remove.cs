using System.Linq;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;


namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static partial class ILinkedListTests
    {


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Remove_NodeFromNonEmptyList_ShouldRemoveNodeFromList) })]
        public static void Remove_NodeFromNonEmptyList_ShouldRemoveNodeFromList(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Remove_NodeFromNonEmptyList_ShouldRemoveNodeFromList_Test<ISinglyLinkedListNode>(l),
                l => Remove_NodeFromNonEmptyList_ShouldRemoveNodeFromList_Test<IDoublyLinkedListNode>(l),
                l => Remove_NodeFromNonEmptyList_ShouldRemoveNodeFromList_Test<ILinkedListNode>(l));

        }


        public static void Remove_NodeFromNonEmptyList_ShouldRemoveNodeFromList_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Robert Heinlein";
            var counter = 0;

            list.Add($"{nodeValue}{++counter}");
            var nodeToRemove = list.Add($"{nodeValue}{++counter}");
            list.Add($"{nodeValue}{++counter}");

            list.Remove(nodeToRemove);

            CollectionAssert.AreEqual(new string[] { $"{nodeValue}1", $"{nodeValue}3" }, list.ToArray());
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Remove_HeadNode_ShouldSetNextAsHead) })]
        public static void Remove_HeadNode_ShouldSetNextAsHead(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Remove_HeadNode_ShouldSetNextAsHead_Test<ISinglyLinkedListNode>(l),
                l => Remove_HeadNode_ShouldSetNextAsHead_Test<IDoublyLinkedListNode>(l),
                l => Remove_HeadNode_ShouldSetNextAsHead_Test<ILinkedListNode>(l));

        }


        public static void Remove_HeadNode_ShouldSetNextAsHead_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Stanislaw Lem";
            var counter = 0;

            var nodeToRemove = list.Add($"{nodeValue}{++counter}");
            list.Add($"{nodeValue}{++counter}");
            list.Add($"{nodeValue}{++counter}");

            list.Remove(nodeToRemove);

            CollectionAssert.AreEqual(new string[] { $"{nodeValue}2", $"{nodeValue}3" }, list.ToArray());
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Remove_TailNode_ShouldSetPreviousAsTail) })]
        public static void Remove_TailNode_ShouldSetPreviousAsTail(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Remove_TailNode_ShouldSetPreviousAsTail_Test<ISinglyLinkedListNode>(l),
                l => Remove_TailNode_ShouldSetPreviousAsTail_Test<IDoublyLinkedListNode>(l),
                l => Remove_TailNode_ShouldSetPreviousAsTail_Test<ILinkedListNode>(l));

        }


        public static void Remove_TailNode_ShouldSetPreviousAsTail_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Ray Bradbury";
            var counter = 0;

            list.Add($"{nodeValue}{++counter}");
            list.Add($"{nodeValue}{++counter}");
            var nodeToRemove = list.Add($"{nodeValue}{++counter}");

            list.Remove(nodeToRemove);

            CollectionAssert.AreEqual(new string[] { $"{nodeValue}1", $"{nodeValue}2" }, list.ToArray());
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Remove_OnlyNode_ListShouldBecomeEmpty) })]
        public static void Remove_OnlyNode_ListShouldBecomeEmpty(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Remove_OnlyNode_ListShouldBecomeEmpty_Test<ISinglyLinkedListNode>(l),
                l => Remove_OnlyNode_ListShouldBecomeEmpty_Test<IDoublyLinkedListNode>(l),
                l => Remove_OnlyNode_ListShouldBecomeEmpty_Test<ILinkedListNode>(l));

        }


        public static void Remove_OnlyNode_ListShouldBecomeEmpty_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Neil Gaiman";

            var nodeToRemove = list.Add($"{nodeValue}");

            list.Remove(nodeToRemove);

            CollectionAssert.AreEqual(Enumerable.Empty<string>(), list.ToArray());
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Remove_NodeRemovedTwice_ShouldThrow) })]
        public static void Remove_NodeRemovedTwice_ShouldThrow(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Remove_NodeRemovedTwice_ShouldThrow_Test<ISinglyLinkedListNode>(l),
                l => Remove_NodeRemovedTwice_ShouldThrow_Test<IDoublyLinkedListNode>(l),
                l => Remove_NodeRemovedTwice_ShouldThrow_Test<ILinkedListNode>(l));

        }


        public static void Remove_NodeRemovedTwice_ShouldThrow_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Andre Norton";

            var nodeToRemove = list.Add($"{nodeValue}");

            list.Remove(nodeToRemove);

            var e = Assert.Throws<System.InvalidOperationException>(() => list.Remove(nodeToRemove));
            Assert.AreEqual("Node is invalidated", e.Message);

            CollectionAssert.AreEqual(Enumerable.Empty<string>(), list.ToArray());
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetationsWithAnotherList), new object[] { nameof(Remove_NodeFromAnotherList_ShouldThrow) })]
        public static void Remove_NodeFromAnotherList_ShouldThrow(object list, object anotherList, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                anotherList,
                testGenericInterface,
                (l, al) => Remove_NodeFromAnotherList_ShouldThrow_Test<ISinglyLinkedListNode>(l, al),
                (l, al) => Remove_NodeFromAnotherList_ShouldThrow_Test<IDoublyLinkedListNode>(l, al),
                (l, al) => Remove_NodeFromAnotherList_ShouldThrow_Test<ILinkedListNode>(l, al));

        }


        public static void Remove_NodeFromAnotherList_ShouldThrow_Test<TNode>(ILinkedList<TNode> list, ILinkedList<TNode> anotherList)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Harry Harrison";

            var nodeToRemove = anotherList.Add(nodeValue);

            var e = Assert.Throws<System.InvalidOperationException>(() => list.Remove(nodeToRemove));
            Assert.AreEqual("Node does not belong to this list", e.Message);

            CollectionAssert.AreEqual(Enumerable.Empty<string>(), list.ToArray());
        }

    }

}
