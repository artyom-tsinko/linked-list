using System;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static partial class ILinkedListTests
    {

        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Remove_Condition_ShouldResult) })]
        public static void Remove_Condition_ShouldResult(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Add_NullString_ShouldThrow_Test<ISinglyLinkedListNode>(l),
                l => Add_NullString_ShouldThrow_Test<IDoublyLinkedListNode>(l),
                l => Add_NullString_ShouldThrow_Test<ILinkedListNode>(l));

        }

        public static void Remove_Condition_ShouldResult_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);
        }
        
    }

}
