//Task 1

//string pattern = @"[a-z]|[A-Z]|[0-9]|[\.]+@[a-zA-Z]+\.[a-zA-Z]+";
//var regex = new Regex(pattern);
//bool flag = true;
//while (flag)
//{
//    string @string = Console.ReadLine();
//    if (@string == null)
//    {
//        flag = false;
//    }
//    bool success = regex.IsMatch(@string);
//    Console.WriteLine(success ? $" match found \"{pattern}" : $" match NOT found \"{pattern}\"");
//}

//TASK 2

//using System.Text.RegularExpressions;

//string pattern = @"\+[0-9]{5,}|[0-9]{5,}";
//var regex = new Regex(pattern);
//var array = new[] { "+380454454525", "0454454525", "380454454525", ".+380454454525", "test123" };

//foreach (string item in array)
//{
//    bool flag = regex.IsMatch(item);
//    if (flag)
//    {
//        Match match = Regex.Match(item, pattern);
//        if (match.Success)
//        {

//            Console.WriteLine(match.Value);
//        }
//        match = match.NextMatch();
//        if (match.Success)
//        {
//            Console.WriteLine(match.Value);
//        }
//        while (match.Success)
//        {
//            Console.WriteLine(match.Value);
//            match = match.NextMatch();
//        }
//    }
//    else
//    {
//        break;
//    }
//}


//TASK 3

//using System.Text.RegularExpressions;

//string pattern = @"([A-Z][a-z]|[0-9]|[\!]|[\@]|[\#]|[\$]|[\%]|[\^]|[\&]|[\*]).{8,}";
//var regex = new Regex(pattern);
//bool flag = true;
//while (flag)
//{
//    string @string = Console.ReadLine();
//    if (@string == null)
//    {
//        flag = false;
//    }
//    bool success = regex.IsMatch(@string);
//    Console.WriteLine(success ? $" match found \"{pattern}" : $" match NOT found \"{pattern}\"");
//}



using System.Text.RegularExpressions;

class Program
{


    static void Main()
    {

        // TASK 4
        string text = "Here are some URLs: http://example.com, https://example.com/path, www.example.com, ww.exsaple.com";
        var urls = ExtractUrls(text);

        Console.WriteLine("Extracted URLs:");
        foreach (var url in urls)
        {
            Console.WriteLine(url);

        }

        //TASK 5

        string text1 = "Here are some dates: 31/12/2023, 29-02-2024, 30/02/2023, 15/08/2022.";
        var dates = ExtractValidDates(text);

        Console.WriteLine("Valid dates:");
        foreach (var date in dates)
        {
            Console.WriteLine(date);
        }
    }
    static List<string> ExtractUrls(string text)
    {
       
        string pattern = @"(http(s)?://[^\s]+|www\.[^\s]+)";
        var matches = Regex.Matches(text, pattern);

        List<string> urls = new List<string>();
        foreach (Match match in matches)
        {
            urls.Add(match.Value);
        }

        return urls;
    }

    //TASK 5

    static List<string> ExtractValidDates(string text1)
    {
       
        string pattern = @"\b(0[1-9]|[12][0-9]|3[01])[-/](0[1-9]|1[0-2])[-/](\d{4})\b";
        var matches = Regex.Matches(text1, pattern);

        List<string> validDates = new List<string>();

        foreach (Match match in matches)
        {
            string[] dateParts = match.Value.Split(new char[] { '/', '-' });
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

           
            if (IsValidDate(day, month, year))
            {
                validDates.Add(match.Value);
            }
        }

        return validDates;
    }

    static bool IsValidDate(int day, int month, int year)
    {
        try
        {
            DateTime date = new DateTime(year, month, day);
            return true;
        }
        catch
        {
            return false;
        }
    }

}
