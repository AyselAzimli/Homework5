using System.Net;
using System.Net.NetworkInformation;

namespace Homework5
{
    public class Library
    {
        List<Book> books = new List<Book>();
        public Library()
        {
            books.Add(new Book(1, "C# Programming", "John Doe"));
            books.Add(new Book(2, "Learn Programming", "Jane Smith"));
            books.Add(new Book(3, "Become BasketballPRO", "Michael B Jordan"));
        }
        public void AddBook()
        {
            ViewBooks();
            Console.Write("Enter Book ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bookID))
            {
                Console.WriteLine("Invalid or duplicate Book ID.");
                return;
            }
            bool bookExists = false; 
            foreach (var book in books) 
            {
                if (book.BookId == bookID) 
                {
                    bookExists = true; 
                    break; 
                }
            }

            if (bookExists)
            {
                Console.WriteLine("Invalid or duplicate Book ID.");
                return;
            }
            else
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                books.Add(new Book(bookID, title, author));
                Console.WriteLine("Book added successfully.");
                ViewBooks();
            }
        }
        public void ViewBooks()
        {
            Console.WriteLine($"{"ID",-4}{"Title",-20} {"Author",-20} {"Availability",-15}");
            foreach (var book in books)
            {
                Console.WriteLine(new string('-', 60));
                Console.WriteLine($"{book.BookId,-4}{book.Title,-20} {book.Author,-20} {book.IsAvailable,-15}");
                Console.WriteLine(new string('-', 60));
            }
        }
        public void FindById()
        {
            Console.Write("Enter the ID:");
            int id = int.Parse(Console.ReadLine());
            bool IsFound=false;
            foreach (var book in books)
            {
                if (book.BookId == id)
                {
                    IsFound = true;
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine($"{"ID",-4}{"Title",-20} {"Author",-10}");
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine($"{book.BookId,-4}{book.Title,-20} {book.Author,-10}");
                    Console.WriteLine(new string('-', 60));
                }
            }
            if (!IsFound)
            {
                Console.WriteLine("Book was not found");
            }
        }
        public void BorrowBook()
        {
            bool found = false;
            Console.Write("\nEnter Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (var book in books)
                {
                    if (book.BookId == id)
                    {
                        if (book.IsAvailable)
                        {
                            book.IsAvailable = false;
                            Console.WriteLine($"Book {book.Title} has been borrowed.");
                        }
                        else
                        {
                            Console.WriteLine("Book is already borrowed.");
                        }
                        return;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Book with this ID does not exists");
                }
                Console.WriteLine("Book not found.");
            }
        }
        public void ReturnBook()
        {
            Console.Write("\nEnter Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (var book in books)
                {
                    if (book.BookId == id)
                    {
                        if (book.IsAvailable)
                        {
                            Console.WriteLine("Book is already available");
                        }
                        else
                        {
                            book.IsAvailable = true;
                            Console.WriteLine("Book is returned");
                            Console.WriteLine();
                            Console.WriteLine(new string('-', 60));
                            Console.WriteLine($"{"ID",-4}{"Title",-20} {"Author",-20} {"Availability",-15}");
                            Console.WriteLine(new string('-', 60));
                            Console.WriteLine($"{book.BookId,-4}{book.Title,-20} {book.Author,-20} {book.IsAvailable,-15}");
                            Console.WriteLine(new string('-', 60));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("invalid Id");
            }
        }
        public void RemoveBook()
        {
            Console.Write("Enter ID");
            bool found = false;
            int id=int.Parse(Console.ReadLine());
            foreach (var book in books)
            {
                if (book.BookId == id)
                {
                    found = true;
                    books.Remove(book);
                    ViewBooks();
                    return;
                }
            }
            if (!found)
            {
                Console.WriteLine("Book with this ID does not exists");
            }
        }
        ////Additional features :)
        public void SearchPartly()
        {
            ViewBooks();
            Console.Write("Enter Title:");
            string title=Console.ReadLine();
            Console.WriteLine("Enter Author:");
            string author=Console.ReadLine();
            foreach(var book in books)
            {
                if(book.Title.Contains(title,StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine($"{book.BookId,-4}{book.Title,-20} {book.Author,-20} {book.IsAvailable,-15}");
                    return;
                }
            }
        }
        public void ViewOnlyAvailableBooks()
        {
            Console.WriteLine($"{"ID",-4}{"Title",-20} {"Author",-20} {"Availability",-15}");

            foreach (var book in books)
            {
                if(book.IsAvailable)
                {
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine($"{book.BookId,-4}{book.Title,-20} {book.Author,-20} {book.IsAvailable,-15}");
                    Console.WriteLine(new string('-', 60));
                }
            }
        }
        public void CountAvailableBorrowedBooks()
        {
            int CountOfAvailableBooks = 0;
            int CountOfBorrowedBooks = 0;
            foreach (var book in books)
            {
                if (book.IsAvailable)
                {
                    CountOfAvailableBooks += 1;
                }
                else
                {
                    CountOfBorrowedBooks += 1;
                }
            }
            Console.WriteLine($"Available bookcount:{CountOfAvailableBooks}   Borrowed bookcount:{CountOfBorrowedBooks}");
        }
    }
}
