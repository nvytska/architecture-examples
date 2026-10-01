namespace OCP.Quiz;

public class TrueFalseQuestion : Question
{
    private readonly string correctAnswer;

    public TrueFalseQuestion(string prompt, string correctAnswer) : base(prompt)
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