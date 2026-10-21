public class UglyInvoice
{
    public string Number { get; }
    public DateTime Date { get; }
    public string Customer { get; }
    public decimal Subtotal { get; }
    public decimal Tax { get; }
    public decimal Discount { get; }
    public string Currency { get; }
    public string Notes { get; }

    public UglyInvoice(
        string number,
        DateTime date,
        string customer,
        decimal subtotal,
        decimal tax = 0m,
        decimal discount = 0m,
        string currency = "USD",
        string notes = "")
    {
        if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Number required");
        if (string.IsNullOrWhiteSpace(customer)) throw new ArgumentException("Customer required");
        if (subtotal < 0) throw new ArgumentException("Subtotal must be non-negative");

        Number = number;
        Date = date;
        Customer = customer;
        Subtotal = subtotal;
        Tax = tax;
        Discount = discount;
        Currency = currency;
        Notes = notes;
    }
}

// Usage (gross):
