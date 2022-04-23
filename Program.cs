
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
            
             program.EstablishConnection();
            Console.WriteLine("Welcome to EmployeePayroll ADO.NET");
            Console.WriteLine("Connection establised");
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

    }
}