using Assignment2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeeManagement
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = ReadEmployeeDataFromCSV("D:\\employees.csv");

            var employeesByDepartment = employees.GroupBy(e => e.Department);

            foreach(var departmentalGroup in employeesByDepartment)
            {
                Console.WriteLine($" Department : {departmentalGroup.Key}");

                foreach(var employee in departmentalGroup)
                {
                    Console.WriteLine($"-{employee.FirstName} {employee.LastName}");
                }
            }

            var highestPaidProjectManager = employees
                .Where(e => e.JobTitle == "Project Manager")
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();
            Console.WriteLine($"The Highest Paid Project manager is {highestPaidProjectManager.FirstName}");

            var mostExperiencedWebDeveloper = employees
                .Where(e => e.JobTitle == "Web Developer")
                .OrderByDescending(e => e.Years)
                .FirstOrDefault();

            Console.WriteLine($"The most Experiedn Web developer is : {mostExperiencedWebDeveloper.FirstName}");

            var averageSalaryByJobTitle = employees
                .GroupBy(e => e.JobTitle)
                .Select(group => new
                {
                    JobTitle = group.Key,
                    AverageSalary = group.Average(e => e.Salary)

                });
            foreach ( var avgSalary in averageSalaryByJobTitle )
            {
                Console.WriteLine($"Average Salary of {avgSalary.JobTitle} is {avgSalary.AverageSalary
                    }");
            }

            var genderCounts = employees
                .GroupBy(e => e.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                    Count = group.Count()
                });
           foreach(var genderCount in genderCounts)
            {
                Console.WriteLine($"Number of {genderCount.Gender} Emplloyee is {genderCount.Count}");
            }
        }


        static List<Employee> ReadEmployeeDataFromCSV(string filePath)
        {
            
            List<Employee> employees = File.ReadLines(filePath)
                .Skip(1) 
                .Select(line => line.Split(','))
                .Select(data => new Employee
                {
                    FirstName = data[0],
                    LastName = data[1],
                    Email = data[2],
                    Phone = data[3],
                    Gender = data[4],
                    Age = int.Parse(data[5]),
                    JobTitle = data[6],
                    Years = int.Parse(data[7]),
                    Salary = double.Parse(data[8]),
                    Department = data[9]
                })
                .ToList();


            return employees;
        }
    }
}