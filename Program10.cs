using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a task (1-5): ");
        int choice = int.Parse(Console.ReadLine() ?? "1");

        switch (choice)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 3:
                Task3();
                break;
            case 4:
                Task4();
                break;
            case 5:
                Task5();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void Task1()
    {
        var random = new Random();
        var numbers = Enumerable.Range(0, 100).Select(_ => random.Next(1, 1000)).ToList();

        bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }

        bool IsFibonacci(int number)
        {
            bool IsPerfectSquare(int x) => Math.Sqrt(x) % 1 == 0;
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }

        var primes = numbers.Where(IsPrime).ToList();
        var fibonacci = numbers.Where(IsFibonacci).ToList();

        File.WriteAllLines("primes.txt", primes.Select(x => x.ToString()));
        File.WriteAllLines("fibonacci.txt", fibonacci.Select(x => x.ToString()));

        Console.WriteLine($"Prime numbers saved to primes.txt ({primes.Count}).");
        Console.WriteLine($"Fibonacci numbers saved to fibonacci.txt ({fibonacci.Count}).");
    }

    static void Task2()
    {
        Console.WriteLine("Enter the path to the file:");
        string path = Console.ReadLine();
        Console.WriteLine("Enter the word to search for:");
        string searchWord = Console.ReadLine();
        Console.WriteLine("Enter the word to replace with:");
        string replaceWord = Console.ReadLine();

        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            string updatedContent = content.Replace(searchWord, replaceWord);
            File.WriteAllText(path, updatedContent);

            Console.WriteLine($"Replacement completed. All occurrences of '{searchWord}' replaced with '{replaceWord}'.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static void Task3()
    {
        Console.WriteLine("Enter the path to the text file:");
        string textPath = Console.ReadLine();
        Console.WriteLine("Enter the path to the file with moderation words:");
        string moderationWordsPath = Console.ReadLine();

        if (File.Exists(textPath) && File.Exists(moderationWordsPath))
        {
            string content = File.ReadAllText(textPath);
            var moderationWords = File.ReadAllLines(moderationWordsPath);

            foreach (var word in moderationWords)
            {
                content = content.Replace(word, new string('*', word.Length));
            }

            File.WriteAllText(textPath, content);
            Console.WriteLine("Moderation completed.");
        }
        else
        {
            Console.WriteLine("One of the files was not found.");
        }
    }

    static void Task4()
    {
        Console.WriteLine("Enter the path to the file:");
        string path = Console.ReadLine();

        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            string reversedContent = new string(content.Reverse().ToArray());
            string newFilePath = Path.Combine(Path.GetDirectoryName(path), "reversed_" + Path.GetFileName(path));

            File.WriteAllText(newFilePath, reversedContent);
            Console.WriteLine($"Reversed file created: {newFilePath}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static void Task5()
    {
        Console.WriteLine("Enter the path to the file:");
        string path = Console.ReadLine();

        if (File.Exists(path))
        {
            var numbers = File.ReadAllLines(path).Select(int.Parse).ToList();

            var positiveNumbers = numbers.Where(n => n > 0).ToList();
            var negativeNumbers = numbers.Where(n => n < 0).ToList();
            var twoDigitNumbers = numbers.Where(n => n >= 10 && n <= 99 || n <= -10 && n >= -99).ToList();
            var fiveDigitNumbers = numbers.Where(n => n >= 10000 && n <= 99999 || n <= -10000 && n >= -99999).ToList();

            Console.WriteLine($"Count of positive numbers: {positiveNumbers.Count}");
            Console.WriteLine($"Count of negative numbers: {negativeNumbers.Count}");
            Console.WriteLine($"Count of two-digit numbers: {twoDigitNumbers.Count}");
            Console.WriteLine($"Count of five-digit numbers: {fiveDigitNumbers.Count}");

            File.WriteAllLines("positive_numbers.txt", positiveNumbers.Select(x => x.ToString()));
            File.WriteAllLines("negative_numbers.txt", negativeNumbers.Select(x => x.ToString()));
            File.WriteAllLines("two_digit_numbers.txt", twoDigitNumbers.Select(x => x.ToString()));
            File.WriteAllLines("five_digit_numbers.txt", fiveDigitNumbers.Select(x => x.ToString()));

            Console.WriteLine("Statistics files have been created.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
