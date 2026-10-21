namespace Strategy;

public class CartFunctional(Func<decimal, decimal> discountApplier)
{
    public decimal CalculateTotal(decimal subtotal)
    {
        return discountApplier(subtotal);
    }
}