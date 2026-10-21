namespace Observer.Exercise;

public class CompletionDisplay : IEventListener
{
    public void Notify(int  percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Complete: " + percentage);

        }
    }
}