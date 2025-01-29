using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Task 1: Student Performance Analysis
        List<(string Name, double Average, string Speciality)> students = new()
        {
            ("Maria", 92, "Computer Science"),
            ("Oleg", 85, "Mathematics"),
            ("Andrew", 78, "Physics"),
            ("Svetlana", 88, "Biology"),
            ("Yuriy", 65, "Chemistry")
        };

        var bestStudent = students.OrderByDescending(s => s.Average).First();
        double averageScore = students.Average(s => s.Average);

        Console.WriteLine($"Best student: {bestStudent.Name}, Average Score: {bestStudent.Average}");
        Console.WriteLine($"Class Average Score: {averageScore:F1}\n");

        // Task 2: Currency Converter
        Console.Write("Enter amount in UAH: ");
        double uah = double.Parse(Console.ReadLine());

        var rates = (USD: 0.0256, EUR: 0.0238, PLN: 0.1065);
        var converted = (USD: uah * rates.USD, EUR: uah * rates.EUR, PLN: uah * rates.PLN);

        Console.WriteLine($"{uah} UAH = {converted.USD:F2}$ = {converted.EUR:F2}€ = {converted.PLN:F2} PLN\n");

        // Task 3: Car Statistics
        var cars = new[]
        {
            new { Brand = "Toyota Corolla", Year = 2020, Mileage = 50000, Price = 15000 },
            new { Brand = "Tesla Model 3", Year = 2022, Mileage = 20000, Price = 35000 },
            new { Brand = "Ford Focus", Year = 2017, Mileage = 80000, Price = 12000 },
            new { Brand = "BMW X5", Year = 2019, Mileage = 40000, Price = 45000 }
        };

        var recentCars = cars.Where(c => c.Year > 2018);
        var minMileageCar = cars.OrderBy(c => c.Mileage).First();
        double averagePrice = cars.Average(c => c.Price);

        Console.WriteLine("Cars from 2018+:");
        foreach (var car in recentCars)
            Console.WriteLine($"{car.Brand} - {car.Year}, {car.Mileage} km");

        Console.WriteLine($"\nLowest mileage: {minMileageCar.Brand} ({minMileageCar.Mileage} km)");
        Console.WriteLine($"Average car price: {averagePrice:C}\n");

        // Task 4: Exam Analysis
        var examStudents = new[]
        {
            new { Name = "Maria", Grade = 95 },
            new { Name = "Oleg", Grade = 82 },
            new { Name = "Andrew", Grade = 89 },
            new { Name = "Svetlana", Grade = 55 },
            new { Name = "Yuriy", Grade = 60 }
        };

        var passed = examStudents.Where(s => s.Grade >= 60).Select(s => s.Name);
        double classAverage = examStudents.Average(s => s.Grade);
        var topStudents = examStudents.OrderByDescending(s => s.Grade).Take(3);

        Console.WriteLine($"Students who passed the exam: {string.Join(", ", passed)}");
        Console.WriteLine($"Class average grade: {classAverage:F1}");
        Console.WriteLine("Top 3 students:");
        int rank = 1;
        foreach (var student in topStudents)
            Console.WriteLine($"{rank++}. {student.Name} ({student.Grade})");

        Console.WriteLine();

        // Task 5: Book Ratings
        var books = new[]
        {
            (Title: "1984", Author: "George Orwell", Rating: 9.5),
            (Title: "The Lord of the Rings", Author: "J.R.R. Tolkien", Rating: 9.3),
            (Title: "Harry Potter", Author: "J.K. Rowling", Rating: 9.1),
            (Title: "To Kill a Mockingbird", Author: "Harper Lee", Rating: 8.7),
            (Title: "The Great Gatsby", Author: "F. Scott Fitzgerald", Rating: 8.5)
        };

        var topBooks = books.OrderByDescending(b => b.Rating).Take(3);

        Console.WriteLine("Top 3 books:");
        int bookRank = 1;
        foreach (var book in topBooks)
            Console.WriteLine($"{bookRank++}. \"{book.Title}\" ({book.Author}) - {book.Rating}");
    }
}
