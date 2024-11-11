using System;

class Program
{
    static void Main()
    {
        var wordService = new WordService();
        var observer = new WordObserver();

        // Subskrybujemy observer na strumień zdarzeń w wordService
        wordService.Subscribe(observer);

        while (true)
        {
            Console.WriteLine("--- Menu ---");
            Console.WriteLine("1. Dodaj nowe słowo");
            Console.WriteLine("2. Usuń słowo");
            Console.WriteLine("3. Wyświetl wszystkie słowa");
            Console.WriteLine("4. Zakończ działanie");
            Console.Write("Wybierz opcję: ");
            
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Console.Write("Podaj słowo: ");
                    var original = Console.ReadLine();
                    Console.Write("Podaj tłumaczenie: ");
                    var translation = Console.ReadLine();
                    Console.Write("Podaj kategorię: ");
                    var category = Console.ReadLine();
                    
                    var word = new Word
                    {
                        Original = original,
                        Translation = translation,
                        Category = category
                    };
                    
                    wordService.AddWord(word);
                    break;

                case "2":
                    Console.Write("Podaj ID słowa do usunięcia: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        wordService.RemoveWord(id);
                    }
                    break;

                case "3":
                    wordService.DisplayAllWords();
                    break;

                case "4":
                    wordService.SaveWords();
                    Console.WriteLine("Zamykanie aplikacji...");
                    return;

                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }
    }
}
