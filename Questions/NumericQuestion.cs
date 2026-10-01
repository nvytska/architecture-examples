using System.Globalization;

namespace OCP.Quiz;

public class NumericQuestion : Question
{
    private double expectedAnswer;
    private double tolerance;

    public NumericQuestion(string prompt, double expectedAnswer, double tolerance) : base(prompt)
    {
        this.expectedAnswer = expectedAnswer;
        this.tolerance = tolerance;
    }

    public override void Ask()
    {
        Console.WriteLine("Enter a number:");
    }

    public override bool IsCorrect(string answer)
    {
        if (!double.TryParse(answer, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
        {
            return false;
        }
        return Math.Abs(value - expectedAnswer) <= tolerance;
    }
}