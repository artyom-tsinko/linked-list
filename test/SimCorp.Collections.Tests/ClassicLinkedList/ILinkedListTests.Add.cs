using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static partial class ILinkedListTests
    {

        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Add_NullString_ShouldThrow) })]
        public static void Add_NullString_ShouldThrow(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Add_NullString_ShouldThrow_Test<ISinglyLinkedListNode>(l),
                l => Add_NullString_ShouldThrow_Test<IDoublyLinkedListNode>(l),
                l => Add_NullString_ShouldThrow_Test<ILinkedListNode>(l));

        }

        public static void Add_NullString_ShouldThrow_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);
            var e = Assert.Throws<ArgumentNullException>(() => list.Add(default));
            Assert.IsTrue(e.Message.StartsWith("Value cannot be null."));
            Assert.IsTrue(e.Message.Contains("value"));
        }


        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Add_NotNullString_ShouldReturnNodeWithValue) })]
        public static void Add_NotNullString_ShouldReturnNodeWithValue(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Add_NotNullString_ShouldReturnNodeWithValue_Test<ISinglyLinkedListNode>(l),
                l => Add_NotNullString_ShouldReturnNodeWithValue_Test<IDoublyLinkedListNode>(l),
                l => Add_NotNullString_ShouldReturnNodeWithValue_Test<ILinkedListNode>(l));

        }

        public static void Add_NotNullString_ShouldReturnNodeWithValue_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Arthur Clarke";
            var node = list.Add(nodeValue);

            Assert.NotNull(node);
            Assert.AreEqual(nodeValue, node.Value);

            // Assert list state, though covering more than single aspect of the interface
            CollectionAssert.AreEqual(new[] { nodeValue }, list.ToArray());
        }


        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Add_DuplicateValues_ShouldReturnDifferentNodesWithSameValue) })]
        public static void Add_DuplicateValues_ShouldReturnDifferentNodesWithSameValue(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Add_DuplicateValues_ShouldReturnDifferentNodesWithSameValue_Test<ISinglyLinkedListNode>(l),
                l => Add_DuplicateValues_ShouldReturnDifferentNodesWithSameValue_Test<IDoublyLinkedListNode>(l),
                l => Add_DuplicateValues_ShouldReturnDifferentNodesWithSameValue_Test<ILinkedListNode>(l));

        }

        public static void Add_DuplicateValues_ShouldReturnDifferentNodesWithSameValue_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Isaak Asimov";
            var nodes = new List<TNode>();

            nodes.Add(list.Add(nodeValue));
            nodes.Add(list.Add(nodeValue));
            nodes.Add(list.Add(nodeValue));

            // no nodes are null
            Assert.IsTrue(!nodes.Any(node => node is null));
            // all nodes are unique instances
            Assert.AreEqual(nodes.Count, nodes.Distinct(EqualityComparer<TNode>.Default).Count());
            // all nodes has the same value
            Assert.AreEqual(nodeValue, nodes.Select(node => node.Value).Distinct().SingleOrDefault());

            // Assert list state, though covering more than single aspect of the interface
            CollectionAssert.AreEqual(Enumerable.Repeat(nodeValue, nodes.Count), list.ToArray());
        }


        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Add_MultipleValues_ShouldAppendNewValues) })]
        public static void Add_MultipleValues_ShouldAppendNewValues(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Add_MultipleValues_ShouldAppendNewValues_Test<ISinglyLinkedListNode>(l),
                l => Add_MultipleValues_ShouldAppendNewValues_Test<IDoublyLinkedListNode>(l),
                l => Add_MultipleValues_ShouldAppendNewValues_Test<ILinkedListNode>(l));

        }

        public static void Add_MultipleValues_ShouldAppendNewValues_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);

            const string nodeValue = "Clifford Simak";
            var counter = 0;
            var nodes = new List<TNode>();

            nodes.Add(list.Add($"{nodeValue}{++counter}"));
            nodes.Add(list.Add($"{nodeValue}{++counter}"));
            nodes.Add(list.Add($"{nodeValue}{++counter}"));

            // Assert list state, though covering more than single aspect of the interface
            CollectionAssert.AreEqual(Enumerable.Repeat(nodeValue, nodes.Count).Select((v, index) => $"{nodeValue}{index + 1}"), list.ToArray());
        }

    }

}
