use UNIVER

DECLARE
@A CHAR = 'А',
@B NVARCHAR(4) = 'ISaT',
@C DATETIME=GETDATE(),
@D TIME,
@E INT,
@F SMALLINT,
@G TINYINT,
@H NUMERIC(12,5);

set @D = GETDATE();

select @E = 2134580797, @F = 34, @G = 8;

PRINT CONVERT(NVARCHAR,@D ) + ' ' + CONVERT(NVARCHAR, @E) + ' '
+ CONVERT(NVARCHAR, @F) + ' '+ CONVERT(NVARCHAR, @G);
SELECT @A Символ, @B Строка, @C Дата;

----------------------------------2
declare
@CAPACITY INT = (select sum(AUDITORIUM_CAPACITY)from AUDITORIUM),
@TOTAL INT,
@AVGTOTAL INT,
@TOTALLESS INT,
@PROCENT INT;

if @CAPACITY > 200
begin 
set @TOTAL = (select count(*) from AUDITORIUM);
set @AVGTOTAL = (select avg(AUDITORIUM_CAPACITY)from AUDITORIUM);
set @TOTALLESS = (select count(*) from AUDITORIUM where AUDITORIUM_CAPACITY < @AVGTOTAL);
set @PROCENT = @TOTALLESS * 100 / @TOTAL;
select @CAPACITY [Общая вместимость],
@TOTAL [Количество],
@AVGTOTAL [Средняя вместимость],
@TOTALLESS [Кол-во аудиторий ниже среднего],
@PROCENT [Процент меньших аудиторий]
end

else print 'Общая вместимость < 200'

----------------------------------3
PRINT 'ЧИСЛО ОБРАБОТАННЫХ СТРОК: ' + CAST(@@ROWCOUNT AS NVARCHAR);
PRINT 'ВЕРСИЯ SQL SERVER: ' + CAST(@@VERSION AS VARCHAR);
PRINT 'СИСТЕМНЫЙ ИДЕНТИФИКАТОР ПРОЦЕССА: ' + CAST(@@SPID AS NVARCHAR);
PRINT 'КОД ПОСЛЕДНЕЙ ОШИБКИ: ' + CAST(@@ERROR AS VARCHAR);
PRINT 'ИМЯ СЕРВЕРА: ' + CAST(@@SERVERNAME AS VARCHAR);
PRINT 'УРОВЕНЬ ВЛОЖЕННОСТИ ТРАНЗАКЦИИ: ' + CAST(@@TRANCOUNT AS NVARCHAR);
PRINT 'ПРОВЕРКА РЕЗУЛЬТАТА СЧИТЫВАНИЯ СТРОК РЕЗУЛЬТИРУЮЩЕГО НАБОРА: ' + CAST(@@FETCH_STATUS AS NVARCHAR);
PRINT 'УРОВЕНЬ ВЛОЖЕННОСТИ ТЕКУЩЕЙ ПРОЦЕДУРЫ: ' + CAST(@@NESTLEVEL AS NVARCHAR);

----------------------------------4
DECLARE 
@Z FLOAT,
@T FLOAT = 13,
@X FLOAT = 9;

IF @T > @X
SET @Z = POWER(SIN(@T), 2);

ELSE IF @T < @X
SET @Z = 4*(@T + @X);

ELSE
SET @Z = 1 - EXP(@X-2);

SELECT @Z;
-------
declare 
@FIRSTNAME nvarchar(15) = 'Vladimir',
@LASTNAME nvarchar(15) = 'Lobanov',
@FATHERNAME nvarchar(25) = 'Dmitrievich',
@FULLNAME nvarchar (40),
@SMALLNAME nvarchar (15);

set @FULLNAME = @LASTNAME + ' ' + @FIRSTNAME + ' ' + @FATHERNAME

set @FIRSTNAME = substring(@FIRSTNAME, 1,1)+'.';
set @FATHERNAME = substring(@FATHERNAME, 1,1)+'.';
set @SMALLNAME = @LASTNAME + ' ' + @FIRSTNAME + ' ' + @FATHERNAME;

select @FULLNAME [Полное имя], @SMALLNAME [Сокращенное имя]

select STUDENT.NAME, STUDENT.BDAY, DATEDIFF(YEAR, STUDENT.BDAY, SYSDATETIME()) AS ВОЗРАСТ
from STUDENT
where MONTH(STUDENT.BDAY) = MONTH(SYSDATETIME()) - 1;

declare @GROUPNUMBER INT = 4;
select STUDENT.NAME, DATENAME(dw, PROGRESS.PDATE) [День недели]
from STUDENT 
join PROGRESS on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
join  GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
where GROUPS.IDGROUP = @GROUPNUMBER and  PROGRESS.SUBJECT = 'СУБД';

----------------------------------5

declare @MINCAPASITY INT = (select min(AUDITORIUM_CAPACITY) from AUDITORIUM)
if @MINCAPASITY = 30
begin 
print 'Минимальная вместимость = 30'
end
else print 'Минимальная вместимость > 30'

----------------------------------6
select (case
when NOTE between 0 and 3 then 'очень плохо'
when NOTE between 4 and 5 then 'ниже среднего'
when NOTE between 6 and 7 then 'средний результат'
when NOTE between 8 and 10 then 'очень хорошо'
end) Оценки, count(*) [Количество оценок] from PROGRESS
group by (case
when NOTE between 0 and 3 then 'очень плохо'
when NOTE between 4 and 5 then 'ниже среднего'
when NOTE between 6 and 7 then 'средний результат'
when NOTE between 8 and 10 then 'очень хорошо'
end)

----------------------------------7
create table #TASK(
	ID INT,
	NAME VARCHAR(20),
	LASTNAME VARCHAR(20)
	)
GO
declare @INDEX INT = 0
while @INDEX < 10
begin
insert #TASK values (@INDEX, 'Имя ' + cast(@INDEX as varchar), 'Фамилия ' + cast(@INDEX as varchar))
set @INDEX += 1
end

select * from #TASK

drop table #TASK;

----------------------------------8
DECLARE @I INT = 10;
PRINT @I+3;
PRINT POWER(@I,2);
RETURN
PRINT @I+11;

----------------------------------9
BEGIN TRY
UPDATE PROGRESS SET NOTE = 'Проверка на ошибки' WHERE NOTE = 9
END TRY
BEGIN CATCH
PRINT 'код последней ошибки'
PRINT ERROR_NUMBER()
PRINT 'сообщение об ошибке'
PRINT ERROR_MESSAGE() 
PRINT 'код последней ошибки'
PRINT ERROR_LINE() 
PRINT 'имя процедуры или NULL'
PRINT ERROR_PROCEDURE() 
PRINT 'уровень серьезности ошибки'
PRINT ERROR_SEVERITY() 
PRINT 'метка ошибки'
PRINT ERROR_STATE()
END CATCH

