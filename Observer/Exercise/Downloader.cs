namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class Downloader
{
    private readonly List<IEventListener> _listeners = new();
    private int progress;

    public void Subscribe(IEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void Unsubscribe(IEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress)
        {
            return;
        }

        progress = percentage;

        foreach (var listener in _listeners)
        {
            listener.Notify(percentage);
        }
    }
}
