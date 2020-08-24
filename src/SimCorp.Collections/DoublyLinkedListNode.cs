using System;
using System.Collections.Generic;
using System.Text;

namespace SimCorp.Collections
{

    public sealed class DoublyLinkedListNode : LinkedListNode<DoublyLinkedListNode>
    {

        public DoublyLinkedListNode Next => this.NextInternal;
        public DoublyLinkedListNode Prev => this.PrevInternal;

    }

}
