namespace DemoDomain;

public class ObsoleteMethodAttribute(string reason) : Attribute
{
    public string Reason { get; } = reason;
}
