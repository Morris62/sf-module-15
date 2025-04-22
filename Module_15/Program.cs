namespace Module_15;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = [1, 2, 3, 4, 5];
        Console.WriteLine($"numbers: {string.Join(", ", numbers)}");
        var result = numbers.Aggregate((x, y) => x - y);
        Console.WriteLine($"Aggregate((x, y) => x - y): {result}");

        var sum = numbers.Aggregate((x, y) => x + y);
        Console.WriteLine($"Aggregate((x, y) => x + y): {sum}");

        var factorial = Factorial(5);
        Console.WriteLine($"Factorial(5): {factorial}");

        var contacts = new List<Contact>()
        {
            new Contact() { Name = "Андрей", Phone = 79994500508 },
            new Contact() { Name = "Сергей", Phone = 799990455 },
            new Contact() { Name = "Иван", Phone = 79999675334 },
            new Contact() { Name = "Игорь", Phone = 8884994 },
            new Contact() { Name = "Анна", Phone = 665565656 },
            new Contact() { Name = "Василий", Phone = 3434 }
        };

        var invalidContacts = from contact in contacts
            let phone = contact.Phone.ToString()
            where !phone.StartsWith("7") && phone.Length != 11
            select contact;

        foreach (var contact in invalidContacts)
            Console.WriteLine($"{contact.Name} {contact.Phone}");

        int[] simpleNumbers = [3, 5, 7];
        var simpleNumberSum = simpleNumbers.Sum();
        Console.WriteLine($"Sum: {simpleNumberSum}");

        var students = new List<Student>
        {
            new() { Name = "Андрей", Age = 23 },
            new() { Name = "Сергей", Age = 27 },
            new() { Name = "Дмитрий", Age = 29 }
        };

        var totalAge = students.Sum(s => s.Age);
        Console.WriteLine($"TotalAge: {totalAge}");

        var average = Average([1, 5, 7, 9, 11]);
        Console.WriteLine($"Average: {average}");
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
    }

    static double Average(int[] numbers)
    {
        return numbers.Sum() / (double)numbers.Length;
    }

    static int Factorial(int number)
    {
        var numbers = new List<int>();
        for (int i = 1; i <= number; i++)
            numbers.Add(i);
        return numbers.Aggregate((x, y) => x * y);
    }
}