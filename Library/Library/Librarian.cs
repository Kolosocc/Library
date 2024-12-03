using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    internal class Librarian : IEnumerator<Book>
    {
        private Library library;
        private int current = -1;

        public Librarian(Library library)
        {
            this.library = library;
        }

        public bool MoveNext()
        {
            if (current < library.Count - 1)
            {
                current++;
                return true;
            }
            return false;
        }

        public void Reset() => current = -1;

        public void Dispose()
        {
        }

        public Book Current => library[current];

        object IEnumerator.Current => Current;
    }
}
