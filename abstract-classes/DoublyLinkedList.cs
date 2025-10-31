#nullable disable
public class DoublyLinkedList<E> : LinkedList<E>
{
    public DoublyLinkedList() : base() { }

    public override void Prepend(E value)
    {
        ListNode<E> newNode = new ListNode<E>();
        newNode.value = value;
        newNode.back = null;

        if (this.head == null)
        {
            newNode.next = null;
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.next = this.head;
            this.head.back = newNode;
            this.head = newNode;
        }
    }

    public override void Append(E value)
    {
        ListNode<E> newNode = new ListNode<E>();
        newNode.value = value;
        newNode.next = null;

        if (this.tail == null)
        {
            newNode.back = null;
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.back = this.tail;
            this.tail.next = newNode;
            this.tail = newNode;
        }
    }

    public override void Insert(int i, E value)
    {
        if (i < 0 || i > this.Size())
        {
            throw new ListIndexOutOfBounds();
        }

        if (i == 0)
        {
            this.Prepend(value);
            return;
        }

        if (i == this.Size())
        {
            this.Append(value);
            return;
        }

        ListNode<E> newNode = new ListNode<E>();
        newNode.value = value;

        // Traverse to node BEFORE insertion point
        ListNode<E> current = this.head;
        for (int index = 0; index < i - 1; index++)
        {
            current = current.next;
        }

        // Update all four pointers
        newNode.next = current.next;
        newNode.back = current;
        current.next.back = newNode;
        current.next = newNode;
    }

    public override E RemoveFirst()
    {
        if (this.head == null)
        {
            throw new ListDoesNotContainValue();
        }

        E value = this.head.value;
        this.head = this.head.next;

        if (this.head != null)
        {
            this.head.back = null;
        }
        else
        {
            this.tail = null;
        }

        return value;
    }

    public override E RemoveLast()
    {
        if (this.tail == null)
        {
            throw new ListDoesNotContainValue();
        }

        E value = this.tail.value;
        this.tail = this.tail.back;

        if (this.tail != null)
        {
            this.tail.next = null;
        }
        else
        {
            this.head = null;
        }

        return value;
    }

    public override E RemoveAt(int i)
    {
        if (i < 0 || i >= this.Size())
        {
            throw new ListIndexOutOfBounds();
        }

        if (i == 0)
        {
            return this.RemoveFirst();
        }

        if (i == this.Size() - 1)
        {
            return this.RemoveLast();
        }

        // Traverse to the actual node to remove
        ListNode<E> current = this.head;
        for (int index = 0; index < i; index++)
        {
            current = current.next;
        }

        E value = current.value;

        // Update both directions
        current.back.next = current.next;
        current.next.back = current.back;

        return value;
    }

    public override E Remove(E value)
    {
        if (this.head == null)
        {
            throw new ListDoesNotContainValue();
        }

        ListNode<E> current = this.head;

        while (current != null)
        {
            if (current.value.Equals(value))
            {
                // Special case: removing first element
                if (current == this.head)
                {
                    return this.RemoveFirst();
                }

                // Special case: removing last element
                if (current == this.tail)
                {
                    return this.RemoveLast();
                }

                // Remove from middle using back pointer
                current.back.next = current.next;
                current.next.back = current.back;

                return current.value;
            }
            current = current.next;
        }

        throw new ListDoesNotContainValue();
    }
}