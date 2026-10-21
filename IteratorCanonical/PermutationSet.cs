namespace IteratorCanonical;

public class PermutationSet<T>(IEnumerable<T> source) : IAggregate<IReadOnlyList<T>>
{
    private readonly List<T> items = new(source);

    public IIterator<IReadOnlyList<T>> CreateIterator()
        => new PermutationIterator<T>(items);
}

// Heap's algorithm
public class PermutationIterator<T> : IIterator<IReadOnlyList<T>>
{
    private readonly List<T> items;
    private readonly int[] counters;   // Heap’s algorithm counters
    private int i;
    private bool first;
    private bool done;

    public PermutationIterator(List<T> source)
    {
        items = new List<T>(source);
        counters = new int[items.Count];
        i = 0;
        first = true;
        done = items.Count == 0;
    }

    public bool HasNext()
    {
        return !done;
    }

    public IReadOnlyList<T> Next()
    {
        if (done)
        {
            throw new InvalidOperationException("No more permutations.");
        }

        if (first)
        {
            first = false;
            return new List<T>(items);
        }

        while (i < items.Count)
        {
            if (counters[i] < i)
            {
                int j;
                if (i % 2 == 0)
                {
                    j = 0;
                }
                else
                {
                    j = counters[i];
                }

                (items[i], items[j]) = (items[j], items[i]);
                counters[i] += 1;
                i = 0;

                return new List<T>(items);
            }
            counters[i] = 0;
            i += 1;
        }

        done = true;
        throw new InvalidOperationException("No more permutations.");
    }
}
