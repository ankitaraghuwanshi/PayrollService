using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class DetailsOfEmp
    {
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
        public  List<Employee> GetEmployeesPayrollData()
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
        public  Employee UpdateSalary(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string Spname = "dbo.[UpdateDetails]";
                    SqlCommand command = new SqlCommand(Spname, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Action", "Update");
                    command.Parameters.AddWithValue("@Emp_Id", employee.Emp_Id);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);

                    employee = new Employee();
                    connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.Emp_Id = (int)sqlDataReader["Emp_Id"];
                            employee.Name = (string)sqlDataReader["Name"];
                            employee.Salary = (Int64)sqlDataReader["Salary"];
                            employee.StartDate = (DateTime)sqlDataReader["StartDate"];
                            employee.Gender = (string)sqlDataReader["Gender"];
                            employee.Department = (string)sqlDataReader["Department"];
                            employee.Phone = (Int64)sqlDataReader["Phone"];
                            employee.Address = (string)sqlDataReader["Address"];
                            employee.BasicPay = (Int64)sqlDataReader["BasicPay"];
                            employee.Deduction = (Int64)sqlDataReader["Deduction"];
                            employee.TaxablePay = (Int64)sqlDataReader["TaxablePay"];
                            employee.IncomeTax = (Int64)sqlDataReader["IncomeTax"];
                            employee.NetPay = (Int64)sqlDataReader["NetPay"];


                        }
                        if (employee == null)
                        {
                            throw new Exceptions(Exceptions.ExceptionType.NoDataFound, "No data found");
                        }
                    }

                    connection.Close();
                }


                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
       
    }
}
