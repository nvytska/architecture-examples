public class Invoice
{
    public string Number { get; internal set; } = "";
    public DateTime Date { get; internal set; }
    public string Customer { get; internal set; } = "";
    public decimal Subtotal { get; internal set; }
    public decimal Tax { get; internal set; }
    public decimal Discount { get; internal set; }
    public string Currency { get; internal set; } = "USD";
    public string Notes { get; internal set; } = "";
}

// Step interfaces
public interface IStart
{
    ISetDate Number(string value);
}

public interface ISetDate
{
    ISetCustomer Date(DateTime value);
    ISetCustomer Today();
}

public interface ISetCustomer
{
    ISetSubtotal Customer(string name);
}

public interface ISetSubtotal
{
    IOptional Subtotal(decimal value);
}

public interface IOptional
{
    IOptional Tax(decimal value);
    IOptional Discount(decimal value);
    IOptional Currency(string code);
    IOptional Notes(string text);
    IBuild Done();
}

public interface IBuild
{
    Invoice Build();
}