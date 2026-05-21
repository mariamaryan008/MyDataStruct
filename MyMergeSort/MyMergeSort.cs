namespace MyMergeSort
{
    public class MyMergeSort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            if (items.Length <= 1)
                return;

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            Sort(left);
            Sort(right);

            Merge(items, left, right);
        }

        private void Merge(T[] items, T[] left, T[] right)
        {
            int i = 0; // left index
            int j = 0; // right index
            int k = 0; // result index

            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    items[k++] = left[i++];
                }
                else
                {
                    items[k++] = right[j++];
                }
            }

            
            while (i < left.Length)
            {
                items[k++] = left[i++];
            }

            while (j < right.Length)
            {
                items[k++] = right[j++];
            }
        }
    }
}