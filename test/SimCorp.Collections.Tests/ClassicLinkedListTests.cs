using NUnit.Framework;
using SimCorp.Collections.ClassicLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.Collections.Tests
{
    public static class ClassicLinkedListTests
    {


        [Test]
        public static void ListSampleTest()
        {

            //ISinglyLinkedList t = new SinglyLinkedList();
            //IDoublyLinkedList t2 = new DoublyLinkedList();

            ILinkedList<ISinglyLinkedListNode> t3 = new SinglyLinkedList();
            ILinkedList<IDoublyLinkedListNode> t4 = new DoublyLinkedList();

            // ILinkedList<ILinkedListNode> t5 = new SinglyLinkedList();
            // ILinkedList<ILinkedListNode> t6 = new DoublyLinkedList();

            // new LinkedList<DoublyLinkedListNode>()

            // ILinkedListNode t2 = new DoublyLinkedListNode();
            // IDoublyLinkedListNode t3 = new DoublyLinkedListNode();
            // ILinkedList<ILinkedListNode> t2 = new LinkedList<DoublyLinkedListNode>();

        }


    }

}
