using System.Globalization;
namespace assignment3OOP
{
    
    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        SecurityOfficer
    }

    public class HireDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }

    public class Employee : IComparable<Employee>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        private string gender;
        public string Gender
        {
            get => gender;
            set
            {
                if (value != "M" && value != "F")
                    throw new ArgumentException("Gender must be 'M' or 'F'.");
                gender = value;
            }
        }
        public SecurityLevel SecurityLevel { get; set; }
        public decimal Salary { get; set; }
        public HireDate HireDate { get; set; }

        public Employee(int id, string name, string gender, SecurityLevel securityLevel, decimal salary, HireDate hireDate)
        {
            ID = id;
            Name = name;
            Gender = gender;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Gender: {Gender}, Security Level: {SecurityLevel}, " +
                   $"Salary: {Salary.ToString("C", CultureInfo.CurrentCulture)}, Hire Date: {HireDate}";
        }

        public int CompareTo(Employee other)
        {
            return DateTime.Compare(
                new DateTime(HireDate.Year, HireDate.Month, HireDate.Day),
                new DateTime(other.HireDate.Year, other.HireDate.Month, other.HireDate.Day)
            );
        }
    }

    public class Library
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }

            public Book(string title, string author, string isbn)
            {
                Title = title;
                Author = author;
                ISBN = isbn;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}";
            }
        }

        public class EBook : Book
        {
            public double FileSize { get; set; }

            public EBook(string title, string author, string isbn, double fileSize) : base(title, author, isbn)
            {
                FileSize = fileSize;
            }

            public override string ToString()
            {
                return base.ToString() + $", File Size: {FileSize}MB";
            }
        }

        public class PrintedBook : Book
        {
            public int PageCount { get; set; }

            public PrintedBook(string title, string author, string isbn, int pageCount) : base(title, author, isbn)
            {
                PageCount = pageCount;
            }

            public override string ToString()
            {
                return base.ToString() + $", Page Count: {PageCount}";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 3.Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions. (Employee [] EmpArr;)
            Employee[] employees =
            {
                new Employee(1, "Alice", "F", SecurityLevel.DBA, 5000, new HireDate(1, 1, 2020)),
                new Employee(2, "Bob", "M", SecurityLevel.Guest, 3000, new HireDate(5, 3, 2021)),
                new Employee(3, "Charlie", "M", SecurityLevel.SecurityOfficer, 7000, new HireDate(15, 7, 2019))
            };
            #endregion
            #region 4.Sort the employees based on their hire date then Print the sorted array.
            Array.Sort(employees);
            Console.WriteLine("Employees sorted by hire date:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            #endregion
            #region 5-Design a program for a library management system 
            var eBook = new Library.EBook("Digital C#", "John Doe", "12345", 5.2);
            var printedBook = new Library.PrintedBook("Learn C#", "Jane Doe", "67890", 350);

            Console.WriteLine("\nLibrary Books:");
            Console.WriteLine(eBook);
            Console.WriteLine(printedBook);
            #endregion
        }
    }
}
