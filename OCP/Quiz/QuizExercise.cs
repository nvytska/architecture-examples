namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new Question[]
        {
            new TextQuestion(
                "What is the capital of France?",
                "Paris"),
            new MultipleChoiceQuestion(
                "Which number is prime?",
                new[] { "4", "7", "9" },
                2),
            new TextQuestion(
                "Which C# keyword creates a new object?",
                "new"),
            new NumericQuestion(
                "What is the year Nataliia Vytska Bachelor graduation?",
                2028,
                2),
            new TrueFalseQuestion("Is the KSE in Ukraine(T/F)", "T")
        };

        new QuizRunner().Run(questions);
    }
}