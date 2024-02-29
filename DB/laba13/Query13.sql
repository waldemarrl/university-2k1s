create function FUNCTIN (@f nvarchar(50)) returns nvarchar(300) 
as
begin 
declare @all nvarchar(50) = ' ', @one nvarchar(300)
declare Out cursor local dynamic scroll for 
	select PULPIT.PULPIT
	from PULPIT
	where PULPIT.FACULTY = @f;
open Out
fetch last from Out into @one;
while @@FETCH_STATUS = 0
begin
	set @all = RTRIM(@one) + ', ' + @all
	fetch prior from Out into @one
end 
close Out
return @all
end

declare @h nvarchar(300) = dbo.FUNCTIN ('кут')
print @h;

drop function FUNCTIN;