

class ArrayProcessor
{
    public delegate int[] ArrayDelegate(int[] array);

    public static int[] GetEvenNumbers(int[] array) => array.Where(x => x % 2 == 0).ToArray();

    public static int[] GetOddNumbers(int[] array) => array.Where(x => x % 2 != 0).ToArray();

    public static int[] GetPrimeNumbers(int[] array)
    {
        bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }
        return array.Where(IsPrime).ToArray();
    }

    public static int[] GetFibonacciNumbers(int[] array)
    {
        bool IsFibonacci(int num)
        {
            bool IsPerfectSquare(int n) => Math.Sqrt(n) % 1 == 0;
            return IsPerfectSquare(5 * num * num + 4) || IsPerfectSquare(5 * num * num - 4);
        }
        return array.Where(IsFibonacci).ToArray();
    }
}

// Завдання 2: Методи із використанням Action, Predicate, Func
class Utility
{
    public static void DisplayCurrentTime() => Console.WriteLine($"Current Time: {DateTime.Now:HH:mm:ss}");

    public static void DisplayCurrentDate() => Console.WriteLine($"Current Date: {DateTime.Now:yyyy-MM-dd}");

    public static void DisplayCurrentDayOfWeek() => Console.WriteLine($"Day of the Week: {DateTime.Now:dddd}");

    public static double CalculateTriangleArea(double baseLength, double height) => 0.5 * baseLength * height;

    public static double CalculateRectangleArea(double width, double height) => width * height;
}

// Завдання 3: Клас "Кредитна картка" із подіями
class CreditCard
{
    public string CardNumber { get; init; }
    public string HolderName { get; set; }
    public DateTime ExpiryDate { get; set; }
    private string pin;
    public double CreditLimit { get; set; }
    public double Balance { get; private set; }

    public event Action<double> OnDeposit;
    public event Action<double> OnWithdraw;
    public event Action OnCreditStarted;
    public event Action OnLimitReached;
    public event Action OnPinChanged;

    public CreditCard(string cardNumber, string holderName, DateTime expiryDate, string pin, double creditLimit)
    {
        CardNumber = cardNumber;
        HolderName = holderName;
        ExpiryDate = expiryDate;
        this.pin = pin;
        CreditLimit = creditLimit;
        Balance = 0;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        OnDeposit?.Invoke(amount);
    }

    public void Withdraw(double amount)
    {
        if (Balance - amount < 0)
        {
            if (Math.Abs(Balance - amount) > CreditLimit)
            {
                Console.WriteLine("Limit exceeded.");
                OnLimitReached?.Invoke();
                return;
            }
            OnCreditStarted?.Invoke();
        }
        Balance -= amount;
        OnWithdraw?.Invoke(amount);
    }

    public void ChangePin(string newPin)
    {
        pin = newPin;
        OnPinChanged?.Invoke();
    }
}

// Тестовий код
class Program
{
    static void Main()
    {
        // Завдання 1
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 21, 34 };

        ArrayProcessor.ArrayDelegate evenDelegate = ArrayProcessor.GetEvenNumbers;
        Console.WriteLine("Even Numbers: " + string.Join(", ", evenDelegate(numbers)));

        ArrayProcessor.ArrayDelegate oddDelegate = ArrayProcessor.GetOddNumbers;
        Console.WriteLine("Odd Numbers: " + string.Join(", ", oddDelegate(numbers)));

        ArrayProcessor.ArrayDelegate primeDelegate = ArrayProcessor.GetPrimeNumbers;
        Console.WriteLine("Prime Numbers: " + string.Join(", ", primeDelegate(numbers)));

        ArrayProcessor.ArrayDelegate fibDelegate = ArrayProcessor.GetFibonacciNumbers;
        Console.WriteLine("Fibonacci Numbers: " + string.Join(", ", fibDelegate(numbers)));

        // Завдання 2
        Action displayTime = Utility.DisplayCurrentTime;
        displayTime();

        Action displayDate = Utility.DisplayCurrentDate;
        displayDate();

        Action displayDay = Utility.DisplayCurrentDayOfWeek;
        displayDay();

        Func<double, double, double> triangleArea = Utility.CalculateTriangleArea;
        Console.WriteLine("Triangle Area: " + triangleArea(10, 5));

        Func<double, double, double> rectangleArea = Utility.CalculateRectangleArea;
        Console.WriteLine("Rectangle Area: " + rectangleArea(10, 5));

        // Завдання 3
        var card = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), "1234", 1000);

        card.OnDeposit += amount => Console.WriteLine($"Deposited: {amount}");
        card.OnWithdraw += amount => Console.WriteLine($"Withdrawn: {amount}");
        card.OnCreditStarted += () => Console.WriteLine("Started using credit.");
        card.OnLimitReached += () => Console.WriteLine("Credit limit reached.");
        card.OnPinChanged += () => Console.WriteLine("PIN changed.");

        card.Deposit(500);
        card.Withdraw(600);
        card.Withdraw(500);
        card.ChangePin("5678");
    }
}
