namespace MementoSimple;

using System;

public class TextEditor
{
    private string _text = "";
    
    public void Type(string text)
    {
        _text += text;
        Console.WriteLine($"Current text: {_text}");
    }

    public IMemento Save()
    {
        Console.WriteLine("Saving current state...");
        return new EditorMemento(_text);
    }

    public void Restore(IMemento memento)
    {
        if (memento is not EditorMemento saved)
        {
            throw new InvalidOperationException("Invalid memento type");
        }

        _text = saved.State;
        Console.WriteLine($"Restored text: {_text}");
    }
    
    private class EditorMemento : IMemento
    {
        internal string State { get; }

        internal EditorMemento(string state)
        {
            State = state;
        }
    }
}

