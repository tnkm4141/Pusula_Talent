using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;

namespace Pusula
{
    public class FilterPeopleFromXmlClass
    {
        public static string FilterPeopleFromXml(string xmlData)
        {
            if (string.IsNullOrWhiteSpace(xmlData))
                return JsonSerializer.Serialize(new
                {
                    Names = new List<string>(),
                    TotalSalary = 0,
                    AverageSalary = 0,
                    MaxSalary = 0,
                    Count = 0
                });

            var doc = XDocument.Parse(xmlData);

            var people = doc.Descendants("Person")
                .Select(p => new
                {
                    Name = (string)p.Element("Name"),
                    Age = (int)p.Element("Age"),
                    Department = (string)p.Element("Department"),
                    Salary = (decimal)p.Element("Salary"),
                    HireDate = DateTime.Parse((string)p.Element("HireDate"))
                })
                .Where(p => p.Age > 30
                            && p.Department == "IT"
                            && p.Salary > 5000
                            && p.HireDate < new DateTime(2019, 1, 1))
                .ToList();

            var names = people.Select(p => p.Name).OrderBy(n => n).ToList();
            var totalSalary = people.Sum(p => p.Salary);
            var avgSalary = people.Count > 0 ? people.Average(p => p.Salary) : 0;
            var maxSalary = people.Count > 0 ? people.Max(p => p.Salary) : 0;

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = avgSalary,
                MaxSalary = maxSalary,
                Count = people.Count
            };

            return JsonSerializer.Serialize(result);
        }
    }
}
