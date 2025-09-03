using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pusula
{
    public class FilterEmployeesClass
    {
        public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            var filtered = employees
                .Where(e => e.Age >= 25 && e.Age <= 40)
                .Where(e => e.Department == "IT" || e.Department == "Finance")
                .Where(e => e.Salary >= 5000 && e.Salary <= 9000)
                .Where(e => e.HireDate > new DateTime(2017, 1, 1))
                .ToList();

            var names = filtered
                .Select(e => e.Name)
                .OrderByDescending(n => n.Length)   // uzunluk azalan
                .ThenBy(n => n)                     // alfabetik
                .ToList();

            var totalSalary = filtered.Sum(e => e.Salary);
            var avgSalary = filtered.Count > 0 ? filtered.Average(e => e.Salary) : 0;
            var minSalary = filtered.Count > 0 ? filtered.Min(e => e.Salary) : 0;
            var maxSalary = filtered.Count > 0 ? filtered.Max(e => e.Salary) : 0;

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = Math.Round(avgSalary, 2), // küsuratları düzenlemek için
                MinSalary = minSalary,
                MaxSalary = maxSalary,
                Count = filtered.Count
            };

            return JsonSerializer.Serialize(result);
        }
    }
}
