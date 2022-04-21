--Welcome to Employee Payroll Service Problem--

create database Payroll_Service
use Payroll_Service

create table EmployeePayroll(
Emp_ID int identity(1,1) not null Primary key,
Name varchar(50),
Salary bigint,
StartDate datetime
)
insert into EmployeePayroll (Name,Salary,StartDate) values 
('Ankita',30000,'2022-01-04'),
('Golu',40000,'2021-05-18'),
('Bill',533500,'2018-05-25'),
('Charlie',350640,'2017-11-25')

select * from EmployeePayroll


select Salary from EmployeePayroll where Name = 'Bill'
select Name from EmployeePayroll WHERE StartDate BETWEEN CAST('2018-01-01'AS DATE) AND '2022-04-21';

alter table EmployeePayroll add Gender varchar(1)

update EmployeePayroll set Gender = 'M'
update EmployeePayroll set Gender = 'F' where Name = 'Ankita'

select Gender, sum(Salary) as TotalSalary from EmployeePayroll group by Gender
select Gender, avg(Salary) as AverageSalary from EmployeePayroll group by Gender
select Gender, min(Salary) as Minimum from EmployeePayroll group by Gender
select Gender, max(Salary) as Maximum from EmployeePayroll group by Gender
select Gender, count(*) as MaleorFemale from EmployeePayroll group by Gender

create table EmployeeDepartment(
ID int not null,
Department varchar(50) not null,
Phone bigint, 
Address varchar(100),
)

insert into EmployeeDepartment(ID,Department,Phone,Address) values
(1,'Hospitality',9545454545,'MP'),
(2,'HR',9574747485,'UP'),
(3,'IT',9414141411,'Delhi'),
(4,'Management',9132456783,'Mumbai'),
(5,'Sales',978945612,'Pune'),
(6,'IT',941526398,'Raipur')

select * from EmployeeDepartment

select EmployeePayroll.Emp_ID, Name, Salary, StartDate, Gender, Department, Phone, Address
from EmployeePayroll 
left join EmployeeDepartment on EmployeePayroll.Emp_ID = EmployeeDepartment.ID