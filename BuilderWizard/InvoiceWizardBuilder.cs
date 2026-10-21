public class InvoiceWizardBuilder : IStart, ISetDate, ISetCustomer, ISetSubtotal, IOptional, IBuild
{
    private readonly Invoice invoice = new Invoice();

    private InvoiceWizardBuilder() { }

    public static IStart Create() { return new InvoiceWizardBuilder(); }

    public ISetDate Number(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Number required");
        }
        invoice.Number = value;
        return this;
    }

    public ISetCustomer Date(DateTime value)
    {
        invoice.Date = value;
        return this;
    }

    public ISetCustomer Today()
    {
        invoice.Date = DateTime.Today;
        return this;
    }

    public ISetSubtotal Customer(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Customer required");
        }
        invoice.Customer = name;
        return this;
    }

    public IOptional Subtotal(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Subtotal must be non-negative");
        }
        invoice.Subtotal = value;
        return this;
    }

    public IOptional Tax(decimal value)
    {
        invoice.Tax = value;
        return this;
    }

    public IOptional Discount(decimal value)
    {
        invoice.Discount = value;
        return this;
    }

    public IOptional Currency(string code)
    {
        invoice.Currency = code;
        return this;
    }

    public IOptional Notes(string text)
    {
        invoice.Notes = text;
        return this;
    }

    public IBuild Done() { return this; }

    public Invoice Build()
    {
        if (string.IsNullOrWhiteSpace(invoice.Number))
        {
            throw new InvalidOperationException("Number required");
        }
        if (string.IsNullOrWhiteSpace(invoice.Customer))
        {
            throw new InvalidOperationException("Customer required");
        }
        if (invoice.Subtotal < 0)
        {
            throw new InvalidOperationException("Subtotal must be non-negative");
        }
        if (invoice.Date == default)
        {
            invoice.Date = DateTime.Today;
        }
        return invoice;
    }
}