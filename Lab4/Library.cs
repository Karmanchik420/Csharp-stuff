namespace LibrarySystem
{
    internal class Library
    {
        private List<Book> _books;
        private List<User> _users;

        public Library()
        {
            _books = new List<Book>();
            _users = new List<User>();
        }
        private Book FindBook(int id)
        {
            foreach (var book in _books)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }
        private User FindUser(int id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }
        public void AddBook(Book book)
        {
            if (FindBook(book.Id) != null)
            {
                Console.WriteLine($"Error: a book with id {book.Id} is already in the library.");
                return;
            }
            _books.Add(book);
        }
        public void AddUser(User user)
        {
            if (FindUser(user.Id) != null)
            {
                Console.WriteLine($"Error: a user with id {user.Id} is already registered.");
                return;
            }
            _users.Add(user);
        }
        public void RentBook(int bookId, int userId)
        {
            Book book = FindBook(bookId);
            User user = FindUser(userId);
            if (book == null)
            {
                Console.WriteLine($"Error: there is no book with id {bookId}.");
                return;
            }
            if (user == null)
            {
                Console.WriteLine($"Error: there is no user with id {userId}.");
                return;
            }
            if (!book.IsAvailable)
            {
                Console.WriteLine($"Error: \"{book.Title}\" is already rented.");
                return;
            }
            book.RentBook();
            user.AddBook(book);
            Console.WriteLine($"Rented: \"{book.Title}\" -> {user.Name}.");
        }
        public void ReturnBook(int bookId, int userId)
        {
            Book book = FindBook(bookId);
            User user = FindUser(userId);
            if (book == null)
            {
                Console.WriteLine($"Error: there is no book with id {bookId}.");
                return;
            }
            if (user == null)
            {
                Console.WriteLine($"Error: there is no user with id {userId}.");
                return;
            }
            if (book.IsAvailable)
            {
                Console.WriteLine($"Error: \"{book.Title}\" is not rented.");
                return;
            }
            if (!user.HasBook(book))
            {
                Console.WriteLine($"Error: {user.Name} has not borrowed \"{book.Title}\".");
                return;
            }
            book.ReturnBook();
            user.RemoveBook(book);
            Console.WriteLine($"Returned: \"{book.Title}\" <- {user.Name}.");
        }
        public void ShowBooks()
        {
            Console.WriteLine("\n=== All books ===");
            foreach (var book in _books)
            {
                Console.WriteLine($"\n{book}\n");
            }
        }
        public void ShowUsers()
        {
            Console.WriteLine("\n=== Users ===");
            foreach (var user in _users)
            {
                Console.WriteLine($"\n{user}\n");
                user.ShowBooks();
            }
        }
        public void ShowAvailableBooks()
        {
            Console.WriteLine("\n=== Available books ===");
            foreach (var book in _books)
            {
                if (book.IsAvailable)
                    Console.WriteLine($"\n{book}\n");
            }
        }
        public void ShowRentedBooks()
        {
            Console.WriteLine("\n=== Rented books ===");
            foreach (var book in _books)
            {
                if (!book.IsAvailable)
                    Console.WriteLine($"\n{book}\n");
            }
        }
    }
}
