namespace MyBubbleSort
{
    public class MyBubbleSort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] items) 
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (CompareTo(items[i-1], items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }

        public int CompareTo(T Value, T other)
        {
            return Value.CompareTo(other);
        }

        private void Swap(T[] items, int v, int i)
        {
            T temp = items[i];
            items[i] = items[v];
            items[v] = temp;
        }
    }
}
