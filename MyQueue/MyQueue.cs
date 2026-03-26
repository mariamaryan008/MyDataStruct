using System.Collections;
using System.Collections.Generic;

namespace MyLinkedListProgramm;

public class MyQueue<T> : IEnumerable<T>
{
    private MyLinkedList<T> list;

    public MyQueue()
    {
        list = new MyLinkedList<T>();
    }

    public void Enqueue(T item)
    {
        list.AddLast(item);
    }

    public T Dequeue()
    {
        if (list.Count == 0)
        {
            throw new System.InvalidOperationException("The queue is empty");
        }

        T value = list.Head.Value;
        list.RemoveFirst(value);

        return value;
    }

    public T Peek()
    {
        if (list.Count == 0)
        {
            throw new System.InvalidOperationException("The queue is empty");
        }

        return list.Head.Value;
    }

    public int Count
    {
        get
        {
            return list.Count;
        }
    }

    public void Clear()
    {
        list.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T> current = list.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
