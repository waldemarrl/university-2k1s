use UNIVER;
declare @k nvarchar(30), @all nvarchar(500) = ' ';
declare OUTPUT cursor for select TEACHER_NAME from TEACHER where PULPIT = '����'
open OUTPUT 
fetch OUTPUT into @k;
print '����� ��������'
while @@fetch_status = 0
begin 
set @all = RTRIM(@k) + ' , ' + @all;
fetch OUTPUT into @k;
end;
print RTRIM(@all) + '�����'
close OUTPUT