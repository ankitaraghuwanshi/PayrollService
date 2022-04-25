use [Payroll_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdateDetails]
@ID int,
@Salary bigint
AS
SET NOCOUNT ON
BEGIN
begin try
begin transaction	
declare @Row_Count integer
update Employee_Payroll Set Salary = @Salary where Emp_ID = @ID

select EmployeePayroll.Emp_ID, Name, Salary, StartDate, Gender, Department, Phone, Address, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from EmployeePayroll 
left join EmployeeDepartment on EmployeePayroll.Emp_ID = EmployeeDepartment.ID
left join Payroll on EmployeePayroll.Emp_ID = Payroll.ID

	select @Row_Count = @@ROWCOUNT
commit transaction
end try
begin catch
select ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage
if(XACT_STATE())=-1
	begin
		print
			'Transaction is Uncommitable' + 'Rolling back Transaction'
		rollback transaction
	end
else if(XACT_STATE())=1
	begin
		print
			'Transaction is Commitable'
		commit transaction
	end
else
	begin
		print
			'Transaction Failed'
		rollback transaction
	end
end catch
return @Row_Count
END
GO