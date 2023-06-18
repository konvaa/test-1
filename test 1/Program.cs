using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    // List<Book> books = new List<Book>();
    static int counter = 0;
    static string available;
    private static void Main(string[] args)
    {

        List<Book> books = new List<Book>();
        Console.WriteLine("Welcome to a library");
        bool library = true;
        while (library)
        {
            Console.WriteLine("What you want to do?");
            Console.WriteLine("A - Add new book,  S - search, C - checkout, E - exit, L - list all books");
            string userinput = Console.ReadLine();
            userinput = userinput.ToLower();
            string request;
            switch (userinput)
            {
                case "a":

                    Book book = new Book();
                    book.NewBook();
                    books.Add(book);

                    break;
                case "l":
                    Console.WriteLine("List of existing books:");
                    foreach (Book book1 in books)
                    {
                        if (book1.availability)
                        {
                            available = "Yes";
                        }
                        else { available = "no"; }
                        Console.WriteLine("ID: " + book1.ID + " Title: " + book1.titleName + "  Author: " + book1.author + " Year of publication: " + book1.year + "  Is available?: " + available);
                    }
                    break;
                case "e":
                    Environment.Exit(0);
                    break;
                case "s":
                    Console.WriteLine("What book you want search? Please type a name or part, author or year: ");
                    request = Console.ReadLine();
                    Console.WriteLine("Searching....");
                    foreach (Book book1 in books)
                    {
                        if (book1.availability)
                        {
                            available = "Yes";
                        }
                        else { available = "no"; }
                        if ((book1.titleName.IndexOf(request, StringComparison.OrdinalIgnoreCase) >= 0) || (book1.author.IndexOf(request, StringComparison.OrdinalIgnoreCase) >= 0) || (book1.year.ToString().IndexOf(request, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            Console.WriteLine("ID: " + book1.ID + " Title: " + book1.titleName + " Author: " + book1.author + " Year: " + book1.year + " Available: " + available);
                        }
                    }
                    break;
                case "c":
                    Console.WriteLine("What book you want to check out? Please type exact name : ");
                    request = Console.ReadLine();
                    Console.WriteLine("Searching....");
                    foreach (Book book1 in books)
                    {
                        if (book1.availability)
                        {
                            available = "Yes";
                        }
                        else { available = "no"; }
                        if (book1.titleName.Equals(request, StringComparison.OrdinalIgnoreCase))
                        {


                            book1.availability = false;
                            Console.WriteLine("Book titled: " + book1.titleName + " is yours");
                        }

                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
    public class Book
    {
        public string titleName;
        public string author;
        public int year;
        public int ID;
        public bool availability;

        public void NewBook()
        {
            Console.WriteLine("Please writte name of the book");
            titleName = Console.ReadLine();
            Console.WriteLine("Specify book's Author");
            author = Console.ReadLine();
            bool validity = false;
            while (validity == false)
            {
                Console.WriteLine("Now type the year of publication");
                int rok;
                bool ValidYear = int.TryParse(Console.ReadLine(), out rok);
                if (ValidYear)
                {
                    validity = true;
                    year = rok;
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.WriteLine("You wrote invalid year");
                }

            }
            ID = Program.counter++;
            availability = true;
            Console.WriteLine("Database contains " + Program.counter + " books");


        }
    }
}
