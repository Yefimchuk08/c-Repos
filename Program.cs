
class Program
{
    static void Main()
    {
        //Multiply(2, 5);


        //Console.WriteLine(NumFibbonachi(8));
        //Console.WriteLine(NumFibbonachi(10));

        //Console.Write("[1] - HIGH;\n[2] - DOWN;\nEnter num 1-2: ");
        //string str = Console.ReadLine();
        //int num = Convert.ToInt32(str);
        //Random random = new Random();
        //Console.WriteLine("Enter size of arr: ");
        //string str1 = Console.ReadLine();
        //int size = Convert.ToInt32(str1);
        //int[] arr = new int[size];
        //for (int i = 0; i < size; i++)
        //{
        //    arr[i] = random.Next()% 100;
        //}
        //SortArr(num, arr);


        //City city = new City();
        //city.SetInfo();
        //city.ShowInfo();

        //Employer employer = new Employer();
        //employer.SetInfo();
        //employer.ShowInfo();

        
        Plane airplane1 = new Plane();
        airplane1.ShowInfo();
        Console.WriteLine();

        Plane airplane2 = new Plane("Boeing 747", "Boeing", 1969, "Passenger");
        airplane2.ShowInfo();
        Console.WriteLine();

        Plane airplane3 = new Plane();
        airplane3.SetInfo("Airbus A320", "Airbus");
        airplane3.SetInfo(1988, "Passenger");
        airplane3.ShowInfo();

        Matrix matrix1 = new Matrix();
        matrix1.SetData();
        matrix1.ShowData();
        Console.WriteLine($"Max: {matrix1.FindMax()}");
        Console.WriteLine($"Min: {matrix1.FindMin()}");

        int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        Matrix matrix2 = new Matrix(3, 3);
        matrix2.SetData(array);
        matrix2.ShowData();
        Console.WriteLine($"Max: {matrix2.FindMax()}");
        Console.WriteLine($"Min: {matrix2.FindMin()}");
    }


    static void Multiply(int num1, int num2)
    {
        int multiply = 1;
        if (num1 < num2)
        {
            for (int i = num1; i <= num2; i++)
            {
                multiply *= i;
            }
        }
        else
        {
            {
                for (int i = num2; i <= num1; i++)
                {
                    multiply *= i;
                }
            }
        }
        Console.WriteLine(multiply);
    }

    static bool NumFibbonachi(int num)
    {
        if (num < 0) return false; 

        int a = 0, b = 1;

        while (b < num)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }

        return b == num || num == 0;
    }
    static void SortArr(int num, int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {arr[i]}");
            Console.WriteLine();
        }
        switch (num)
        {
        case 1:
           for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i+1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            int temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                break;
            case 2:

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] < arr[j])
                        {
                            int temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                break;
            default:
                break;
        }
        for (int i = 0;i < arr.Length;i++)
        {
            Console.WriteLine($"{i+1}: {arr[i]}");
        }
    }
}

class City
{
    private string cityName;
    private string countryName;
    private int countOfPeople;
    private int cityPhoneCode;
    private string[] districts;

    public City() { }

    public City(string cityName, string countryName, int countOfPeople, int cityPhoneCode, string[] districts)
    {
        this.cityName = cityName;
        this.countryName = countryName;
        this.countOfPeople = countOfPeople;
        this.cityPhoneCode = cityPhoneCode;
        this.districts = districts;
    }

    public string CityName
    {
        get { return cityName; }
        set { cityName = value; }
    }

    public string CountryName
    {
        get { return countryName; }
        set { countryName = value; }
    }

    public int CountOfPeople
    {
        get { return countOfPeople; }
        set { countOfPeople = value; }
    }

    public int CityPhoneCode
    {
        get { return cityPhoneCode; }
        set { cityPhoneCode = value; }
    }

    public string[] Districts
    {
        get { return districts; }
        set { districts = value; }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"City name: {cityName}");
        Console.WriteLine($"Country name: {countryName}");
        Console.WriteLine($"Population: {countOfPeople}");
        Console.WriteLine($"City phone code: {cityPhoneCode}");
        Console.WriteLine("Districts: " + (districts != null ? string.Join(", ", districts) : "No districts"));
    }

    public void SetInfo()
    {
        Console.WriteLine("Enter city name: ");
        cityName = Console.ReadLine();

        Console.WriteLine("Enter country name: ");
        countryName = Console.ReadLine();

        Console.WriteLine("Enter population: ");
        while (!int.TryParse(Console.ReadLine(), out countOfPeople) || countOfPeople < 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for population.");
        }

        Console.WriteLine("Enter city phone code: ");
        while (!int.TryParse(Console.ReadLine(), out cityPhoneCode) || cityPhoneCode < 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for city phone code.");
        }

        Console.WriteLine("Enter the number of districts: ");
        int numDistricts;
        while (!int.TryParse(Console.ReadLine(), out numDistricts) || numDistricts < 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of districts.");
        }

        districts = new string[numDistricts];
        Console.WriteLine("Enter district names:");
        for (int i = 0; i < numDistricts; i++)
        {
            Console.Write($"District {i + 1}: ");
            districts[i] = Console.ReadLine();
        }
    }
}

class Employer
{
    private string name;
    private string surname;
    private string dadname;
    private string birthday;
    private int phone_number;
    private string email;
    private string position;
    private string work;

    public Employer()
    {

    }
    public Employer(string name, string surname, string dadname, string birthday, int phone_number, string email, string position, string work)
    {
        this.name = name;
        this.surname = surname;
        this.dadname = dadname;
        this.birthday = birthday;
        this.phone_number = phone_number;
        this.email = email;
        this.position = position;
        this.work = work;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }
    public string Dadname
    {
        get { return dadname; }
        set { dadname = value; }
    }
    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    public int PhoneNumber
    {
        get { return phone_number; }
        set { phone_number = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Position
    {
        get { return position; }
        set { position = value; }
    }
    public string Work
    {
        get { return work; }
        set { work = value; }
    }

    public void SetInfo()
    {
        Console.WriteLine("Enter name: ");
        name = Console.ReadLine();
        Console.WriteLine("Enter surname: ");
        surname = Console.ReadLine();
        Console.WriteLine("Enter dadname: ");
        dadname = Console.ReadLine();
        Console.WriteLine("Enter Birthday: ");
        birthday = Console.ReadLine();
        Console.WriteLine("Enter phone number: ");
        while(!int.TryParse(Console.ReadLine(),out phone_number))
        {
            Console.WriteLine("Invalid value");
        }
        Console.WriteLine("Enter email: ");
        email = Console.ReadLine();
        Console.WriteLine("Enter position: ");
        position = Console.ReadLine();
        Console.WriteLine("Enter work: ");
        work = Console.ReadLine();
    }

    public void ShowInfo()
    {
        Console.WriteLine($"PIB: {surname}{name}{dadname}");
        Console.WriteLine($"Birth date: {birthday}");
        Console.WriteLine($"Phone number: {phone_number}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Work: {work}");
    }
}

class Plane
{
    private string name;
    private string vurobnik;
    private int year;
    private string type;

    public Plane()
    {

    }
    public Plane(string name, string vurobnik, int year, string type)
    {
        this.name = name;
        this.vurobnik = vurobnik;
        this.year = year;
        this.type = type;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Vurobnik
    {
        get { return vurobnik; }
        set { vurobnik = value; }
    }
    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    public void SetInfo(string name, string manufacturer, int yearOfProduction, string type)
    {
        this.name = name;
        this.vurobnik = manufacturer;
        this.year = yearOfProduction;
        this.type = type;
    }

   
    public void SetInfo(string name, string manufacturer)
    {
        this.name = name;
        this.vurobnik = manufacturer;
    }

    
    public void SetInfo(int yearOfProduction, string type)
    {
        this.year = yearOfProduction;
        this.type = type;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Vurobnik: {vurobnik}");
        Console.WriteLine($"Year: {year}");
        Console.WriteLine($"Type: {type}");
    }
}


class Matrix
{
    private int[,] data;

    public Matrix()
    {
        data = new int[3, 3];
    }

    public Matrix(int rows, int cols)
    {
        data = new int[rows, cols];
    }

    public void SetData()
    {
        Console.WriteLine("Enter elements of the matrix:");
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write($"Element [{i + 1},{j + 1}]: ");
                data[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void SetData(int[,] array)
    {
        if (array.GetLength(0) == data.GetLength(0) && array.GetLength(1) == data.GetLength(1))
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    data[i, j] = array[i, j];
        }
    }

    public void ShowData()
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int FindMax()
    {
        int max = data[0, 0];
        for (int i = 0; i < data.GetLength(0); i++)
            for (int j = 0; j < data.GetLength(1); j++)
                if (data[i, j] > max)
                    max = data[i, j];
        return max;
    }

    public int FindMin()
    {
        int min = data[0, 0];
        for (int i = 0; i < data.GetLength(0); i++)
            for (int j = 0; j < data.GetLength(1); j++)
                if (data[i, j] < min)
                    min = data[i, j];
        return min;
    }
}