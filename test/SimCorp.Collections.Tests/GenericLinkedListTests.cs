using System.Collections.Generic;

using NUnit.Framework;

using SimCorp.Collections.GenericLinkedList;

namespace SimCorp.Collections.Tests
{

    public static class GenericLinkedListTests
    {

        [Test]
        public static void DoublyLinkedListSample() 
        {

            var list = new GenericLinkedList.LinkedList<DoublyLinkedListNode>();
            var nodeA = list.Add("a");
            var nodeB = list.Add("b");
            var nodeC = list.Add("c");

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, list.ToArray());

            // navigate from head to tail
            var navValues = new List<string>();

            navValues.Add(nodeA.Value);
            navValues.Add(nodeA.Next.Value);
            navValues.Add(nodeA.Next.Next.Value);

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, navValues.ToArray());

            // navigate from tail to head
            navValues.Clear();
            navValues.Add(nodeC.Value);
            navValues.Add(nodeC.Previous.Value);
            navValues.Add(nodeC.Previous.Previous.Value);

            CollectionAssert.AreEqual(new[] { "c", "b", "a" }, navValues.ToArray());

            // clear list

            list.Remove(nodeB);
            CollectionAssert.AreEqual(new[] { "a", "c" }, list.ToArray());
            list.Remove(nodeA);
            CollectionAssert.AreEqual(new[] { "c" }, list.ToArray());
            list.Remove(nodeC);
            CollectionAssert.AreEqual(new string[] { }, list.ToArray());

        }

        [Test]
        public static void SinglyLinkedListSample()
        {

            var list = new GenericLinkedList.LinkedList<SinglyLinkedListNode>();
            var nodeA = list.Add("a");
            var nodeB = list.Add("b");
            var nodeC = list.Add("c");

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, list.ToArray());

            // navigate from head to tail
            var navValues = new List<string>();

            navValues.Add(nodeA.Value);
            navValues.Add(nodeA.Next.Value);
            navValues.Add(nodeA.Next.Next.Value);

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, navValues.ToArray());

            // clear list

            list.Remove(nodeB);
            CollectionAssert.AreEqual(new[] { "a", "c" }, list.ToArray());
            list.Remove(nodeA);
            CollectionAssert.AreEqual(new[] { "c" }, list.ToArray());
            list.Remove(nodeC);
            CollectionAssert.AreEqual(new string[] { }, list.ToArray());

        }

    }

}
