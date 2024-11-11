using System;

public class WordObserver : IObserver<Word>
{
    public void OnCompleted()
    {
        Console.WriteLine("No more words to observe.");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Error observed: {error.Message}");
    }

    public void OnNext(Word word)
    {
        Console.WriteLine($"Observed change: Word '{word.Original}' was added or removed.");
    }
}
