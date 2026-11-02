namespace LibrarySystem
{
    internal class Book
    {
        private int _id;
        private string _title;
        private string _author;
        private bool _isAvailable;

        public int Id => _id;
        public string Title => _title;
        public string Author => _author;
        public bool IsAvailable => _isAvailable;

        public Book(int id, string title, string author)
        {
            _id = id;
            _title = title;
            _author = author;
            _isAvailable = true;
        }
        public override string ToString()
        {
            return $"[{Id}] \"{Title}\" - {Author} ({(_isAvailable ? "available" : "rented")})";
        }
        public void RentBook()
        {
            _isAvailable = false;
        }
        public void ReturnBook()
        {
            _isAvailable = true;
        }
    }
}
