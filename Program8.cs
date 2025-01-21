// Завдання 1: Клас "П'єса"


class Play : IDisposable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    private bool disposed = false;

    public Play(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Очистка керованих ресурсів
            }

            // Очистка некерованих ресурсів
            disposed = true;
        }
    }

    ~Play()
    {
        Dispose(false);
    }
}

// Завдання 2: Клас "Магазин"
class Shop : IDisposable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ShopType { get; set; }

    private bool disposed = false;

    public Shop(string name, string address, string shopType)
    {
        Name = name;
        Address = address;
        ShopType = shopType;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Address: {Address}, Type: {ShopType}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Очистка керованих ресурсів
            }

            // Очистка некерованих ресурсів
            disposed = true;
        }
    }

    ~Shop()
    {
        Dispose(false);
    }
}

// Тестовий код
class Program
{
    static void Main()
    {
        // Тестування класу "П'єса"
        using (var play = new Play("Hamlet", "William Shakespeare", "Tragedy", 1601))
        {
            play.DisplayInfo();
        }

        // Тестування класу "Магазин"
        using (var shop = new Shop("Supermarket", "123 Main St", "Grocery"))
        {
            shop.DisplayInfo();
        }
    }
}
