var inv1 = new UglyInvoice("INV-1001", DateTime.Today, "Acme", 100m, tax: 20m, notes: "Net 30");

// Usage (human-readable):
var inv2 = new InvoiceBuilder() 
    .Number("INV-2001")
    .Date(DateTime.Today)
    .Customer("Acme")
    .Subtotal(100m)
    .Tax(20m)
    .Notes("Net 30")
    .Build();
    
