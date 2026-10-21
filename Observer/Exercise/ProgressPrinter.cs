namespace Observer.Exercise;

public class ProgressPrinter
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}