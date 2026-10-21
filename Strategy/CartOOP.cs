namespace Strategy;

public class CartOOP(IDiscountStrategy discount)
{
    public decimal CalculateTotal(decimal subtotal)
    {
        return discount.ApplyDiscount(subtotal);
    }
}