#nullable disable
public abstract class LinkedList<E>: IList<E>
{
    protected ListNode<E> head;
    protected ListNode<E> tail;
    protected int size;

    public LinkedList()
    {
        this.head = null;
        this.tail = null;
        this.size = 0;
    }

    public virtual int Size()
    {
        ListNode<E> current = this.head;
        int count = 0;

        while (current != null)
        {
            count += 1;
            current = current.next;
        }
        return count;
    }

    // Abstract methods - must be implemented differently for singly vs doubly linked lists
    public abstract void Insert(int i, E value);

    public abstract void Prepend(E value);

    public abstract void Append(E value);

    public virtual void Clear()
    {
        this.head = null;
        this.tail = null;
        this.size = 0;
    }

    public virtual E Head()
    {
        if (this.head == null)
        {
            throw new ListDoesNotContainValue();
        }
        return this.head.value;
    }

    public virtual E Last()
    {
        if (this.tail == null)
        {
            throw new ListDoesNotContainValue();
        }
        return this.tail.value;
    }

    public virtual int IndexOf(E value)
    {
        ListNode<E> current = this.head;
        int index = 0;

        while (current != null)
        {
            if (current.value.Equals(value))
            {
                return index;
            }
            index += 1;
            current = current.next;
        }

        throw new ListDoesNotContainValue();
    }

    public virtual bool Contains(E value)
    {
        try
        {
            this.IndexOf(value);
            return true;
        }
        catch (ListDoesNotContainValue)
        {
            return false;
        }
    }

    public virtual bool IsEmpty()
    {
        return this.head == null;
    }

    public virtual E Get(int i)
    {
        if (i < 0 || i >= this.Size())
        {
            throw new ListIndexOutOfBounds();
        }

        ListNode<E> current = this.head;
        for (int index = 0; index < i; index++)
        {
            current = current.next;
        }

        return current.value;
    }

    public virtual E Set(int i, E value)
    {
        if (i < 0 || i >= this.Size())
        {
            throw new ListIndexOutOfBounds();
        }

        ListNode<E> current = this.head;
        for (int index = 0; index < i; index++)
        {
            current = current.next;
        }

        E oldValue = current.value;
        current.value = value;
        return oldValue;
    }

    // Abstract removal methods - must be implemented differently for singly vs doubly linked lists
    public abstract E RemoveAt(int i);

    public abstract E RemoveFirst();

    public abstract E RemoveLast();

    public abstract E Remove(E value);

    // IEnumerable implementation
    public virtual System.Collections.Generic.IEnumerator<E> GetEnumerator()
    {
        ListNode<E> current = this.head;
        while (current != null)
        {
            yield return current.value;
            current = current.next;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}




public class ListNode<E>
{
    public E value;
    public ListNode<E> back;
    public ListNode<E> next;
}