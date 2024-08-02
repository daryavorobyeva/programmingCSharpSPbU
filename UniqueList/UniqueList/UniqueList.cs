using SimpleList;
using UniqueList.Exeptions;

namespace UniqueList;

/// <summary>
/// Inherited from the standard linked list, but has unique elements.
/// </summary>
public class SimpleUniqueList : List
{
    /// <summary>
    /// Calculates whether a value is unique for a given list.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private bool IsUnique(int value)
    {
        ListNode current = head;
        for (int i = 0; i < Size; ++i)
        {
            if (current.Value == value)
            {
                return false;
            }
            current = current.Next;
        }
        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationValueAlreadyExistsException"></exception>
    public override void Add(int value)
    {
        if (!IsUnique(value))
        {
            throw new InvalidOperationValueAlreadyExistsException("The value already exists in the list.");
        }
        base.Add(value);
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationValueAlreadyExistsException"></exception>
    public override void Replace(int value, int position)
    {
        if (!IsUnique(value))
        {
            throw new InvalidOperationValueAlreadyExistsException("The value already exists in the list.");
        }
        base.Replace(value, position);
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidRemoveOperationException"></exception>
    public void RemoveByValue(int value)
    {
        if (IsUnique(value))
        {
            throw new InvalidRemoveOperationException("This value is not in the list.");
        }

        ListNode current = head;
        for (int i = 0; i < Size; ++i)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
            }
            current = current.Next;
        }
    }
}
