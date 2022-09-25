using System;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Animal Farm", 2003, "George Orwell");
            Book book2 = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book book3 = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(book1, book2, book3);
        }
    }
}
