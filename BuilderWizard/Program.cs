// Usage (with enforced order):
var inv3 = InvoiceWizardBuilder.Create()
    .Number("INV-3001")
    .Today()
    .Customer("Acme")
    .Subtotal(250m)
    .Tax(25m)
    .Currency("EUR")
    .Notes("Pay within 10 days")
    .Done()
    .Build();
    