using System;

namespace SimCorp.Collections
{

    public abstract class LinkedListNode<TNode>
        where TNode : LinkedListNode<TNode>, new()
    {

        private LinkedList<TNode> _container = default;

        // TODO - is it necessary? double-check
        internal LinkedListNode() { }

        public string Value { get; private set; }
        internal TNode PrevInternal { get; set; }
        internal TNode NextInternal { get; set; }


        /// <summary>
        /// Returns new Root
        /// </summary>
        internal void AttachTo(LinkedList<TNode> container, string value)
        {
            if (this._container != null)
            {
                throw new InvalidOperationException("This node is already attached to another list");
            }

            this._container = container;
            this.Value = value;
        }

        /// <summary>
        /// Returns new Root
        /// </summary>
        internal void RemoveFrom(LinkedList<TNode> container)
        {
            if (this._container is null ||
                !object.ReferenceEquals(this._container, container))
            {
                throw new InvalidOperationException("This node was not attached to this container");
            }

            this._container = null;
        }

    }

    

    

}
