using System.Reflection;
using CommandContracts;

var path = Path.Combine(AppContext.BaseDirectory, "UserCommands.dll");
var asm = Assembly.LoadFrom(path);

var commands = new Dictionary<string, (Type Type, MethodInfo Method)>(StringComparer.OrdinalIgnoreCase);

foreach (var type in asm.GetTypes())
{
    var command = type.GetCustomAttribute<CommandAttribute>();
    if (command is null)
        continue;

    var method = type
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
        .FirstOrDefault(m => m.GetCustomAttribute<ExecuteAttribute>() is not null);
    if (method is null)
        continue;
   commands[command.Name] = (type, method);
}

Console.WriteLine("Available commands:");
foreach (var (name, (type, method)) in commands)
{
    var parameters = string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"  {name} -> {type.Name}.{method.Name}({parameters})");
}
Console.WriteLine("ping:");
var (pingType, pingMethod) = commands["ping"];
var instance = pingMethod.IsStatic ? null : Activator.CreateInstance(pingType);
var result = pingMethod.Invoke(instance, null);
if (result is not null)
    Console.WriteLine(result);

TryRun("sum", new[] { "2", "3" });
TryRun("greet", new[] { "Natalia" });
TryRun("repeat", new[] { "hi", "3", "true" });
TryRun("sum", new[] { "abc", "3" });   
TryRun("sum", new[] { "1" });

void TryRun(string name, string[] args)
{
    try
    {
        var (type, method) = commands[name];
        var arguments = ConvertArguments(method.GetParameters(), args);
        var target = method.IsStatic ? null : Activator.CreateInstance(type);
        var output = method.Invoke(target, arguments);
        Console.WriteLine($"{name} {string.Join(" ", args)} => {output}");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"{name} {string.Join(" ", args)} => Error: {e.Message}");
    }
}

static object?[] ConvertArguments(ParameterInfo[] parameters, string[] args)
{
    if (args.Length != parameters.Length)
        throw new ArgumentException($"Expected {parameters.Length} argument(s), got {args.Length}.");
    var result = new object?[parameters.Length];
    for (var i = 0; i < parameters.Length; i++)
        result[i] = ConvertArgument(parameters[i], args[i]);
    return result;
}

static object ConvertArgument(ParameterInfo parameter, string value)
{
    var type = parameter.ParameterType;

    if (type == typeof(string))
        return value;

    if (type == typeof(int))
        return int.TryParse(value, out var number)
            ? number
            : throw new ArgumentException($"'{value}' is not a valid int for '{parameter.Name}'.");

    if (type == typeof(bool))
        return bool.TryParse(value, out var flag)
            ? flag
            : throw new ArgumentException($"'{value}' is not a valid bool for '{parameter.Name}' (use true/false).");

    throw new ArgumentException($"Unsupported parameter type {type.Name} for '{parameter.Name}'.");
}
