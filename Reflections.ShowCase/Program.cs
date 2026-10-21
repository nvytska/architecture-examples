using System.Reflection;
using DemoDomain;

// 1. Load assembly
//    Option A: current assembly (if type is defined in same project)
var asm = Assembly.GetExecutingAssembly();

//    Option B: by name
//    Assembly asm = Assembly.Load("DemoDomain");

//    Option C: from file
//    Assembly asm = Assembly.LoadFrom("DemoDomain.dll");

// 2. List all types
Console.WriteLine("=== Types in assembly ===");
foreach (var t in asm.GetTypes())
{
    Console.WriteLine(t.FullName);
}

// 3. Get specific type
var userType = typeof(User);
// or: Type userType = asm.GetType("DemoDomain.User")!;

// 4. Inspect constructors
Console.WriteLine("\n=== Constructors ===");
foreach (var ctor in userType.GetConstructors())
{
    var paramList = string.Join(", ", ctor.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{userType.Name}({paramList})");
}

// 5. Inspect properties
Console.WriteLine("\n=== Properties ===");
foreach (var prop in userType.GetProperties())
{
    Console.WriteLine($"{prop.PropertyType.Name} {prop.Name} (CanWrite: {prop.CanWrite})");
}

// 6. Inspect methods
Console.WriteLine("\n=== Methods ===");
foreach (var m in userType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
{
    var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
}

// 7. Inspect attributes
Console.WriteLine("\n=== Attributes ===");
foreach (var attr in userType.GetCustomAttributes())
{
    Console.WriteLine(attr.GetType().Name);
}

// 8. Create instance dynamically
Console.WriteLine("\n=== Create Instance ===");
var instance = Activator.CreateInstance(userType, new object[] { "Alice", 25 })!;
Console.WriteLine(instance);

// 9. Invoke method
Console.WriteLine("\n=== Invoke Method ===");
var greetMethod = userType.GetMethod("Greet");
greetMethod!.Invoke(instance, null);

// 9. Check attributed methods
Console.WriteLine("\n=== Methods with [ObsoleteMethodAttribute] ===");
var executeMethods = userType               
    .GetMethods(BindingFlags.Public | BindingFlags.NonPublic 
        | BindingFlags.Instance | BindingFlags.Static)
    .Where(m => m.GetCustomAttribute(typeof(ObsoleteMethodAttribute)) != null);

foreach (var m in executeMethods)
{
    Console.WriteLine($"Method: {m.Name}");
}