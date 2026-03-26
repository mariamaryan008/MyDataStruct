using System;
using System.Collections.Generic;

namespace MyLinkedListProgramm
{
    public class MyStack<T>
    {
        private MyLinkedList<T> list;

        public MyStack()
        {
            list = new MyLinkedList<T>();
        }

        public void Push(T item)
        {
            list.AddFirst(item);
        }

        public T Pop()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Stack is empty.");

            T value = list.Head.Value;
            list.RemoveFirst(value);
            return value;
        }

        public T Peek()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Stack is empty.");

            return list.Head.Value;
        }
    }
}