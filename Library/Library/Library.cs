using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    internal class Library : IEnumerable<Book>
    {
        private Book[] books = new Book[0];
        private int count;

        public Book this[int index]
        {
            get => books[index];
            set => books[index] = value;
        }

        public int Count => count;

        public void Add(Book book)
        {
            if (count == books.Length)
            {
                Array.Resize(ref books, books.Length + 1);
            }
            books[count] = book;
            count++;
        }

        public void Remove(string title)
        {
            int index = Array.FindIndex(books, 0, count, b => b?.Title == title);
            if (index >= 0)
            {
                for (int i = index; i < count - 1; i++)
                {
                    books[i] = books[i + 1];
                }
                books[--count] = null;
            }
        }


        public IEnumerable<Book> SearchByTitle(string title)
        {
            foreach (var book in books)
            {
                if (book?.Title?.Contains(title, StringComparison.OrdinalIgnoreCase) == true)
                    yield return book;
            }
        }

        public IEnumerable<Book> SearchByAuthor(string author)
        {
            foreach (var book in books)
            {
                if (book?.Author?.Contains(author, StringComparison.OrdinalIgnoreCase) == true)
                    yield return book;
            }
        }

        public IEnumerable<Book> SearchByYear(int year)
        {
            foreach (var book in books)
            {
                if (book?.Year == year)
                    yield return book;
            }
        }

        public IEnumerator<Book> GetEnumerator() => new Librarian(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
