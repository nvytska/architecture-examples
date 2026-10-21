namespace Observer.Exercise;

public delegate void ProgressChangedHandler(int percentage);

public class EventDownloader
{
    public event ProgressChangedHandler? ProgressChanged;

    private int progress;

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress)
        {
            return;
        }

        progress = percentage;

        ProgressChanged?.Invoke(percentage);
    }
}