use UNIVER;
declare @k nvarchar(30), @all nvarchar(500) = ' ';
declare OUTPUT cursor for select TEACHER_NAME from TEACHER where PULPIT = 'ИСиТ'
open OUTPUT 
fetch OUTPUT into @k;
print 'Вывод учителей'
while @@fetch_status = 0
begin 
set @all = RTRIM(@k) + ' , ' + @all;
fetch OUTPUT into @k;
end;
print RTRIM(@all) + 'Конец'
close OUTPUT