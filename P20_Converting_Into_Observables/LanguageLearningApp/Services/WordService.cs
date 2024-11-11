using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;

public class WordService : IObservable<Word>
{
    private readonly string _filePath = "slownictwo.txt";
    private readonly Subject<Word> _wordStream = new Subject<Word>();
    private List<Word> _words;

    public WordService()
    {
        _words = LoadWords();
    }

    public IDisposable Subscribe(IObserver<Word> observer)
    {
        return _wordStream.Subscribe(observer);
    }

    public void AddWord(Word word)
    {
        word.Id = GenerateId();
        _words.Add(word);
        _wordStream.OnNext(word); // Emitujemy zdarzenie dodania słowa
    }

    public void RemoveWord(int id)
    {
        var word = _words.FirstOrDefault(w => w.Id == id);
        if (word != null)
        {
            _words.Remove(word);
            _wordStream.OnNext(word); // Emitujemy zdarzenie usunięcia słowa
        }
        else
        {
            Console.WriteLine("Nie znaleziono słowa o podanym ID.");
        }
    }

    public void DisplayAllWords()
    {
        foreach (var word in _words)
        {
            Console.WriteLine(word);
        }
    }

    public void SaveWords()
    {
        using (var writer = new StreamWriter(_filePath))
        {
            foreach (var word in _words)
            {
                writer.WriteLine($"{word.Id}|{word.Original}|{word.Translation}|{word.Category}");
            }
        }
    }

    public int GenerateId()
    {
        return _words.Count == 0 ? 1 : _words.Max(w => w.Id) + 1;
    }

    private List<Word> LoadWords()
    {
        var words = new List<Word>();
        if (File.Exists(_filePath))
        {
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 4 &&
                    int.TryParse(parts[0], out int id))
                {
                    words.Add(new Word
                    {
                        Id = id,
                        Original = parts[1],
                        Translation = parts[2],
                        Category = parts[3]
                    });
                }
            }
        }
        return words;
    }
}
