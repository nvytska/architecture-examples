namespace DemoDomain;

public class User
{
    private readonly Guid id;
    public string Name { get; set; }
    public int Age { get; private set; }

    public User()
    {
        id = Guid.NewGuid();
        Name = "Anonymous";
    }

    public User(string name, int age)
    {
        id = Guid.NewGuid();
        Name = name;
        Age = age;
    }

    public void Greet() => Console.WriteLine($"Hello, {Name}!");
    
    [ObsoleteMethod("Use Greet() instead")]
    public void SayHello() => Console.WriteLine($"Hello, {Name}!");
    
    public int GetBirthYear() => DateTime.Now.Year - Age;

    private void SecretMethod() => Console.WriteLine("This is private");

    public override string ToString() => $"User: {Name} ({Age}) - {id}";
}