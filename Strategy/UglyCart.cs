namespace Strategy;

public class UglyCart
{
    public decimal CalculateTotal(decimal subtotal, string discountType)
    {
        if (discountType == "percent")
        {
            return subtotal * 0.9m; 
        }
        else if (discountType == "fixed")
        {
            return subtotal - 20m; 
        }
        else if (discountType == "none")
        {
            return subtotal;
        }
        else
        {
            throw new ArgumentException("Unknown discount type");
        }
    }
}