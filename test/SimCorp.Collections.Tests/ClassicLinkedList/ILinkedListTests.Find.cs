﻿using System;

using NUnit.Framework;

using SimCorp.Collections.ClassicLinkedList;

namespace SimCorp.Collections.Tests.ClassicLinkedList
{

    public static partial class ILinkedListTests
    {

        [TestCaseSource(nameof(LinkedListImplemetations), new object[] { nameof(Find_Condition_ShouldResult) })]
        public static void Find_Condition_ShouldResult(object list, bool testGenericInterface = false)
        {
            list.ApplyTestCase(
                testGenericInterface,
                l => Find_Condition_ShouldResult_Test<ISinglyLinkedListNode>(l),
                l => Find_Condition_ShouldResult_Test<IDoublyLinkedListNode>(l),
                l => Find_Condition_ShouldResult_Test<ILinkedListNode>(l));

        }

        public static void Find_Condition_ShouldResult_Test<TNode>(ILinkedList<TNode> list)
            where TNode : class, ILinkedListNode
        {
            Assert.NotNull(list);
        }
        
    }

}
