using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pusula
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //1.soru
            var result1 = MaxIncreasingSubArrayAsJsonClass.MaxIncreasingSubArrayAsJson(new List<int> { 1, 2, 3, 1, 2 });
            Console.WriteLine("Soru 1 sonucu: " + result1);
            Console.WriteLine();

            // 2. soru
            var result2 = LongestVowelSubsequenceAsJsonClass.LongestVowelSubsequenceAsJson(new List<string> { "miscellaneous", "queue", "sky", "cooperative" });
            Console.WriteLine("Soru 2 sonucu: " + result2);
            Console.WriteLine();

            // 3. soru
            string xml = @"<People><Person><Name>Ali</Name><Age>35</Age><Department>IT</Department><Salary>6000</Salary><HireDate>2018-06-01</HireDate></Person></People>";
            var result3 = FilterPeopleFromXmlClass.FilterPeopleFromXml(xml);
            Console.WriteLine("Soru 3 sonucu: " + result3);
            Console.WriteLine();

            // 4. soru
            var employees = new List<(string, int, string, decimal, DateTime)>
        {
            ("Ali", 30, "IT", 6000m, new DateTime(2018, 5, 1)),
            ("Ayşe", 35, "Finance", 8500m, new DateTime(2019, 3, 15)),
            ("Veli", 28, "IT", 7000m, new DateTime(2020, 1, 1))
        };

            var result4 = FilterEmployeesClass.FilterEmployees(employees);
            Console.WriteLine("Soru 4 sonucu: " + result4);
            Console.ReadLine();
        }
    }
}
