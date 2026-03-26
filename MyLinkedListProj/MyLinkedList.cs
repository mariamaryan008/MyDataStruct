using System.Collections; 
using System.Collections.Generic;

namespace MyLinkedListProgramm;

public class MyLinkedList<T> : ICollection<T>
{
    public MyLinkedListNode<T> Head { get; private set; }
    public MyLinkedListNode<T> Tail { get; private set; }

    #region ICollection

    public int Count { get; private set; }

    public bool IsReadOnly { get; private set; }

    public void Add(T item)
    {
        AddFirst(item);
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var current = Head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Add
    public void AddFirst(T item)
    {
        AddFirst(new MyLinkedListNode<T>(item));
    }

    private void AddFirst(MyLinkedListNode<T> node)
    {
        MyLinkedListNode<T> temp = Head;
        Head = node;
        Head.Next = temp;
        Count++;
        if (Count == 1)
            Tail = Head;
    }

    public void AddLast(T item)
    {
        AddLast(new MyLinkedListNode<T>(item));
    }

    private void AddLast(MyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            Head = node;
            Tail = node;
        }

        else
        {
            Tail.Next = node;
            Tail = node;
        }
        Count++;
    }
    #endregion

    #region Remove
    public void RemoveFirst(T item)
    {
        RemoveFirst(new MyLinkedListNode<T>(item));
    }

    private void RemoveFirst(MyLinkedListNode<T> node)
    {
        Head = Head.Next;
        Count--;
    }
    public void RemoveLast(T item)
    {
        RemoveLast(new MyLinkedListNode<T>(item));
    }
    private void RemoveLast(MyLinkedListNode<T> node)
    {
        if (Count != 0)
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                MyLinkedListNode<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            Count--;
        }
    }


    #endregion
}
