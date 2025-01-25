using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Book
{
    [XmlElement("BookTitle")]
    public string Title { get; set; }

    [XmlElement("AuthorName")]
    public string Author { get; set; }

    [XmlElement("BookPrice")]
    public decimal Price { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public int InternalId { get; set; }
}

public static class SerializationHelper
{


    // Serialize to XML
    public static void SerializeToXml(List<Book> books, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<Book>));
        using var writer = new StreamWriter(filePath);
        serializer.Serialize(writer, books);
    }

    // Deserialize from XML
    public static List<Book> DeserializeFromXml(string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<Book>));
        using var reader = new StreamReader(filePath);
        return (List<Book>)serializer.Deserialize(reader);
    }
}

class Program
{
    static void Main()
    {
        // Create sample books
        var books = new List<Book>
        {
            new Book { Title = "1984", Author = "George Orwell", Price = 9.99m, InternalId = 1 },
            new Book { Title = "Brave New World", Author = "Aldous Huxley", Price = 12.99m, InternalId = 2 },
            new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Price = 10.99m, InternalId = 3 }
        };

        // File paths
        string xmlFilePath = "books.xml";

        // Serialize to XML
        SerializationHelper.SerializeToXml(books, xmlFilePath);

        Console.WriteLine("Serialization completed. Files saved.");

        // Deserialize from XML
        var deserializedFromXml = SerializationHelper.DeserializeFromXml(xmlFilePath);



        Console.WriteLine("\nDeserialized from XML:");
        foreach (var book in deserializedFromXml)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Price: {book.Price}");
        }
    }
}
