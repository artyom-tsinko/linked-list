using System;
using System.Collections.Generic;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static class Utilities
    {

        public static IEnumerable<TestCaseData> LinkedListImplemetations(string methodName)
        {
            yield return new TestCaseData(new SinglyLinkedList(), false).SetName($"{methodName} : SinglyLinkedList");
            yield return new TestCaseData(new DoublyLinkedList(), false).SetName($"{methodName} : DoublyLinkedList");
            yield return new TestCaseData(new SinglyLinkedList(), true).SetName($"{methodName} : SinglyLinkedList as ILinkedList");
            yield return new TestCaseData(new DoublyLinkedList(), true).SetName($"{methodName} : DoublyLinkedList as ILinkedList");
        }

        public static IEnumerable<TestCaseData> LinkedListImplemetationsWithAnotherList(string methodName)
        {
            yield return new TestCaseData(new SinglyLinkedList(), new SinglyLinkedList(), false).SetName($"{methodName} : SinglyLinkedList");
            yield return new TestCaseData(new DoublyLinkedList(), new DoublyLinkedList(), false).SetName($"{methodName} : DoublyLinkedList");
            yield return new TestCaseData(new SinglyLinkedList(), new SinglyLinkedList(), true).SetName($"{methodName} : SinglyLinkedList as ILinkedList");
            yield return new TestCaseData(new DoublyLinkedList(), new DoublyLinkedList(), true).SetName($"{methodName} : DoublyLinkedList as ILinkedList");
        }


        public static void ApplyTestCase(
            this object list,
            bool testGenericInterface,
            Action<SinglyLinkedList> forSingly,
            Action<DoublyLinkedList> forDoubly,
            Action<ILinkedList<ILinkedListNode>> forGenericInterface)
        {

            if (testGenericInterface)
            {
                forGenericInterface(list as ILinkedList<ILinkedListNode>);
                return;
            }

            switch (list)
            {
                case SinglyLinkedList s:
                    forSingly(s);
                    break;
                case DoublyLinkedList d:
                    forDoubly(d);
                    break;
                default:
                    throw new ArgumentException(
                        message: "list is not a linked list",
                        paramName: nameof(list));
            }

        }

        public static void ApplyTestCase(
            this object list,
            object anotherList,
            bool testGenericInterface,
            Action<SinglyLinkedList, SinglyLinkedList> forSingly,
            Action<DoublyLinkedList, DoublyLinkedList> forDoubly,
            Action<ILinkedList<ILinkedListNode>, ILinkedList<ILinkedListNode>> forGenericInterface)
        {

            if (testGenericInterface)
            {
                forGenericInterface(list as ILinkedList<ILinkedListNode>, anotherList as ILinkedList<ILinkedListNode>);
                return;
            }

            switch (list)
            {
                case SinglyLinkedList s:
                    forSingly(s, (SinglyLinkedList)anotherList);
                    break;
                case DoublyLinkedList d:
                    forDoubly(d, (DoublyLinkedList)anotherList);
                    break;
                default:
                    throw new ArgumentException(
                        message: "list is not a linked list",
                        paramName: nameof(list));
            }

        }

    }

}
