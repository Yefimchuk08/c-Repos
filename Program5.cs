//class Program
//{
//    static void Main()
//    {
//        //TASK 1

//        Product apple = new Product("Apple", 5, 50);
//        apple.DisplayPrice();

//        Console.WriteLine("Reducing price by 1.25...");
//        apple.ReducePrice(1, 25);



//        //TASK 2

//        Chainyk chainyk = new Chainyk("Bosh", "Electro", 2025, "Chainuk", 2);
//        chainyk.ShowInfo();
//        chainyk.DescInfo();
//        chainyk.Sound();

//        Microwave microwave = new Microwave("Bosh", "NewST", 2025, "Microwawe", 100);
//        microwave.ShowInfo();
//        microwave.DescInfo();
//        microwave.Sound();

//        Car car = new Car("BMW", "M5 D90 Competition", 2023, "Car", 4.5, 230);
//        car.ShowInfo();
//        car.DescInfo();
//        car.Sound();

//        Steamer steamer = new Steamer("Titanik", "1912", 1912, "Steamer", 6000);
//        steamer.ShowInfo();
//        steamer.DescInfo();
//        steamer.Sound();



//        //TASK 3


//        Violin violin = new Violin("String", "Bethoven", "Classic", "Violin", 5);
//        violin.ShowInfo();
//        violin.DescInfo();
//        violin.ShowHistory();
//        violin.Sound();

//        Trombone trombone = new Trombone("Dudka", "Orkestr", "Orkestr", "Trombone", "Orkestr");
//        trombone.ShowInfo();
//        trombone.DescInfo();
//        trombone.ShowHistory();
//        trombone.Sound();

//        Ukulele ukulele = new Ukulele("String", "kovboy", "Gdeg dage daga da yo", "Ukulele", 6);
//        ukulele.ShowInfo();
//        ukulele.DescInfo();
//        ukulele.ShowHistory();
//        ukulele.Sound();

//        Cello cello = new Cello("String", "No", "No", "Cello", 5);
//        cello.ShowInfo();
//        cello.DescInfo();
//        cello.ShowHistory();
//        cello.Sound();

//        //TASK 4


//        President president = new President("Dima", "Yefimchuk", "Sergo", 18, "UA", "UA");
//        president.Print();
//        Console.WriteLine();

//        Security security = new Security("Dima", "Yefimchuk", "Sergo", 18, "UA", "Yefimchuk Dima");
//        security.Print();
//        Console.WriteLine();

//        Manager manager = new Manager("Dima", "Yefimchuk", "Sergo", 18, "UA", "Programing");
//        manager.Print();
//        Console.WriteLine();

//        Engineer engineer = new Engineer("Dima", "Yefimchuk", "Sergo", 18, "UA", "Programing");
//        engineer.Print();
//        Console.WriteLine();


//    }
//}

////TASK 1

//class Money
//{
//    private int wholePart;
//    private int fractionalPart;

//    public Money(int whole = 0, int fractional = 0)
//    {
//        wholePart = whole;
//        fractionalPart = fractional;
//        Normalize();
//    }

//    private void Normalize()
//    {
//        if (fractionalPart >= 100)
//        {
//            wholePart += fractionalPart / 100;
//            fractionalPart %= 100;
//        }
//        else if (fractionalPart < 0)
//        {
//            wholePart -= 1 + (-fractionalPart) / 100;
//            fractionalPart = 100 + fractionalPart % 100;
//        }
//    }

//    public void SetMoney(int whole, int fractional)
//    {
//        wholePart = whole;
//        fractionalPart = fractional;
//        Normalize();
//    }

//    public void Display()
//    {
//        Console.WriteLine($"{wholePart}.{fractionalPart:D2}");
//    }

//    public void Subtract(Money amount)
//    {
//        wholePart -= amount.wholePart;
//        fractionalPart -= amount.fractionalPart;
//        Normalize();
//    }
//}

//class Product
//{
//    private string name;
//    private Money price;

//    public Product(string productName, int whole, int fractional)
//    {
//        name = productName;
//        price = new Money(whole, fractional);
//    }

//    public void DisplayPrice()
//    {
//        Console.Write($"Product \"{name}\" price: ");
//        price.Display();
//    }

//    public void ReducePrice(int whole, int fractional)
//    {
//        Money discount = new Money(whole, fractional);
//        price.Subtract(discount);
//        Console.Write("After discount: ");
//        price.Display();
//    }
//}

////TASK 2

//class Gadget
//{
//    private string name;
//    private string vendom;
//    private string model;
//    private int year;


//    public string Name { get; set; }
//    public string Vendom { get; set; }
//    public string Model { get; set; }

//    public int Year { get; set; }

//    public Gadget()
//    {
//        name = "Noname";
//        vendom = "Novendom";
//        model = "NoModel";
//        year = 0;
//    }
//    public Gadget(string v, string m, int y, string n)
//    {
//        name = n;
//        vendom = v;
//        model = m;
//        year = y;
//    }

//    public virtual void ShowInfo()
//    {
//        Console.WriteLine($"Name: {name}");
//    }

//    public virtual void DescInfo()
//    {
//        Console.WriteLine($"Vendom: {vendom}, model: {model}, year: {year}");
//    }


//}

//class Chainyk : Gadget
//{
//    double volume;

//    public double Volume { get; set; }

//    public Chainyk() : base()
//    {
//        volume = 0;
//    }
//    public Chainyk(string v, string m, int y, string n, double vo) : base(v, m, y, n)
//    {
//        volume = vo;
//    }

//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Volume: {volume}");
//        Console.WriteLine();
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//        Console.WriteLine();
//    }

//    public void Sound()
//    {
//        Console.WriteLine("whiiiiiist.....");
//        Console.WriteLine();
//    }
//}

//class Microwave : Gadget
//{
//    int maxTemperature;
//    public int MaxTemperature { get; set; }


//    public string name = "Microwave";
//    public Microwave() : base()
//    {
//        maxTemperature = 0;
//    }

//    public Microwave(string v, string m, int y, string n, int mT) : base(v, m, y, n)
//    {
//        maxTemperature = mT;
//    }

//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Max temperature: {maxTemperature}");
//        Console.WriteLine();
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//        Console.WriteLine();
//    }
//    public void Sound()
//    {
//        Console.WriteLine("mmmzzzzzzz......");
//        Console.WriteLine();
//    }
//}

//class Car : Gadget
//{
//    double volume;
//    int maxSpeed;

//    public double Volume { get; set; }

//    public int MaxSpeed { get; set; }

//    public Car() : base()
//    {
//        volume = 0;
//        maxSpeed = 0;
//    }
//    public Car(string v, string m, int y, string n, double vo, int mS) : base(v, m, y, n)
//    {
//        volume = vo;
//        maxSpeed = mS;
//    }

//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Engine volume: {volume}");
//        Console.WriteLine($"Max speed: {maxSpeed}");
//        Console.WriteLine();
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//        Console.WriteLine();
//    }

//    public void Sound()
//    {
//        Console.WriteLine("brum brum.....");
//        Console.WriteLine();
//    }
//}
//class Steamer : Gadget
//{
//    int size;

//    public int Size { get; set; }

//    public Steamer() : base()
//    {
//        size = 0;
//    }
//    public Steamer(string v, string m, int y, string n, int s) : base(v, m, y, n)
//    {
//        size = s;
//    }

//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Sizw: {size}");
//        Console.WriteLine();
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//        Console.WriteLine();
//    }

//    public void Sound()
//    {
//        Console.WriteLine("pshhhhhh.........");
//        Console.WriteLine();
//    }

//}



////TASK 3

//class SongInstr
//{
//    private string type;
//    private string name_Singer;
//    private string popular_song;
//    private string name;

//    public string Type { get; set; }

//    public string Name_Singer { get; set; }

//    public string Popular_Song { get; set; }

//    public string Name { get; set; }

//    public SongInstr()
//    {
//        type = "No type";
//        name_Singer = "No singer";
//        popular_song = "No song";
//        name = "Noname";
//    }

//    public SongInstr(string t, string nS, string pS, string n)
//    {
//        type = t;
//        name_Singer = nS;
//        popular_song = pS;
//        name = n;
//    }

//    public virtual void ShowInfo()
//    {
//        Console.WriteLine($"Name: {name}");
//    }

//    public virtual void DescInfo()
//    {
//        Console.WriteLine($"The most popular singer: {name_Singer}");
//        Console.WriteLine($"The most popular song: {popular_song}");
//        Console.WriteLine($"Type: {type}");
//    }



//}

//class Violin : SongInstr
//{
//    private int countOfStrings;

//    public int CounOfStrings { get; set; }

//    public Violin() : base()
//    {
//        countOfStrings = 0;
//    }
//    public Violin(string t, string nS, string pS, string n, int cOs) : base(t, nS, pS, n)
//    {
//        countOfStrings += cOs;
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//    }
//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Count of strings: {countOfStrings}");
//    }

//    public void Sound()
//    {
//        Console.WriteLine("zing zing........");
//    }

//    public void ShowHistory()
//    {
//        Console.WriteLine("The violin, also known as the \"fiddle,\" originated in Italy during the 16th century. It evolved from earlier string instruments like the lira da braccio and the rebec. By the 17th century, it became a prominent instrument in classical music, with makers like Stradivari and Guarneri perfecting its design. Today, it's used in various genres, from classical to folk and jazz.");
//    }

//}

//class Trombone : SongInstr
//{
//    private string where_sing;

//    public string Where_Sing { get; set; }

//    public Trombone() : base()
//    {
//        where_sing = "Any data";
//    }

//    public Trombone(string t, string nS, string pS, string n, string wS) : base(t, nS, pS, n)
//    {
//        where_sing = wS;
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//    }
//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Where singing: {where_sing}");
//    }
//    public void Sound()
//    {
//        Console.WriteLine("doo-doo-dooo......");
//    }
//    public void ShowHistory()
//    {
//        Console.WriteLine("The trombone originated in the 15th century, evolving from the sackbut, a Renaissance brass instrument. Its name comes from the Italian word \"tromba,\" meaning \"trumpet,\" with the suffix \"-one\" indicating \"large.\" The trombone became integral in orchestras, brass bands, and jazz music.");
//    }
//}

//class Ukulele : SongInstr
//{
//    private int countOfStrings;

//    public int ConuntOfStrings { get; set; }

//    public Ukulele() : base()
//    {

//    }

//    public Ukulele(string t, string nS, string pS, string n, int cOs) : base(t, nS, pS, n)
//    {
//        countOfStrings = cOs;
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//    }

//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Count of strings: {countOfStrings}");
//    }

//    public void Sound()
//    {
//        Console.WriteLine("ting-ting-ting...........");
//    }
//    public void ShowHistory()
//    {
//        Console.WriteLine("The ukulele originated in Hawaii in the late 19th century, inspired by the Portuguese machete, a small guitar-like instrument brought by immigrants. Its name means \"jumping flea\" in Hawaiian, reflecting the quick movement of players' fingers. The ukulele gained worldwide popularity in the 20th century for its light, happy sound.");
//    }


//}

//class Cello : SongInstr
//{
//    private int countOfStrings;

//    public int CountOfStrings { get; set; }

//    public Cello() : base()
//    {
//        countOfStrings = 0;
//    }
//    public Cello(string t, string nS, string pS, string n, int cOs) : base(t, nS, pS, n)
//    {
//        countOfStrings = cOs;
//    }

//    public override void ShowInfo()
//    {
//        base.ShowInfo();
//    }

//    public override void DescInfo()
//    {
//        base.DescInfo();
//        Console.WriteLine($"Count of strings: {countOfStrings}");
//    }
//    public void Sound()
//    {
//        Console.WriteLine("mmmm-woo................");
//    }

//    public void ShowHistory()
//    {
//        Console.WriteLine("The cello originated in the 16th century as part of the violin family, initially called the \"bass violin.\" It gained prominence in the Baroque period and became a staple of orchestras and chamber music. Its expressive range and deep, warm tone make it a favorite for both solo and ensemble performances.");
//    }
//}

////TASK 4

//class Worker
//{
//    private string name;
//    private string surname;
//    private string dadname;
//    private int age;
//    private string nationality;

//    public string Name { get; set; }

//    public string Surname { get; set; }

//    public string Dadname { get; set; }

//    public int Age { get; set; }

//    public string Nationality { get; set; }

//    public Worker()
//    {
//        name = "No name";
//        surname = "No surname";
//        dadname = "No dadname";
//        age = 0;
//        nationality = "No nationality";
//    }

//    public Worker(string n, string s, string d, int a, string na)
//    {
//        name = n;
//        surname = s;
//        dadname = d;
//        age = a;
//        nationality = na;
//    }

//    public virtual void Print()
//    {
//        Console.WriteLine($"PIB: {surname} {name} {dadname}");
//        Console.WriteLine($"Age: {age}");
//        Console.WriteLine($"Nationality: {nationality}");
//    }
//}

//class President : Worker
//{
//    private string country;

//    public string Country { get; set; }

//    public President() : base()
//    {
//        country = "No country";
//    }

//    public President(string n, string s, string d, int a, string na, string c) : base(n, s, d, a, na)
//    {
//        country = c;
//    }

//    public override void Print()
//    {
//        base.Print();
//        Console.WriteLine($"Country where president is: {country}");
//    }
//}

//class Security : Worker
//{
//    private string famous_person;

//    public string Famous_Person { get; set; }

//    public Security() : base()
//    {

//    }

//    public Security(string n, string s, string d, int a, string na, string f) : base(n, s, d, a, na)
//    {
//        famous_person = f;
//    }

//    public override void Print()
//    {
//        base.Print();
//        Console.WriteLine($"Famous person whose security secures: {famous_person} ");
//    }
//}

//class Manager : Worker
//{
//    private string directionality;

//    public string Directionality { get; set; }

//    public Manager() : base()
//    {
//        directionality = "No directionality";
//    }
//    public Manager(string n, string s, string d, int a, string na, string di) : base(n, s, d, a, na)
//    {
//        directionality = di;
//    }
//    public override void Print()
//    {
//        base.Print();
//        Console.WriteLine($"Directionality: {directionality}");
//    }
//}

//class Engineer : Worker
//{
//    private string directionality;

//    public string Directionality { get; set; }

//    public Engineer() : base()
//    {
//        directionality = "No directionality";
//    }
//    public Engineer(string n, string s, string d, int a, string na, string di) : base(n, s, d, a, na)
//    {
//        directionality = di;
//    }

//    public override void Print()
//    {
//        base.Print();
//        Console.WriteLine($"Directionality: {directionality}");
//    }
//}