using System.Linq;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static partial class ILinkedListTests
    {

        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(ToArray_EmptyList_ShouldReturnEmptyArray) })]
        public static void ToArray_EmptyList_ShouldReturnEmptyArray(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => ToArray_EmptyList_ShouldReturnEmptyArray_Test<ISinglyLinkedListNode>(l),
                l => ToArray_EmptyList_ShouldReturnEmptyArray_Test<IDoublyLinkedListNode>(l),
                l => ToArray_EmptyList_ShouldReturnEmptyArray_Test<ILinkedListNode>(l));
        }


        public static void ToArray_EmptyList_ShouldReturnEmptyArray_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            CollectionAssert.AreEqual(Enumerable.Empty<string>(), list.ToArray());
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(ToArray_FilledList_ShouldReturnArrayItemsInListOrder) })]
        public static void ToArray_FilledList_ShouldReturnArrayItemsInListOrder(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => ToArray_FilledList_ShouldReturnArrayItemsInListOrder_Test<ISinglyLinkedListNode>(l),
                l => ToArray_FilledList_ShouldReturnArrayItemsInListOrder_Test<IDoublyLinkedListNode>(l),
                l => ToArray_FilledList_ShouldReturnArrayItemsInListOrder_Test<ILinkedListNode>(l));
        }


        public static void ToArray_FilledList_ShouldReturnArrayItemsInListOrder_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Roger Zelazny";
            var counter = 0;

            var node1 = list.Add($"{nodeValue}{++counter}");
            var node2 = list.Add($"{nodeValue}{++counter}");
            list.Add($"{nodeValue}{++counter}");
            var node4 = list.Add($"{nodeValue}{++counter}");
            list.Add($"{nodeValue}{++counter}");

            list.Remove(node2);
            list.Remove(node1);
            list.Remove(node4);

            CollectionAssert.AreEqual(new string[] { $"{nodeValue}3", $"{nodeValue}5" }, list.ToArray());
        }

    }

}
