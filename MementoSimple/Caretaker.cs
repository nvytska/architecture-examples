namespace MementoSimple;

public class Caretaker(TextEditor editor)
{
    private readonly Stack<IMemento> history = new();

    public void Backup()
    {
        Console.WriteLine("Saver: requesting backup...");
        history.Push(editor.Save());
    }

    /// <summary>
    /// Example of logic that can be handled here, might be save scheduling as well
    /// </summary>
    public void Undo()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("Saver: nothing to undo.");
            return;
        }

        Console.WriteLine("Saver: restoring last state...");
        editor.Restore(history.Pop());
    }
}