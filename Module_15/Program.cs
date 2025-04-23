namespace Module_15;

class Program
{
    static void Main(string[] args)
    {
        var cars = new List<Car>()
        {
            new Car("Suzuki", "JP"),
            new Car("Toyota", "JP"),
            new Car("Opel", "DE"),
            new Car("Kamaz", "RUS"),
            new Car("Lada", "RUS"),
            new Car("Honda", "JP"),
        };

        var carsByCountry = from car in cars
            group car by car.CountryCode;

        carsByCountry = cars.GroupBy(car => car.CountryCode);

        foreach (var group in carsByCountry)
        {
            Console.WriteLine(group.Key + ": ");

            foreach (var car in group)
            {
                Console.WriteLine(car.Manufacturer);
            }

            Console.WriteLine();
        }

        var carsByCountry2 = from car in cars
            group car by car.CountryCode
            into grouping
            select new
            {
                Name = grouping.Key,
                Count = grouping.Count(),
                Cars = from p in grouping select p
            };

        carsByCountry2 = cars
            .GroupBy(car => car.CountryCode)
            .Select(g => new
            {
                Name = g.Key,
                Count = g.Count(),
                Cars = g.Select(c => c)
            });

        foreach (var group in carsByCountry2)
        {
            Console.WriteLine($"{group.Name}: {group.Count}");

            foreach (var car in group.Cars)
                Console.WriteLine(car.Manufacturer);

            Console.WriteLine();
        }


        var phoneBook = new List<Contact>();

        phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
        phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

        var grouped = phoneBook.GroupBy(p => p.Email.Split('@').Last());
        foreach (var group in grouped)
        {
            if (group.Key.Contains("example"))
            {
                Console.WriteLine("Фейковые адреса:");
                foreach (var contact in group)
                    Console.WriteLine($"{contact.Name} {contact.PhoneNumber} {contact.Email}");
            }
            else
            {
                Console.WriteLine("Реальные адреса:");
                foreach (var contact in group)
                    Console.WriteLine($"{contact.Name} {contact.PhoneNumber} {contact.Email}");
            }
        }
    }

    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Car
    {
        public string Manufacturer { get; set; }
        public string CountryCode { get; set; }

        public Car(string brand, string country)
        {
            Manufacturer = brand;
            CountryCode = country;
        }
    }
}