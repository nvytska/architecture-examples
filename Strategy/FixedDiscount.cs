namespace Strategy;

public class FixedDiscount(decimal amount) : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal subtotal)
    {
        return Math.Max(0, subtotal - amount);
    }
}