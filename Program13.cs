using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
}

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

class Order
{
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}

class City
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int Population { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Завдання 1: Фільтрація студентів");
        FilterStudents();

        Console.WriteLine("\nЗавдання 2: Підрахунок слів у тексті");
        CountWordsInText();

        Console.WriteLine("\nЗавдання 3: Робота з товарами");
        AnalyzeProducts();

        Console.WriteLine("\nЗавдання 4: Статистика про числа");
        AnalyzeNumbers();

        Console.WriteLine("\nЗавдання 5: Аналіз продажів");
        AnalyzeOrders();

        Console.WriteLine("\nЗавдання 6: Пошук у файлі");
        SearchInFile();

        Console.WriteLine("\nЗавдання 7: Групування міст");
        GroupCities();
    }

    static void FilterStudents()
    {
        var students = new List<Student>
        {
            new Student { Name = "John", Age = 21, Grade = 90 },
            new Student { Name = "Alice", Age = 19, Grade = 88 },
            new Student { Name = "Bob", Age = 22, Grade = 84 },
            new Student { Name = "Emma", Age = 23, Grade = 92 }
        };

        var filteredStudents = students
            .Where(s => s.Age > 20 && s.Grade > 85)
            .OrderByDescending(s => s.Grade);

        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"{student.Name}: {student.Grade}");
        }
    }

    static void CountWordsInText()
    {
        string text = File.ReadAllText("text.txt");

        var wordCounts = text
            .Split(new[] { ' ', '\n', '\r', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
            .GroupBy(word => word.ToLower())
            .Select(group => new { Word = group.Key, Count = group.Count() })
            .OrderByDescending(x => x.Count);

        foreach (var wc in wordCounts)
        {
            Console.WriteLine($"{wc.Word}: {wc.Count}");
        }
    }

    static void AnalyzeProducts()
    {
        var products = new List<Product>
        {
            new Product { Name = "Apple", Category = "Fruits", Price = 1.2m },
            new Product { Name = "Banana", Category = "Fruits", Price = 0.8m },
            new Product { Name = "Carrot", Category = "Vegetables", Price = 0.5m },
            new Product { Name = "Potato", Category = "Vegetables", Price = 0.3m }
        };

        var groupedProducts = products.GroupBy(p => p.Category);

        foreach (var group in groupedProducts)
        {
            var cheapest = group.OrderBy(p => p.Price).First();
            var mostExpensive = group.OrderByDescending(p => p.Price).First();
            var averagePrice = group.Average(p => p.Price);

            Console.WriteLine($"Category: {group.Key}");
            Console.WriteLine($"Cheapest: {cheapest.Name} (${cheapest.Price})");
            Console.WriteLine($"Most Expensive: {mostExpensive.Name} (${mostExpensive.Price})");
            Console.WriteLine($"Average Price: ${averagePrice:F2}");
            Console.WriteLine();
        }
    }

    static void AnalyzeNumbers()
    {
        var random = new Random();
        var numbers = Enumerable.Range(1, 50).Select(_ => random.Next(1, 101)).ToArray();

        var evenNumbers = numbers.Where(n => n % 2 == 0);
        var oddSum = numbers.Where(n => n % 2 != 0).Sum();
        var greaterThanAverage = numbers.Where(n => n > numbers.Average()).Count();

        Console.WriteLine($"Even Numbers: {string.Join(", ", evenNumbers)}");
        Console.WriteLine($"Sum of Odd Numbers: {oddSum}");
        Console.WriteLine($"Numbers Greater Than Average: {greaterThanAverage}");
    }

    static void AnalyzeOrders()
    {
        var orders = new List<Order>
        {
            new Order { CustomerName = "John", OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 100 },
            new Order { CustomerName = "Alice", OrderDate = DateTime.Now, TotalAmount = 150 },
            new Order { CustomerName = "Bob", OrderDate = DateTime.Now.AddMonths(-1), TotalAmount = 200 }
        };

        var currentMonthOrders = orders.Where(o => o.OrderDate.Month == DateTime.Now.Month);
        var totalByMonth = orders.GroupBy(o => o.OrderDate.Month)
            .Select(group => new { Month = group.Key, Total = group.Sum(o => o.TotalAmount) });
        var topCustomer = orders.GroupBy(o => o.CustomerName)
            .OrderByDescending(group => group.Count())
            .FirstOrDefault()?.Key;

        Console.WriteLine("Current Month Orders:");
        foreach (var order in currentMonthOrders)
        {
            Console.WriteLine($"{order.CustomerName}: ${order.TotalAmount}");
        }

        Console.WriteLine("Total Sales by Month:");
        foreach (var month in totalByMonth)
        {
            Console.WriteLine($"Month {month.Month}: ${month.Total}");
        }

        Console.WriteLine($"Top Customer: {topCustomer}");
    }

    static void SearchInFile()
    {
        string[] lines = File.ReadAllLines("text.txt");
        string keyword = "LINQ";

        var matchingLines = lines
            .Select((line, index) => new { Line = line, Index = index + 1 })
            .Where(x => x.Line.Contains(keyword));

        foreach (var match in matchingLines)
        {
            Console.WriteLine($"Line {match.Index}: {match.Line}");
        }
    }

    static void GroupCities()
    {
        var cities = new List<City>
        {
            new City { Name = "Kyiv", Country = "Ukraine", Population = 2800000 },
            new City { Name = "Lviv", Country = "Ukraine", Population = 720000 },
            new City { Name = "New York", Country = "USA", Population = 8500000 },
            new City { Name = "Los Angeles", Country = "USA", Population = 4000000 }
        };

        var groupedByCountry = cities.GroupBy(c => c.Country);

        foreach (var group in groupedByCountry)
        {
            Console.WriteLine($"Country: {group.Key}");
            foreach (var city in group)
            {
                Console.WriteLine($"  {city.Name}: {city.Population}");
            }
        }

        var countryWithMostPopulation = groupedByCountry
            .OrderByDescending(group => group.Sum(c => c.Population))
            .FirstOrDefault()?.Key;

        Console.WriteLine($"Country with most population: {countryWithMostPopulation}");

        var largeCities = cities
            .Where(c => c.Population > 1000000)
            .OrderByDescending(c => c.Population);

        Console.WriteLine("Cities with population > 1M:");
        foreach (var city in largeCities)
        {
            Console.WriteLine($"{city.Name}: {city.Population}");
        }
    }
}
