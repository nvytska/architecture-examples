namespace Observer.Exercise;

public class ProgressDisplay : IEventListener
{
    public void Notify(int percentage)
    {
        Console.WriteLine("Progress: " + percentage);
    }
}