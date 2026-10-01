namespace OCP.Quiz;
public abstract class Question
{
    protected Question(string prompt)
    {
        Prompt = prompt;
    }

    public string Prompt { get; }

    public abstract void Ask();

    public abstract bool IsCorrect(string answer);
}