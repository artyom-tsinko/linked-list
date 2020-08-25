using System;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static class ILinkedListNodeTests
    {

        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Value_NodeInTheList_ShouldReturnValue) })]
        public static void Value_NodeInTheList_ShouldReturnValue(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Value_NodeInTheList_ShouldReturnValue_Test<ISinglyLinkedListNode>(l),
                l => Value_NodeInTheList_ShouldReturnValue_Test<IDoublyLinkedListNode>(l),
                l => Value_NodeInTheList_ShouldReturnValue_Test<ILinkedListNode>(l));
        }


        public static void Value_NodeInTheList_ShouldReturnValue_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);
            const string nodeValue = "Antonin Dvorak";
            var node = list.Add(nodeValue);
            Assert.AreEqual(nodeValue, node.Value);
        }


        [TestCaseSource(typeof(Utilities), nameof(Utilities.LinkedListImplemetations), new object[] { nameof(Value_NodeRemovedFromList_ShouldThrow) })]
        public static void Value_NodeRemovedFromList_ShouldThrow(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Value_NodeRemovedFromList_ShouldThrow_Test<ISinglyLinkedListNode>(l),
                l => Value_NodeRemovedFromList_ShouldThrow_Test<IDoublyLinkedListNode>(l),
                l => Value_NodeRemovedFromList_ShouldThrow_Test<ILinkedListNode>(l));
        }


        public static void Value_NodeRemovedFromList_ShouldThrow_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);
            const string nodeValue = "Antonin Dvorak";

            var node = list.Add(nodeValue);
            list.Remove(node);

            var e = Assert.Throws<InvalidOperationException>(() => { var t = node.Value; });
            Assert.AreEqual("Node is invalidated", e.Message);
        }

    }

}
