using LSP.Tickets;

//new TicketCancellationExercise().Run();
var c = new Customer();
c.Calculate = amount => 5;
c.Calculate = CalculateDiscount;

int CalculateDiscount(int x)
{
    return (int)(x * 0.8);
}

public class Customer
{
    public Calculate Calculate { get; set; }
}

public delegate int Calculate(int  amount);

