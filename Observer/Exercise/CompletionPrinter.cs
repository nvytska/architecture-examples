namespace Observer.Exercise;

public class CompletionPrinter
{
    public void OnProgressChanged(int percentage)
    
    {
        if (percentage == 100)
        {
            Console.WriteLine($"Downolad completed: {percentage}%");

        }
    }
}