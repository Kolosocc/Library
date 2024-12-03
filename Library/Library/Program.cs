using LibraryNamespace;

internal class Program
{
    private static void Main(string[] args)
    {
        Library library = new Library();


        library.Add(new Book { Title = "1984", Author = "Джордж Оруэлл", Year = 1949 });
        library.Add(new Book { Title = "О дивный новый мир", Author = "Олдос Хаксли", Year = 1932 });
        library.Add(new Book { Title = "451 градус по Фаренгейту", Author = "Рэй Брэдбери", Year = 1953 });

        Console.WriteLine("Все книги в библиотеке:");
        foreach (var book in library)
        {
            Console.WriteLine($"- {book.Title} ({book.Author}, {book.Year})");
        }


        Console.WriteLine("\nРезультаты поиска по названию '1984':");
        foreach (var book in library.SearchByTitle("1984"))
        {
            Console.WriteLine($"- {book.Title} ({book.Author}, {book.Year})");
        }


        library.Remove("О дивный новый мир");
        Console.WriteLine("\nБиблиотека после удаления книги 'О дивный новый мир':");
        foreach (var book in library)
        {
            Console.WriteLine($"- {book.Title} ({book.Author}, {book.Year})");
        }


        Console.WriteLine("\nРезультаты поиска по автору 'Рэй':");
        foreach (var book in library.SearchByAuthor("Рэй"))
        {
            Console.WriteLine($"- {book.Title} ({book.Author}, {book.Year})");
        }


        Console.WriteLine("\nРезультаты поиска по году 1949:");
        foreach (var book in library.SearchByYear(1949))
        {
            Console.WriteLine($"- {book.Title} ({book.Author}, {book.Year})");
        }
    }
}
