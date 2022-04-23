using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public long BasicPay { get; set; }
        public long Deduction { get; set; }
        public long TaxablePay { get; set; }
        public long IncomeTax { get; set; }
        public long NetPay { get; set; }
    }
}
