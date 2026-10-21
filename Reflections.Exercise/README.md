# Reflection: command framework

Use .NET 10. This folder contains the compiled exercise libraries:

- Source for both attributes is available in [`Reflections.Contracts`](../Reflections.Contracts).
- `Command.Contracts.dll` defines `CommandAttribute` and `ExecuteAttribute` in the `CommandContracts` namespace.
- `UserCommands.dll` contains classes to inspect and execute.

Reference `Command.Contracts.dll` in your project and load `UserCommands.dll` using reflection. Keep both DLLs available when running your application. Use the supplied attribute types instead of declaring new copies.

Work in groups of three. Build a console runner that discovers classes marked `[Command]`, reads the command name from `CommandAttribute.Name`, and finds their methods marked `[Execute]`. Start with parameterless calls, then support positional `string`, `int`, and `bool` arguments. Handle invalid input and execution errors without terminating the loop, and add `exit`.

Inspect the metadata rather than assuming class names or public method names identify executable commands. Divide the work into discovery, argument conversion, and execution with the input loop. Each member should be ready to show their work during the session.

Optional: generate `help` from command names and parameter information.
