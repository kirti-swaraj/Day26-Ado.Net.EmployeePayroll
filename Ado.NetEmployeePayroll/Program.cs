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
            //UC 2
            EmployeeRepository repository1 = new EmployeeRepository();
            repository1.GetAllEmployees();

            //Adding new employee details
            EmployeeRepository repository2 = new EmployeeRepository();
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

            Console.WriteLine(repository2.AddEmployee(model) ? "Record inserted successfully " : "Failed");
        }
    }
}