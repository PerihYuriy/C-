using System;

public interface ILibraryItem
{
    void IssueItem();
    void ReturnItem();
    bool CheckStatus();
}

public class Book : ILibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    private bool isIssued;

    public event EventHandler<string> StatusChanged;

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
        isIssued = false;
    }

    public void IssueItem()
    {
        if (!isIssued)
        {
            isIssued = true;
            StatusChanged?.Invoke(this, $"{Title} has been issued.");
        }
        else
        {
            throw new BookAlreadyIssuedException($"{Title} is already issued.");
        }
    }

    public void ReturnItem()
    {
        if (isIssued)
        {
            isIssued = false;
            StatusChanged?.Invoke(this, $"{Title} has been returned.");
        }
        else
        {
            throw new BookNotIssuedException($"{Title} is not issued.");
        }
    }

    public bool CheckStatus()
    {
        return isIssued;
    }
}

public class BookAlreadyIssuedException : Exception
{
    public BookAlreadyIssuedException(string message) : base(message)
    {
    }
}

public class BookNotIssuedException : Exception
{
    public BookNotIssuedException(string message) : base(message)
    {
    }
}

public class LibraryUser
{
    public string Name { get; set; }
    public int ID { get; set; }

    public LibraryUser(string name, int id)
    {
        Name = name;
        ID = id;
    }
}


public class Student : LibraryUser
{
    public string Department { get; set; }

    public Student(string name, int id, string department) : base(name, id)
    {
        Department = department;
    }
}

public class Teacher : LibraryUser
{
    public string Department { get; set; }

    public Teacher(string name, int id, string department) : base(name, id)
    {
        Department = department;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book("DiscreteMathematics", "Scherbyna", 2023);
        Book book2 = new Book("MathematicalAnalyzes", "Tarasiuk", 2024);

        book1.StatusChanged += (sender, message) => Console.WriteLine(message);
        book2.StatusChanged += (sender, message) => Console.WriteLine(message);

        try
        {
            book1.IssueItem();
            book1.IssueItem(); 
        }
        catch (BookAlreadyIssuedException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            book1.ReturnItem();
            book1.ReturnItem(); 
        }
        catch (BookNotIssuedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
