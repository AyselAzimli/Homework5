namespace Homework5
{
    public class Book
    {

        public Book(int bookId, string title, string author)
        {
            BookId= bookId;
            Title = title;
            Author = author;
        }
        
        public int Id { get; set; }
        public int BookId { get; }
        public string Title {  get; }
        public string Author { get; } 
        public bool IsAvailable { get; set; } = true;

    }
}
