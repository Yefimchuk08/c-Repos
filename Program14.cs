


namespace RecordsPD422
{
    //public record Student(string Name, string Surname, int Age, int GroupNumber, double AverageGrade);


    //internal class Program
    //{
    //    static void Main()
    //    {
    //        var students = new List<Student>
    //        {
    //            new Student("Dima", "Diomin", 16, 1, 12),
    //            new Student("Vasya", "Ivanov", 15, 2, 11.5),
    //            new Student("Genya", "Geniov", 16, 3, 9),
    //            new Student("Roma", "Romanov", 16, 4, 10),
    //            new Student("Igor", "Igorenko", 16, 4, 4.3),

    //        };

    //        foreach (var student in students)
    //        {
    //            Console.WriteLine(student.ToString()); 
    //        }
    //        Console.WriteLine();
    //        foreach (var student in students)
    //        {
    //            if (student.AverageGrade > 4.5)
    //            {
    //                Console.WriteLine(student.ToString());
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //        Console.WriteLine();
    //        Console.WriteLine("Enter number of group: ");
    //        string num_str = Console.ReadLine();
    //        int num = Int32.Parse(num_str);
    //        foreach (var student in students)
    //        {
    //            if (student.GroupNumber == num)
    //            {
    //                Console.WriteLine(student.ToString());
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //        Console.WriteLine();
    //        var bestStudent = students.MaxBy(s => s.AverageGrade);
    //        Console.WriteLine("Best student:");
    //        Console.WriteLine(bestStudent?.ToString());

    //        Console.WriteLine();

    //        if (bestStudent != null)
    //        {
    //            var modifiedStudent = bestStudent with { AverageGrade = 8.5 };
    //            Console.WriteLine("Modify student:");
    //            Console.WriteLine(modifiedStudent.ToString());
    //        }
    //    }
    //}



    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public record Order(
            int OrderId,
            string CustomerName,
            string Product,
            int Quantity,
            decimal Price,
            DateTime Date,
            string Status)
        {
            public decimal TotalCost => Quantity * Price; 
        }

        static void Main(string[] args)
        {
            
            List<Order> orders = new List<Order>
        {
            new(1, "Ivan", "Laptop", 1, 15000, new DateTime(2025, 1, 20), "Completed"),
            new(2, "Maria", "Phone", 2, 8000, new DateTime(2025, 1, 15), "Processing"),
            new(3, "Ivan", "Mouse", 1, 500, new DateTime(2025, 1, 10), "Completed"),
            new(4, "Olena", "Keyboard", 1, 1000, new DateTime(2025, 1, 18), "Processing"),
            new(5, "Maria", "Monitor", 1, 12000, new DateTime(2025, 1, 12), "Completed")
        };

            // 1.
            var customerTotals = orders
                .GroupBy(o => o.CustomerName)
                .Select(g => new { CustomerName = g.Key, TotalAmount = g.Sum(o => o.TotalCost) });

            Console.WriteLine("Total order value for each customer:");
            foreach (var customer in customerTotals)
            {
                Console.WriteLine($"{customer.CustomerName}: {customer.TotalAmount} UAH");
            }

            // 2.
            var topCustomer = orders
                .Where(o => o.Status == "Completed")
                .GroupBy(o => o.CustomerName)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (topCustomer != null)
            {
                Console.WriteLine($"\nCustomer with the most completed orders: {topCustomer.Key} ({topCustomer.Count()} orders)");
            }

            // 3. 
            var expensiveOrders = orders
                .Where(o => o.TotalCost > 1000)
                .OrderBy(o => o.Date);

            Console.WriteLine("\nOrders with total cost over 1000 UAH:");
            foreach (var order in expensiveOrders)
            {
                Console.WriteLine($"{order.CustomerName} - {order.Product} - {order.TotalCost} UAH - {order.Date:yyyy-MM-dd}");
            }

            // 4.
            var orderToModify = orders.FirstOrDefault(o => o.Status == "Processing");
            if (orderToModify != null)
            {
                var modifiedOrder = orderToModify with { Status = "Completed" };
                Console.WriteLine($"\nModified order copy: {modifiedOrder}");
            }

            // 5. 
            var processingCustomers = orders
                .Where(o => o.Status == "Processing")
                .Select(o => o.CustomerName)
                .Distinct();

            Console.WriteLine("\nCustomers with at least one 'Processing' order:");
            foreach (var customer in processingCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }

}
