--Welcome to Employee Payroll Service Problem--

create database Payroll_Service
use Payroll_Service

create table EmployeePayroll(
Emp_ID int identity(1,1) not null Primary key,
Name varchar(50),
Salary bigint,
StartDate datetime
)