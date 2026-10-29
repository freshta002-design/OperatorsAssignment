using System;

namespace EmployeeComparisonApp
{
    // Step 1: Create an Employee class with Id, FirstName, and LastName properties.
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Step 2: Overload the "==" operator (and its paired "!=" operator).
        // Comparison operators must be overloaded in pairs in C#.
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Handle null checks to prevent NullReferenceException
            if (ReferenceEquals(emp1, emp2))
            {
                return true;
            }

            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
            {
                return false;
            }

            // Compare two Employee objects by checking if their Id properties are equal
            return emp1.Id == emp2.Id;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // It is also a best practice to override Equals and GetHashCode when overloading operators
        public override bool Equals(object obj)
        {
            if (obj is Employee otherEmployee)
            {
                return this.Id == otherEmployee.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Step 3: Instantiate two objects of the Employee class and assign values to their properties.
            
            // First employee instance
            Employee employee1 = new Employee()
            {
                Id = 101,
                FirstName = "John",
                LastName = "Doe"
            };

            // Second employee instance (sharing the same Id to test equality)
            Employee employee2 = new Employee()
            {
                Id = 101,
                FirstName = "Jane",
                LastName = "Smith"
            };

            // Third employee instance with a different Id
            Employee employee3 = new Employee()
            {
                Id = 102,
                FirstName = "Alice",
                LastName = "Johnson"
            };

            // Display initial employee details
            Console.WriteLine($"Employee 1: ID = {employee1.Id}, Name = {employee1.FirstName} {employee1.LastName}");
            Console.WriteLine($"Employee 2: ID = {employee2.Id}, Name = {employee2.FirstName} {employee2.LastName}");
            Console.WriteLine($"Employee 3: ID = {employee3.Id}, Name = {employee3.FirstName} {employee3.LastName}");
            Console.WriteLine(new string('-', 50));

            // Compare the two employee objects using the newly overloaded operators and display the results.
            
            // Comparing Employee 1 and Employee 2 (Same ID: 101)
            bool areEqual1And2 = (employee1 == employee2);
            Console.WriteLine($"Comparing Employee 1 and Employee 2 (using ==): Are they equal? {areEqual1And2}");

            // Comparing Employee 1 and Employee 3 (Different IDs: 101 vs 102)
            bool areEqual1And3 = (employee1 == employee3);
            Console.WriteLine($"Comparing Employee 1 and Employee 3 (using ==): Are they equal? {areEqual1And3}");

            // Testing the overloaded != operator as well
            bool areNotEqual = (employee1 != employee3);
            Console.WriteLine($"Comparing Employee 1 and Employee 3 (using !=): Are they not equal? {areNotEqual}");

            // Keep console open
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}