// Task 1: Class "Journal"
public class Journal
{
    public string Name { get; set; }
    public int NumberOfEmployees { get; set; }

    public Journal(string name, int numberOfEmployees)
    {
        Name = name;
        NumberOfEmployees = numberOfEmployees;
    }

    public static Journal operator +(Journal journal, int employees)
    {
        journal.NumberOfEmployees += employees;
        return journal;
    }

    public static Journal operator -(Journal journal, int employees)
    {
        journal.NumberOfEmployees = Math.Max(0, journal.NumberOfEmployees - employees);
        return journal;
    }

    public static bool operator ==(Journal journal1, Journal journal2)
    {
        return journal1.NumberOfEmployees == journal2.NumberOfEmployees;
    }

    public static bool operator !=(Journal journal1, Journal journal2)
    {
        return !(journal1 == journal2);
    }

    public static bool operator <(Journal journal1, Journal journal2)
    {
        return journal1.NumberOfEmployees < journal2.NumberOfEmployees;
    }

    public static bool operator >(Journal journal1, Journal journal2)
    {
        return journal1.NumberOfEmployees > journal2.NumberOfEmployees;
    }

    public override bool Equals(object obj)
    {
        if (obj is Journal journal)
        {
            return this == journal;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return NumberOfEmployees.GetHashCode();
    }
}

// Task 2: Class "Store"
public class Store
{
    public string Name { get; set; }
    public double Area { get; set; }

    public Store(string name, double area)
    {
        Name = name;
        Area = area;
    }

    public static Store operator +(Store store, double additionalArea)
    {
        store.Area += additionalArea;
        return store;
    }

    public static Store operator -(Store store, double reducedArea)
    {
        store.Area = Math.Max(0, store.Area - reducedArea);
        return store;
    }

    public static bool operator ==(Store store1, Store store2)
    {
        return Math.Abs(store1.Area - store2.Area) < 0.0001;
    }

    public static bool operator !=(Store store1, Store store2)
    {
        return !(store1 == store2);
    }

    public static bool operator <(Store store1, Store store2)
    {
        return store1.Area < store2.Area;
    }

    public static bool operator >(Store store1, Store store2)
    {
        return store1.Area > store2.Area;
    }

    public override bool Equals(object obj)
    {
        if (obj is Store store)
        {
            return this == store;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Area.GetHashCode();
    }
}

// Task 3: Application "Reading List"
public class ReadingList
{
    private List<string> books = new List<string>();

    public string this[int index]
    {
        get => books[index];
        set => books[index] = value;
    }

    public void AddBook(string book)
    {
        if (!books.Contains(book))
        {
            books.Add(book);
        }
    }

    public void RemoveBook(string book)
    {
        books.Remove(book);
    }

    public bool ContainsBook(string book)
    {
        return books.Contains(book);
    }

    public override string ToString()
    {
        return string.Join(", ", books);
    }
}

// Main Program to Utilize Classes
public class Program
{
    public static void Main(string[] args)
    {
        // Task 1: Journal Example
        Journal journal1 = new Journal("Tech Weekly", 10);
        Journal journal2 = new Journal("Health Digest", 15);

        journal1 += 5;
        journal2 -= 3;

        Console.WriteLine($"Journal 1: {journal1.Name}, Employees: {journal1.NumberOfEmployees}");
        Console.WriteLine($"Journal 2: {journal2.Name}, Employees: {journal2.NumberOfEmployees}");
        Console.WriteLine($"Are employee counts equal? {journal1 == journal2}");

        // Task 2: Store Example
        Store store1 = new Store("SuperMart", 250.5);
        Store store2 = new Store("MiniMart", 150.0);

        store1 += 50.0;
        store2 -= 25.0;

        Console.WriteLine($"Store 1: {store1.Name}, Area: {store1.Area} sqm");
        Console.WriteLine($"Store 2: {store2.Name}, Area: {store2.Area} sqm");
        Console.WriteLine($"Is Store 1 larger than Store 2? {store1 > store2}");

        // Task 3: Reading List Example
        ReadingList readingList = new ReadingList();
        readingList.AddBook("1984 by George Orwell");
        readingList.AddBook("To Kill a Mockingbird by Harper Lee");

        Console.WriteLine("Books in Reading List:");
        Console.WriteLine(readingList);

        readingList.RemoveBook("1984 by George Orwell");
        Console.WriteLine("Books after removal:");
        Console.WriteLine(readingList);
    }
}
