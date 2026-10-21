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

public class InvoiceBuilder
{
    private readonly Invoice invoice = new Invoice();

    public InvoiceBuilder Number(string value)
    {
        invoice.Number = value;
        return this;
    }

    public InvoiceBuilder Date(DateTime value)
    {
        invoice.Date = value;
        return this;
    }

    public InvoiceBuilder Customer(string value)
    {
        invoice.Customer = value;
        return this;
    }

    public InvoiceBuilder Subtotal(decimal value)
    {
        invoice.Subtotal = value;
        return this;
    }

    public InvoiceBuilder Tax(decimal value)
    {
        invoice.Tax = value;
        return this;
    }

    public InvoiceBuilder Discount(decimal value)
    {
        invoice.Discount = value;
        return this;
    }

    public InvoiceBuilder Currency(string value)
    {
        invoice.Currency = value;
        return this;
    }

    public InvoiceBuilder Notes(string value)
    {
        invoice.Notes = value;
        return this;
    }

    public Invoice Build()
    {
        if (string.IsNullOrWhiteSpace(invoice.Number)) throw new InvalidOperationException("Number required");
        if (string.IsNullOrWhiteSpace(invoice.Customer)) throw new InvalidOperationException("Customer required");
        if (invoice.Subtotal < 0) throw new InvalidOperationException("Subtotal must be non-negative");
        if (invoice.Date == default) invoice.Date = DateTime.Today;
        return invoice;
    }
}