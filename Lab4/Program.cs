namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook(new Book(1, "The Hobbit", "J.R.R. Tolkien"));
            library.AddBook(new Book(2, "1984", "George Orwell"));
            library.AddBook(new Book(3, "Dune", "Frank Herbert"));
            library.AddBook(new Book(4, "Pride and Prejudice", "Jane Austen"));
            library.AddBook(new Book(5, "The Great Gatsby", "F. Scott Fitzgerald"));

            library.AddUser(new User(1, "Olena"));
            library.AddUser(new User(2, "Andrii"));
            library.AddUser(new User(3, "Maria"));


            library.ShowAvailableBooks();
            library.RentBook(1, 1);
            library.RentBook(1, 2);
            library.ShowAvailableBooks();
            library.ShowRentedBooks();
            library.ShowUsers();
            library.ReturnBook(1, 1);
            library.ShowAvailableBooks();

            Console.WriteLine("=== Errors examples: ===");
            library.RentBook(99, 1);

            library.RentBook(2, 99);

            library.ReturnBook(3, 1);

            library.RentBook(2, 2);      
            library.ReturnBook(2, 3);    

            library.AddBook(new Book(1, "Another Book", "Someone"));
            library.AddUser(new User(1, "Another User"));

            library.ShowBooks();
            library.ShowUsers();
        }
    }
}
