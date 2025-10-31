#nullable disable
public class SinglyLinkedList<E> : LinkedList<E>
{
    public SinglyLinkedList() : base() { }

    public override void Prepend(E value)
    {
        ListNode<E> newNode = new ListNode<E>();
        newNode.value = value;
        newNode.next = this.head;
        newNode.back = null;

        this.head = newNode;

        if (this.tail == null)
        {
            this.tail = newNode;
        }
    }

    public override void Append(E value)
    {
        ListNode<E> newNode = new ListNode<E>();
        newNode.value = value;
        newNode.next = null;
        newNode.back = null;

        if (this.tail == null)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
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
        newNode.back = null;

        // Traverse to node BEFORE insertion point
        ListNode<E> current = this.head;
        for (int index = 0; index < i - 1; index++)
        {
            current = current.next;
        }

        // Only update next pointers
        newNode.next = current.next;
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

        if (this.head == null)
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

        // Special case: only one element
        if (this.head == this.tail)
        {
            this.head = null;
            this.tail = null;
            return value;
        }

        // Must traverse entire list to find second-to-last node
        ListNode<E> current = this.head;
        while (current.next != this.tail)
        {
            current = current.next;
        }

        current.next = null;
        this.tail = current;

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

        // Must traverse to node BEFORE the one to remove
        ListNode<E> current = this.head;
        for (int index = 0; index < i - 1; index++)
        {
            current = current.next;
        }

        E value = current.next.value;
        current.next = current.next.next;

        return value;
    }

    public override E Remove(E value)
    {
        if (this.head == null)
        {
            throw new ListDoesNotContainValue();
        }

        // Special case: removing first element
        if (this.head.value.Equals(value))
        {
            return this.RemoveFirst();
        }

        // Must keep track of previous node while searching
        ListNode<E> current = this.head;
        ListNode<E> previous = null;

        while (current != null)
        {
            if (current.value.Equals(value))
            {
                // Remove the node
                previous.next = current.next;

                // Update tail if we removed the last element
                if (current == this.tail)
                {
                    this.tail = previous;
                }

                return current.value;
            }
            previous = current;
            current = current.next;
        }

        throw new ListDoesNotContainValue();
    }
}