using ConsoleAppForLinq.Data;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static void Main(string[] args)
    {

        List<Employee> employeeList1 = Data.GetEmployees();



        var filteredEmployees = employeeList1.Where(emp => emp.AnnualSalary < 50000);

        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            Console.WriteLine($"Manager: {employee.IsManager}");
            Console.WriteLine();
        }

        List<Department> departmentList1 = Data.GetDepartments();

        var filteredDepartments = departmentList1.Where(dept => dept.ShortName == "TE" || dept.ShortName == "HR");

        foreach (var department in filteredDepartments)
        {
            Console.WriteLine($"Id: {department.Id}");
            Console.WriteLine($"Short Name: {department.ShortName}");
            Console.WriteLine($"Long Name: {department.LongName}");
            Console.WriteLine();
        }

        List<Employee> employeeList = Data.GetEmployees();
        List<Department> departmentList = Data.GetDepartments();

        var resultList = from emp in employeeList
                         join dept in departmentList
                         on emp.DepartmentId equals dept.Id
                         //  where dept.ShortName == "FN" || dept.ShortName == "TE"
                         select new
                         {
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             AnnualSalary = emp.AnnualSalary,
                             Manager = emp.IsManager,
                             Department = dept.LongName
                         };

        foreach (var employee in resultList)
        {
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            Console.WriteLine($"Manager: {employee.Manager}");
            Console.WriteLine($"Department: {employee.Department}");
            Console.WriteLine();
        }

        var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
        var highestAnnualSalary = resultList.Max(a => a.AnnualSalary);
        var lowestAnnualSalary = resultList.Min(a => a.AnnualSalary);

        Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");
        Console.WriteLine($"Highest Annual Salary: {highestAnnualSalary}");
        Console.WriteLine($"Lowest Annual Salary: {lowestAnnualSalary}");
        Console.ReadKey();

        //2.Section
        ////Equality Operator
        ////SequenceEqual
        var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
        var integerList2 = new List<int> { 1, 2, 3, 4, 5, 6 };

        var boolSequenceEqual = integerList1.SequenceEqual(integerList2);

        Console.WriteLine(boolSequenceEqual);
        var employeeListCompare = Data.GetEmployees();
        bool boolSE = employeeList.SequenceEqual(employeeListCompare, new EmployeeComparer());

        Console.WriteLine($"Result: {boolSE}");

        ////Concatenation Operator
        ////Concat
        List<int> integerList3 = new List<int> { 1, 2, 3, 4 };
        List<int> integerList4 = new List<int> { 5, 6, 7, 8, 9, 10 };

        IEnumerable<int> integerListConcat = integerList3.Concat(integerList4);

        foreach (var item in integerListConcat)
            Console.WriteLine(item);

        List<Employee> employeeList2 = new List<Employee> { new Employee { Id = 5, FirstName = "Tony", LastName = "Soprano" }, new Employee { Id = 6, FirstName = "Debbie", LastName = "Fred" } };

        IEnumerable<Employee> results1 = employeeList.Concat(employeeList2);

        foreach (var item in results1)
            Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10}");

        ////Aggregate Operators - Aggregate, Average, Count, Sum, Max
        ////Aggregate Operator
        //The initial seed value, which is 0 in this case (the starting value for the aggregation).
        //A lambda expression that defines the aggregation logic. (totAnnualSalary, e) => { ... }: This lambda expression takes two parameters:
        //totAnnualSalary: The accumulated total annual salary e: Each employee in the list during the aggregation.
        decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0, (totAnnualSalary, e) =>
        {
            var bonus = (e.IsManager) ? 0.04m : 0.02m;

            totAnnualSalary = (e.AnnualSalary + (e.AnnualSalary * bonus)) + totAnnualSalary;

            return totAnnualSalary;
        });

        Console.WriteLine($"Total Annual Salary of all employees (including bonus): {totalAnnualSalary}");
        //(s, e) => { ... }: This lambda expression takes two parameters:
        //s: The accumulated string, initially set to the seed value.
        // e: Each employee in the list during the aggregation.
        string data = employeeList.Aggregate<Employee, string, string>("Employee Annual Salaries (including bonus): ",//
            (s, e) =>
            {
                var bonus = (e.IsManager) ? 0.04m : 0.02m;

                s += $"{e.FirstName} {e.LastName} - {e.AnnualSalary + (e.AnnualSalary * bonus)}, ";
                return s;//returns the accumulated string
            }, s => s.Substring(0, s.Length - 2)//removes comma and space from the end
        );

        Console.WriteLine(data);

        ////Average
        decimal average = employeeList.Where(e => e.DepartmentId == 3).Average(e => e.AnnualSalary);

        Console.WriteLine($"Average Annual Salary (Technology Department): {average}");

        ////Count
        int countEmployees = employeeList.Count(e => e.DepartmentId == 3);

        Console.WriteLine($"Number of Employees (Technology Department): {countEmployees}");

        ////Sum
        decimal result1 = employeeList.Sum(e => e.AnnualSalary);
        Console.WriteLine($"Total Annual Salaries: {result1}");

        ////Max
        var result2 = employeeList.Max(e => e.AnnualSalary);
        Console.WriteLine($"Highest Annual Salary: {result2}");

        //Generation Operators - DefaultIfEmpty, Empty, Range, Repeat
        ////DefaultIfEmpty
        List<int> intList = new List<int>();
        var newList1 = intList.DefaultIfEmpty();//The DefaultIfEmpty method is typically used to ensure that a sequence has at least one element. If the sequence is empty, it provides a default value to prevent issues like null reference exceptions.

        Console.WriteLine(newList1.ElementAt(0));

        List<Employee> employees = new List<Employee>();
        var newList2 = employees.DefaultIfEmpty(new Employee { Id = 0 });

        var result3 = newList2.ElementAt(0);

        if (result3.Id == 0)
            Console.WriteLine($"The list is empty");

        ////Empty
        List<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();

        emptyEmployeeList.Add(new Employee { Id = 7, FirstName = "Dan", LastName = "Brown" });

        foreach (var item in emptyEmployeeList)
            Console.WriteLine($"{item.FirstName} {item.LastName}");

        ////Range Enumerable.Range(25, 20): This creates a sequence of integers starting from 25 and including the next 20 consecutive integers. In this case, it generates numbers from 25 to 44 (25 + 20 - 1). 
        var intCollection = Enumerable.Range(25, 20);
        foreach (var item in intCollection)
            Console.WriteLine(item);

        ////Repeat
        ///enumerable is commonly used to perform various operations on collections such as arrays, lists, and other types that implement the IEnumerable<T> interface.
        var strCollection = Enumerable.Repeat<string>("Placeholder", 10);
        foreach (var item in strCollection)
            Console.WriteLine(item);

        ////Set Operators - Distinct, Except, Intersect, Union
        ////Distinct
        List<int> list = new List<int> { 1, 2, 1, 4, 6, 2, 6, 7, 8, 7, 7, 7 };
        var results2 = list.Distinct();
        foreach (var item in results2)
            Console.WriteLine(item);

        ////Except
        IEnumerable<int> collection1 = new List<int> { 1, 2, 3, 4 };
        IEnumerable<int> collection2 = new List<int> { 3, 4, 5, 6 };

        var results3 = collection1.Except(collection2);
        foreach (var item in results3)
            Console.WriteLine(item);
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals([AllowNull] Employee x, [AllowNull] Employee y)
        {
            if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
