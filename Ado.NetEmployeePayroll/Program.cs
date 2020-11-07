// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Ado.NetEmployeePayroll
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository repository = new EmployeeRepository();
            //repository.GetFullTableDetails(); 
            //UC 3
            //Console.WriteLine(repository.UpdateSalaryIntoDatabase("Teressa", 30000) ? "Update done successfully " : "Update Failed");

            //UC 5
            repository.GetEmployeesFromForDateRange("2021 - 02 - 01");
        }

        /// <summary>
        /// Adds the new employee into the database.
        /// </summary>
        public static void AddNewEmployee()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "shreya";
            model.Address = "Hyderabad";
            model.BasicPay = 45;
            model.Deductions = 454;
            model.Department = "IT";
            model.Gender = "F";
            model.PhoneNumber = 983798;
            model.NetPay = 833;
            model.Tax = 32;
            model.StartDate = DateTime.Now;
            model.TaxablePay = 324;

           Console.WriteLine(repository.AddEmployee(model) ? "Record inserted successfully " : "Failed");
        }
    }
}