namespace IteratorNative;
using System;
using System.Collections;
using System.Collections.Generic;

public class PermutationSet<T>(IEnumerable<T> source) : IEnumerable<IReadOnlyList<T>>
{
    private readonly List<T> items = [..source];

    // You can drop interface and this two methods and expose GeneratePermutations() as public to make it even simpler
    public IEnumerator<IReadOnlyList<T>> GetEnumerator()
    {
        return GeneratePermutations().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GeneratePermutations().GetEnumerator();
    }

    public IEnumerable<IReadOnlyList<T>> GeneratePermutations()
    {
        var n = items.Count;
        if (n == 0)
        {
            yield break;
        }

        var result = new List<T>(items);
        var counters = new int[n];

        yield return new List<T>(result);

        int i = 0;
        while (i < n)
        {
            if (counters[i] < i)
            {
                int j = (i % 2 == 0) ? 0 : counters[i];
                (result[i], result[j]) = (result[j], result[i]);

                yield return new List<T>(result);

                counters[i]++;
                i = 0;
            }
            else
            {
                counters[i] = 0;
                i++;
            }
        }
    }
}