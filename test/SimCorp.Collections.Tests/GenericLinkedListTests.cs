using NUnit.Framework;
using SimCorp.Collections.GenericLinkedList;
using System;
using System.Collections.Generic;

namespace SimCorp.Collections.Tests
{


    public class ObjWithEnum 
    {
        public IEnumerable<int> GetValues() 
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }

    public static class GenericLinkedListTests
    {

        [Test]
        public static void SampleTest() 
        {
            Assert.Pass("Have fun with your lists!");
        }

        [Test]
        public static void NullableEnumTest()
        {
            var t = default(ObjWithEnum)?.GetValues();
            Assert.IsNotNull(t);
        }

        [Test]
        public static void EmptyArrayTest()
        {
            var emptyArr = Array.Empty<string>();
            emptyArr[0] = "abc";
            emptyArr[1] = "def";

            Assert.Pass();
        }

        [Test]
        public static void StringEqualsTest()
        {
            Console.WriteLine(string.Equals(null, null, StringComparison.Ordinal));
            Console.WriteLine(string.Equals(null, "", StringComparison.Ordinal));

            Assert.Pass();
        }


        [Test]
        public static void ListSampleTest() 
        {

            ILinkedList<DoublyLinkedListNode> t = new GenericLinkedList.LinkedList<DoublyLinkedListNode>();
            ILinkedList<SinglyLinkedListNode> t2 = new GenericLinkedList.LinkedList<SinglyLinkedListNode>();
            // new LinkedList<DoublyLinkedListNode>()

            // ILinkedListNode t2 = new DoublyLinkedListNode();
            // IDoublyLinkedListNode t3 = new DoublyLinkedListNode();
            // ILinkedList<ILinkedListNode> t2 = new LinkedList<DoublyLinkedListNode>();

        }

    }

}
