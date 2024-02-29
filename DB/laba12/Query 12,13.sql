create procedure PR @f nvarchar(50)
as
begin 
select AUDITORIUM.AUDITORIUM_TYPE from AUDITORIUM 
where AUDITORIUM.AUDITORIUM = @f
end 

declare @d char(50)
exec @d = PR '206-1'
print @d

drop procedure PR
----------------

create function FU (@g nvarchar(50)) returns int as 
begin
declare @c int = 0
set @c = (select AUDITORIUM.AUDITORIUM_CAPACITY
from AUDITORIUM
where AUDITORIUM.AUDITORIUM = @g)
return @c
end

declare @h int = dbo.FU('206-1')
print cast(@h as nvarchar(50))

drop function FU

---------------------
create function FUN (@a nvarchar(50), @n nvarchar(50)) returns table as
return
select AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM.AUDITORIUM_TYPE
from AUDITORIUM
where AUDITORIUM.AUDITORIUM_NAME = @a and AUDITORIUM.AUDITORIUM_TYPE = @n

SELECT * from dbo.FUN('206-1','ка-й')

drop function FUN


-------------- 

create procedure PS @a nvarchar(50) 
as begin 
select AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM_TYPE inner join AUDITORIUM
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
where AUDITORIUM.AUDITORIUM_NAME = @a
end

declare @r nvarchar(50) 
exec @r = PS '206-1'
print @r

drop procedure PS
------------------

create function F (@d nvarchar(50)) returns nvarchar(50) as
begin 
declare @j nvarchar(50)
set @j = (select AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM_TYPE inner join AUDITORIUM
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
where AUDITORIUM.AUDITORIUM_NAME = @d)
return @j
end 

declare @r nvarchar(50)
set @r = dbo.F('206-1')
print @r

drop function F

-----------

use UNIVER;
go
create procedure PS @p nvarchar(20)
as 
begin
select AUDITORIUM_TYPENAME FROM AUDITORIUM_TYPE as a1 inner join AUDITORIUM as a2 
on a1.AUDITORIUM_TYPE = a2.AUDITORIUM_TYPE 
WHERE AUDITORIUM_NAME = @p;
end;
go
declare @p nvarchar(20) = '206-1';
exec PS @p;
drop procedure PS;
----------------

go 
create function PC(@p nvarchar(20)) returns nvarchar(20)
as
begin 
declare @n nvarchar(20) = ' ';
set @n = (select AUDITORIUM_TYPENAME FROM AUDITORIUM_TYPE as a1 inner join AUDITORIUM as a2 
on a1.AUDITORIUM_TYPE = a2.AUDITORIUM_TYPE 
WHERE AUDITORIUM = @p);
return @n;
end;
go
declare @T_1 nvarchar(20) = dbo.PC('206-1')
print @T_1;
drop function PC;