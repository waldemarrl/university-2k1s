use UNIVER;
declare @k nvarchar(10), @all nvarchar(100) = ' '
declare OUTPUT cursor for select PULPIT from PULPIT where FACULTY= '����'
open OUTPUT
fetch OUTPUT into @k;
while @@FETCH_STATUS = 0
begin
if @k like '�%'
begin
set @all = RTRIM(@k) + ', ' + @all;
fetch OUTPUT into @k
end
else 
begin
fetch OUTPUT into @k
end
end;
print RTRIM(@all) + '�����'
close OUTPUT
