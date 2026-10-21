namespace Strategy;

public class NoDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal subtotal)
    {
        return subtotal;
    }
}