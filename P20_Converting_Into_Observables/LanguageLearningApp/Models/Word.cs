using System;

public class Word
{
    public int Id { get; set; }
    public string Original { get; set; }      // Słowo w języku docelowym
    public string Translation { get; set; }   // Tłumaczenie
    public string Category { get; set; }      // Kategoria

    public override string ToString()
    {
        return $"{Id} | {Original} - {Translation} ({Category})";
    }
}
