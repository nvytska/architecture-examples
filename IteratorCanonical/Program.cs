using IteratorCanonical;

var set = new PermutationSet<char>(['A', 'B', 'C']);
var iterator = set.CreateIterator();

while (iterator.HasNext())
{
    var p = iterator.Next();
    Console.WriteLine(string.Join("", p));
}