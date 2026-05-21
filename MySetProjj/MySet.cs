using MyLinkedListProj;
namespace MySetProjj;

public class Set<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private readonly MyLinkedList<T> _items = new MyLinkedList<T>();

    public Set()
    { }
    public Set(IEnumerable<T> items)
    {
        AddRange(items);
    }

    public void Add(T item)
    {
        if (Contains(item))
        {
            throw new InvalidOperationException("Item already exists in the set.");
        }
        _items.Add(item);
    }
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }
    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public int Count
    {
        get { return _items.Count; }
    }

    private void AddSkipDuplicates(T item)
    {
        if (!Contains(item))
        {
            _items.Add(item);
        }
    }

    private void AddRangeSkipDuplicates(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            AddSkipDuplicates(item);
        }
    }

    public Set<T> Union(Set<T> other)
    {
        Set<T> result = new Set<T>();

        result.AddRangeSkipDuplicates(_items);
        result.AddRangeSkipDuplicates(other._items);

        return result;
    }

    public Set<T> Intersection(Set<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));
        Set<T> result = new Set<T>();
        foreach (T item in _items)
        {
            if (other._items.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }


    public Set<T> Difference(Set<T> other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        Set<T> result = new Set<T>();

        foreach (T item in _items)
        {
            if (!other.Contains(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public Set<T> SymmetricDifference(Set<T> other)
    {

        Set<T> intersection = Intersection(other);
        Set<T> union = Union(other);
        return union.Difference(intersection);
    }





    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}