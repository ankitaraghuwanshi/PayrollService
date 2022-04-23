USE [Payroll_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [GetEmployeeDetails]
AS
BEGIN
select EmployeePayroll.Emp_ID, Name, Salary, StartDate, Gender, Department, Phone, Address, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from EmployeePayroll 
left join EmployeeDepartment on EmployeePayroll.Emp_ID = EmployeeDepartment.ID
left join Payroll on EmployeePayroll.Emp_ID = Payroll.ID

END
GO