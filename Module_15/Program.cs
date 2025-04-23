namespace Module_15;

class Program
{
    static void Main(string[] args)
    {
        var cars = new List<Car>()
        {
            new Car() { Model = "SX4", Manufacturer = "Suzuki" },
            new Car() { Model = "Grand Vitara", Manufacturer = "Suzuki" },
            new Car() { Model = "Jimny", Manufacturer = "Suzuki" },
            new Car() { Model = "Land Cruiser Prado", Manufacturer = "Toyota" },
            new Car() { Model = "Camry", Manufacturer = "Toyota" },
            new Car() { Model = "Polo", Manufacturer = "Volkswagen" },
            new Car() { Model = "Passat", Manufacturer = "Volkswagen" },
        };

        var manufacturers = new List<Manufacturer>()
        {
            new Manufacturer() { Country = "Japan", Name = "Suzuki" },
            new Manufacturer() { Country = "Japan", Name = "Toyota" },
            new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
        };

        var result = from car in cars
            join m in manufacturers on car.Manufacturer equals m.Name
            select new
            {
                Name = car.Model,
                Manufacturer = m.Name,
                Country = m.Country
            };

        foreach (var item in result)
            Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");

        Console.WriteLine();

        var result2 = cars
            .Join(
                manufacturers,
                car => car.Manufacturer,
                m => m.Name
                , (car, m) => new
                {
                    Name = car.Model,
                    Manufacturer = m.Name,
                    Country = m.Country
                });

        foreach (var item in result2)
            Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");

        Console.WriteLine();

        var result3 = manufacturers.GroupJoin(cars,
            m => m.Name,
            car => car.Manufacturer,
            (m, crs) => new
            {
                Name = m.Name,
                Country = m.Country,
                Cars = crs.Select(c => c.Model)
            });

        foreach (var item in result3)
        {
            Console.WriteLine($"{item.Name} ({item.Country}):");

            foreach (var model in item.Cars)
                Console.WriteLine($"{model}");

            Console.WriteLine();
        }

        Console.WriteLine();

        var departments = new List<Department>()
        {
            new() { Id = 1, Name = "Программирование" },
            new() { Id = 2, Name = "Продажи" }
        };

        var employees = new List<Employee>()
        {
            new() { DepartmentId = 1, Name = "Инна", Id = 1 },
            new() { DepartmentId = 1, Name = "Андрей", Id = 2 },
            new() { DepartmentId = 2, Name = "Виктор ", Id = 3 },
            new() { DepartmentId = 3, Name = "Альберт ", Id = 4 },
        };

        var resultWorkers = from employee in employees
            join d in departments on employee.DepartmentId equals d.Id
            select new
            {
                Name = employee.Name,
                Department = d.Name
            };

        foreach (var item in resultWorkers)
            Console.WriteLine($"{item.Name}, отдел {item.Department}");

        Console.WriteLine();

        var resultWorkers2 = employees
            .Join(departments,
                employee => employee.DepartmentId,
                d => d.Id,
                (employee, d) => new
                {
                    Name = employee.Name,
                    Department = d.Name
                });

        foreach (var item in resultWorkers2)
            Console.WriteLine($"{item.Name}, отдел {item.Department}");

        Console.WriteLine();

        var resultWorker3 = departments.GroupJoin(
            employees,
            d => d.Id,
            emp => emp.DepartmentId,
            (d, emps) => new
            {
                Department = d.Name,
                Employees = emps.Select(e => e.Name)
            });

        foreach (var item in resultWorker3)
        {
            Console.WriteLine($"Отдел \"{item.Department}\":");

            foreach (var employee in item.Employees)
                Console.WriteLine($"Сотрудник {employee}");

            Console.WriteLine();
        }

        Console.WriteLine();

        var letters = new string[] { "A", "B", "C", "D", "E" };
        var numbers = new int[] { 1, 2, 3 };

        var res = letters.Zip(numbers, (l, n) => $"{l}{n}");

        foreach (var item in res)
            Console.WriteLine(item);
    }

    public class Car
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }

    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}