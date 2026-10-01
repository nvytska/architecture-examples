namespace OCP.Quiz;

public class MultipleChoiceQuestion : Question
{
    private readonly string[] options;
    private readonly int correctOptionNumber;

    public MultipleChoiceQuestion(string prompt, string[] options, int correctOptionNumber) : base(prompt)
    {
        this.options = options;
        this.correctOptionNumber = correctOptionNumber;
    }

    public override void Ask()
    {
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.WriteLine("Enter the option number:");
    }
    public override bool IsCorrect(string answer)
    {
        return int.TryParse(answer, out var number) && number == correctOptionNumber;
    }
}