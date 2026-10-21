namespace IteratorCanonical;


// Iterator interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

