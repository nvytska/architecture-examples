namespace OCP.Quiz;

public class TextQuestion: Question
{
    private readonly string correctAnswer;

    public TextQuestion(string prompt, string correctAnswer) : base(prompt)
    {
        this.correctAnswer = correctAnswer;
    }
    public override void Ask()
    {
        Console.WriteLine("Type your answer:");
    }
    public override bool IsCorrect(string answer)
    {
        return answer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);
    }
}