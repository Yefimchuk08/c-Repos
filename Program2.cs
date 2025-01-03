
//class Program
//{
//    static void Main()
//    {
//        //Console.WriteLine(StrToInt("one")); 

//        Calculator();

//        Passport passport = new Passport();

//        Console.WriteLine("=== Set Passport Info ===");
//        passport.SetInfo();

//        Console.WriteLine("\n=== Passport Info ===");
//        passport.ShowInfo();

//        try
//        {
//            bool result = LogigViras();
//            Console.WriteLine($"Result: {result}");
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }


//    }
//    static void Calculator()
//    {
//        Console.WriteLine("Виберіть напрямок конвертації:");
//        Console.WriteLine("1. З десяткової в двійкову");
//        Console.WriteLine("2. З десяткової в шістнадцяткову");
//        Console.WriteLine("3. З двійкової в десяткову");
//        Console.WriteLine("4. З шістнадцяткової в десяткову");
//        Console.Write("Ваш вибір: ");
//        string choice = Console.ReadLine();

//        try
//        {
//            switch (choice)
//            {
//                case "1":
//                    Console.Write("Введіть число в десятковій системі: ");
//                    int decimalNumber = int.Parse(Console.ReadLine());
//                    Console.WriteLine($"Двійкове представлення: {DecimalToBinary(decimalNumber)}");
//                    break;

//                case "2":
//                    Console.Write("Введіть число в десятковій системі: ");
//                    decimalNumber = int.Parse(Console.ReadLine());
//                    Console.WriteLine($"Шістнадцяткове представлення: {DecimalToHexadecimal(decimalNumber)}");
//                    break;

//                case "3":
//                    Console.Write("Введіть число в двійковій системі: ");
//                    string binaryNumber = Console.ReadLine();
//                    Console.WriteLine($"Десяткове представлення: {BinaryToDecimal(binaryNumber)}");
//                    break;

//                case "4":
//                    Console.Write("Введіть число в шістнадцятковій системі: ");
//                    string hexNumber = Console.ReadLine();
//                    Console.WriteLine($"Десяткове представлення: {HexadecimalToDecimal(hexNumber)}");
//                    break;

//                default:
//                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
//                    break;
//            }
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine($"Помилка: {e.Message}");
//        }
//    }

//    static string DecimalToBinary(int number)
//    {
//        return Convert.ToString(number, 2);
//    }

//    static string DecimalToHexadecimal(int number)
//    {
//        return Convert.ToString(number, 16).ToUpper();
//    }

//    static int BinaryToDecimal(string binary)
//    {
//        return Convert.ToInt32(binary, 2);
//    }

//    static int HexadecimalToDecimal(string hex)
//    {
//        return Convert.ToInt32(hex, 16);
//    }


//    //static int StrToInt(string number)
//    //{
//    //    string[] arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
//    //    if (arr[0] == number.ToLower())
//    //    {
//    //        return 0;
//    //    }
//    //    else if (arr[1] == number.ToLower())
//    //    {
//    //        return 1;
//    //    }
//    //    else if (arr[2] == number.ToLower())
//    //    {
//    //        return 2;
//    //    }
//    //    else if (arr[3] == number.ToLower())
//    //    {
//    //        return 3;
//    //    }
//    //    else if (arr[4] == number.ToLower())
//    //    {
//    //        return 4;
//    //    }
//    //    else if (arr[5] == number.ToLower())
//    //    {
//    //        return 5;
//    //    }
//    //    else if (arr[6] == number.ToLower())
//    //    {
//    //        return 6;
//    //    }
//    //    else if (arr[7] == number.ToLower())
//    //    {
//    //        return 7;
//    //    }
//    //    else if (arr[8] == number.ToLower())
//    //    {
//    //        return 8;
//    //    }
//    //    else if (arr[9] == number.ToLower())
//    //    {
//    //        return 9;
//    //    }
//    //    else
//    //    {
//    //        return -1;
//    //    }

//    //}

//    static bool IsInteger(string input)
//    {
//        return int.TryParse(input, out _);
//    }

//    static int ReadInteger(string prompt)
//    {
//        int result;
//        while (true)
//        {
//            Console.WriteLine(prompt);
//            string input = Console.ReadLine();
//            if (IsInteger(input))
//            {
//                result = int.Parse(input);
//                break;
//            }
//            else
//            {
//                Console.WriteLine("Invalid input. Please enter a valid integer.");
//            }
//        }
//        return result;
//    }

//    static bool LogigViras()
//    {
//        int num1 = ReadInteger("Enter first number: ");
//        int num2 = ReadInteger("Enter second number: ");

//        Console.WriteLine("Enter operator (<, >, <=, >=, ==, !=):");
//        string operathor = Console.ReadLine();

//        return operathor switch
//        {
//            "<" => num1 < num2,
//            ">" => num1 > num2,
//            "<=" => num1 <= num2,
//            ">=" => num1 >= num2,
//            "==" => num1 == num2,
//            "!=" => num1 != num2,
//            _ => throw new InvalidOperationException("Invalid operator entered.")
//        };
//    }
//}

//class Passport
//{
//    private string name;
//    private string surname;
//    private string dadname;
//    private string birthDate;
//    private string passportNumber;

//    public Passport() { }

//    public Passport(string name, string surname, string dadname, string birthDate, string passportNumber)
//    {
//        this.name = name.Trim();
//        this.surname = surname.Trim();
//        this.dadname = dadname.Trim();

//        if (IsDate(birthDate))
//        {
//            this.birthDate = birthDate.Trim();
//        }
//        else
//        {
//            throw new ArgumentException("Invalid birth date format.");
//        }

//        if (IsInteger(passportNumber))
//        {
//            this.passportNumber = passportNumber.Trim();
//        }
//        else
//        {
//            throw new ArgumentException("Passport number must be numeric.");
//        }
//    }

//    public string Name
//    {
//        get => name;
//        set => name = value.Trim();
//    }

//    public string Surname
//    {
//        get => surname;
//        set => surname = value.Trim();
//    }

//    public string Dadname
//    {
//        get => dadname;
//        set => dadname = value.Trim();
//    }

//    public string BirthDate
//    {
//        get => birthDate;
//        set
//        {
//            if (IsDate(value))
//            {
//                birthDate = value.Trim();
//            }
//            else
//            {
//                throw new ArgumentException("Invalid birth date format.");
//            }
//        }
//    }

//    public string PassportNumber
//    {
//        get => passportNumber;
//        set
//        {
//            if (IsInteger(value))
//            {
//                passportNumber = value.Trim();
//            }
//            else
//            {
//                throw new ArgumentException("Passport number must be numeric.");
//            }
//        }
//    }

//    private static bool IsInteger(string input)
//    {
//        return int.TryParse(input, out _);
//    }

//    private static bool IsDate(string input)
//    {
//        return DateTime.TryParse(input, out _);
//    }

//    public void SetInfo()
//    {
//        Console.Write("Enter name: ");
//        Name = Console.ReadLine();

//        Console.Write("Enter surname: ");
//        Surname = Console.ReadLine();

//        Console.Write("Enter dadname: ");
//        Dadname = Console.ReadLine();

//        Console.Write("Enter your birth date (yyyy-mm-dd): ");
//        BirthDate = Console.ReadLine();

//        Console.Write("Enter passport number: ");
//        PassportNumber = Console.ReadLine();
//    }

//    public void ShowInfo()
//    {
//        Console.WriteLine($"Full Name: {Surname} {Name} {Dadname}");
//        Console.WriteLine($"Birth Date: {BirthDate}");
//        Console.WriteLine($"Passport Number: {PassportNumber}");
//    }
//}