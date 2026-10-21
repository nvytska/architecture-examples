namespace Strategy;

public class PercentageDiscount(decimal rate) : IDiscountStrategy
{

    public decimal ApplyDiscount(decimal subtotal)
    {
        return subtotal * (1 - rate);
    }
}