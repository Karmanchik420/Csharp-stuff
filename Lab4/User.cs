namespace LibrarySystem
{
    internal class User
    {
        private int _id;
        private string _name;
        private List<Book> _books;

        public int Id => _id;
        public string Name => _name;

        public User(int id, string name)
        {
            _id = id;
            _name = name;
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
        public bool HasBook(Book book)
        {
            return _books.Contains(book);
        }
        public void ShowBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("   No books borrowed.");
                return;
            }
            foreach (var book in _books)
            {
                Console.WriteLine($"   [{book.Id}] \"{book.Title}\" - {book.Author}");
            }
        }
    }
}
