using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[]args)
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            var test = "test";
            if (test[1] == 'e')
            {
                Console.WriteLine(square(add(12, 12)));
            }
            Console.WriteLine(square(3));

            var developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Hayden"},
                new Employee {Id = 2, Name = "Dylan"}
            };

            var sales = new List<Employee>()
            {
                new Employee {Id = 3, Name="Becca"}
            };

            var query = developers.Where
                (employee => employee.Name.Length == 6)
                .OrderBy(employee => employee.Name);

            var query2 = from developer in developers
                         where developer.Name.Length == 6
                         orderby developer.Name
                         select developer;
            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }
            foreach (var employee in query2)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithH(Employee employee)
        {
            return employee.Name.StartsWith("H");
        }
 
    }
}

