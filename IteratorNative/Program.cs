using IteratorNative;

var set = new PermutationSet<char>(['A', 'B', 'C']);

foreach (var p in set)
{
    Console.WriteLine(string.Join("", p));
    break;
}

// or even simpler
foreach (var p in set.GeneratePermutations())
{
    Console.WriteLine(string.Join("", p));
}