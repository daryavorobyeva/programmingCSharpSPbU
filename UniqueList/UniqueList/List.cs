namespace SimpleList;

/// <summary>
/// Linked List Class.
/// </summary>
public class List
{
    /// <summary>
    /// A linked list node.
    /// </summary>
    protected class ListNode
    {
        public int Value { get; set; }

        /// <summary>
        /// Link to the next element.
        /// </summary>
        public ListNode? Next { get; set; }

        public ListNode(int value = 0, ListNode? next = null)
        {
            Value = value;
            Next = next;
        }
    }

    /// <summary>
    /// The number of items in the list.
    /// </summary>
    public int Size { get; set; }

    protected ListNode? head = null;

    /// <summary>
    /// Add new element in list.
    /// </summary>
    public virtual void Add(int value)
    {
        if (head == null)
        {
            head = new ListNode(value); 
        }
        else
        {
            head.Next = new ListNode(value);
        }
        Size++;
    }

    /// <summary>
    /// Deletes the last item in the list.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void Remove()
    {
        if (Size == 0)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        if (Size == 1)
        {
            head = null;
        }
        else
        {
            ListNode current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }
        Size--;
    }


    /// <summary>
    /// Replace element in list by position to another value.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public virtual void Replace(int value, int position)
    {
        if (position > Size - 1 || position < 0)
        {
            throw new IndexOutOfRangeException("Invalid item position number.");
        }

        ListNode current = head;
        int counter = 1;
        while (counter != position)
        {
            current = current.Next;
            counter++;
        }
        current.Value = value;
    }
}