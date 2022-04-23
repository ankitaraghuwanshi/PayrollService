
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayroll
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Welcome to EmployeePayroll ADO.NET");
            program.EstablishConnection();
            Console.WriteLine("Connection establised");
            GetEmployeesPayrollData();

        }
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=SSPI";
        static SqlConnection connection = new SqlConnection(connectionString);
        public void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();

                }
                catch (Exception)
                {
                    throw new Exceptions(Exceptions.ExceptionType.ConnectionFailed, "Connection Failed.");
                }
            }
            static void ClosedConnection()
            {
                if (connection != null && connection.State.Equals(ConnectionState.Open))
                {
                    try
                    {
                        connection.Close();
                    }
                    catch
                    {
                        throw new Exceptions(Exceptions.ExceptionType.ConnectionFailed, "Connection Failed.");
                    }

                }

            }
        }
        public static List<Employee> GetEmployeesPayrollData()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            SqlConnection connection = new SqlConnection(connectionString);
            string Spname = "dbo.GetEmployeeDetails";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(Spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        emp.Emp_Id = reader.GetInt32(0);
                        emp.Name = reader.GetString(1);
                        emp.Salary = reader.GetInt64(2);
                        emp.StartDate = reader.GetDateTime(3).Date;
                        emp.Gender = reader.GetString(4);
                        emp.Department = reader.GetString(5);
                        emp.Phone = reader.GetInt64(6);
                        emp.Address = reader.GetString(7);
                        emp.BasicPay = reader.GetInt64(8);
                        emp.Deduction = reader.GetInt64(9);
                        emp.TaxablePay = reader.GetInt64(10);
                        emp.IncomeTax = reader.GetInt64(11);
                        emp.NetPay = reader.GetInt64(12);
                        employees.Add(emp);
                        Console.WriteLine(emp.Emp_Id + "," + emp.Name + "," + emp.Salary + "," + emp.StartDate + "," + emp.Gender + "," + emp.Department + "," + emp.Phone + "," + emp.Address + "," + emp.BasicPay + "," + emp.Deduction + "," + emp.TaxablePay + "," + emp.IncomeTax + "," + emp.NetPay);
                    }
                }
                connection.Close();
            }
            return employees;
        }

    }
}















