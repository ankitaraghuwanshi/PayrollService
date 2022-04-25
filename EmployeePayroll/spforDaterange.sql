use [Payroll_Service]
go
set ansi_nulls on
go
set quoted_identifier on
go

Alter  procedure [GetDetailBetweenDates]
@FromDate datetime,
@ToDate Date
as
begin
set nocount on
select EmployeePayroll.Emp_ID, Name, Salary, StartDate, Gender, Department, Phone, Address, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from EmployeePayroll 
left join EmployeeDepartment on EmployeePayroll.Emp_ID = EmployeeDepartment.ID
left join Payroll on EmployeePayroll.Emp_ID = Payroll.ID where StartDate between @FromDate and @ToDate; 

end
go