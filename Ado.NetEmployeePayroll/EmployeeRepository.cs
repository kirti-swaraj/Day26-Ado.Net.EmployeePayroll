// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Ado.NetEmployeePayroll
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class EmployeeRepository
    {
        public static SqlConnection connection { get; set; }

        /// <summary>
        /// UC 2 : Gets all employees details.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllEmployees()
        {
           //Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.employee_payroll";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeID = reader.GetInt32(0);
                            model.EmployeeName = reader.GetString(1);
                            model.StartDate = reader.GetDateTime(2);
                            model.Gender = reader.GetString(3);
                            model.PhoneNumber = reader.GetInt64(4);
                            model.Address = reader.GetString(5);
                            model.Department = reader.GetString(6);
                            model.BasicPay = reader.GetDouble(7);
                            model.Deductions = reader.GetDouble(8);
                            model.TaxablePay = reader.GetDouble(9);
                            model.Tax = reader.GetDouble(10);
                            model.NetPay = reader.GetDouble(11);
                            Console.WriteLine("EmpId:{0}\nEmpName:{1}\nStartDate:{2}\nGender:{3}\nPhoneNumber:{4}\nAddress:{5}\nDepartment:{6}\nBasicPay:{7}\nDeductions:{8}\nTaxablePay:{9}\nTax:{10}\nNetPay:{11}", model.EmployeeID, model.EmployeeName, model.StartDate.ToShortDateString(), model.Gender, model.PhoneNumber, model.Address, model.Department, model.BasicPay, model.Deductions, model.TaxablePay, model.Tax, model.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.EmployeeName);
                    command.Parameters.AddWithValue("@start", model.StartDate);
                    command.Parameters.AddWithValue("@gender", model.Gender);
                    command.Parameters.AddWithValue("@phone_number", model.PhoneNumber);
                    command.Parameters.AddWithValue("@address", model.Address);
                    command.Parameters.AddWithValue("@department", model.Department);
                    command.Parameters.AddWithValue("@Basic_Pay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@Taxable_pay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Income_tax", model.Tax);
                    command.Parameters.AddWithValue("@Net_pay", model.NetPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 3 : Updates the given empname with given salary into database.
        /// </summary>
        /// <param name="empName">Name of the emp.</param>
        /// <param name="basicPay">The basic pay.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateSalaryIntoDatabase(string empName, float basicPay)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = @"update dbo.employee_payroll set BasicPay=@p1 where EmpName=@p2";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p1", basicPay);
                    command.Parameters.AddWithValue("@p2", empName);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}