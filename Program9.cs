// Завдання 1: Океанаріум

using System.Collections;
using System.Collections.Generic;

class Oceanarium : IEnumerable<SeaCreature>
{
    private List<SeaCreature> creatures = new List<SeaCreature>();

    public void AddCreature(SeaCreature creature)
    {
        creatures.Add(creature);
    }

    public IEnumerator<SeaCreature> GetEnumerator()
    {
        return creatures.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class SeaCreature
{
    public string Name { get; set; }
    public string Species { get; set; }

    public SeaCreature(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Species: {Species}";
    }
}

// Завдання 2: Футбольна Команда
class FootballTeam : IEnumerable<Player>
{
    private List<Player> players = new List<Player>();

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public IEnumerator<Player> GetEnumerator()
    {
        return players.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Player
{
    public string Name { get; set; }
    public string Position { get; set; }

    public Player(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Position: {Position}";
    }
}

// Завдання 3: Кафе
class Cafe : IEnumerable<Employee>
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        return employees.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Employee
{
    public string Name { get; set; }
    public string Role { get; set; }

    public Employee(string name, string role)
    {
        Name = name;
        Role = role;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Role: {Role}";
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        // Тестування Океанаріуму
        var oceanarium = new Oceanarium();
        oceanarium.AddCreature(new SeaCreature("Dolphin", "Mammal"));
        oceanarium.AddCreature(new SeaCreature("Shark", "Fish"));

        Console.WriteLine("Oceanarium Creatures:");
        foreach (var creature in oceanarium)
        {
            Console.WriteLine(creature);
        }

        // Тестування Футбольної Команди
        var footballTeam = new FootballTeam();
        footballTeam.AddPlayer(new Player("John", "Goalkeeper"));
        footballTeam.AddPlayer(new Player("Mike", "Defender"));

        Console.WriteLine("\nFootball Team Players:");
        foreach (var player in footballTeam)
        {
            Console.WriteLine(player);
        }

        // Тестування Кафе
        var cafe = new Cafe();
        cafe.AddEmployee(new Employee("Alice", "Barista"));
        cafe.AddEmployee(new Employee("Bob", "Chef"));

        Console.WriteLine("\nCafe Employees:");
        foreach (var employee in cafe)
        {
            Console.WriteLine(employee);
        }
    }
}
