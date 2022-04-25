
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
            Console.WriteLine("Welcome to EmployeePayroll ADO.NET");
            Employee employee = new Employee();
            DetailsOfEmp detailsOfEmp = new DetailsOfEmp();
            int option = 0;
            do
            {
                Console.WriteLine("1: for EstablishConnection");
                Console.WriteLine("2: for get All data");
                Console.WriteLine("3: for Updating Salary");
                Console.WriteLine("4: for Get the Emplyoee Data in Date range");
                Console.WriteLine("0: For Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        detailsOfEmp.EstablishConnection();
                        Console.WriteLine("Connection Establish");
                        break;
                    case 2:
                        detailsOfEmp.GetEmployeesPayrollData();
                        Console.WriteLine("");
                        break;
                    case 3:
                        detailsOfEmp.UpdateSalary(employee);
                        Console.WriteLine("Data updated");
                        break;
                    case 4:
                        var fromDate = Convert.ToDateTime("2020-11-25");
                        var ToDate = Convert.ToDateTime("2022-04-01");
                        detailsOfEmp.EmployeeDataInDateRange(fromDate, ToDate);
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            while (option != 0);
        }



    }

    
}















