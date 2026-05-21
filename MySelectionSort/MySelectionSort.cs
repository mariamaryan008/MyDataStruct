namespace MySelectionSort
{
    public class MySelectionSort<T>
        where T : IComparable<T>
    {


        public void Sort(T[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int minindex = i;
                for (int j = i+1; j < items.Length; j++)
                {
                    if (CompareTo(items[j], items[minindex]) < 0)
                    {
                        minindex = j;
                    }
                }

                Swap(items, i, minindex);
            }
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
