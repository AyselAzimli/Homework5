namespace Homework5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            do
            {
                Console.WriteLine("[1] Add a book");
                Console.WriteLine("[2] View all books");
                Console.WriteLine("[3] Find a book by ID ");
                Console.WriteLine("[4] Borrow a book");
                Console.WriteLine("[5] Return a book");
                Console.WriteLine("[6] Remove a book");
                Console.WriteLine("[7] View only available books");
                Console.WriteLine("[8] Count available and borrowed books");
                Console.WriteLine("[exit] Exit");

                Console.Write("Enter the command:");
                string command = Console.ReadLine();

                switch(command)
                {
                    case "1":
                        library.AddBook();
                        break;
                    case "2":
                        library.ViewBooks();
                        break;
                    case "3":
                        library.FindById();
                        break;
                    case "4":
                        library.BorrowBook();
                        break;
                    case "5":
                        library.ReturnBook();
                        break;
                    case "6":
                        library.RemoveBook();
                        break;
                    case "7":
                        library.ViewOnlyAvailableBooks();
                        break;
                    case "8":
                        library.CountAvailableBorrowedBooks();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("That is not correct command");
                        break;
                }
            } while (true);

        }

    }
}
