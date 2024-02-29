create view [auditorium lk-k] as SELECT AUDITORIUM.AUDITORIUM_NAME as [Auditorium name], AUDITORIUM_TYPE.AUDITORIUM_TYPE as [Auditorium type]
FROM AUDITORIUM, AUDITORIUM_TYPE
WHERE AUDITORIUM_TYPE.AUDITORIUM_TYPE like '%ЛК-К%'
go select * from [auditorium lk-k] 

------------------
create view [Company] as 
select КЛИЕНТ.[Название фирмы-клиента]
from КЛИЕНТ

select * from [Company]
--------------

alter view [Company] as 
select КЛИЕНТ.[Название фирмы-клиента]
from КЛИЕНТ
where КЛИЕНТ.Адрес like 'ул. Свердлова 13'
---------------

select STUDENT.NAME as Student 
from STUDENT
where STUDENT.IDGROUP in (select GROUPS.IDGROUP 
from GROUPS
where GROUPS.FACULTY like '%ИТ%')