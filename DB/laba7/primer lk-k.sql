create view [auditorium lk-k] as SELECT AUDITORIUM.AUDITORIUM_NAME as [Auditorium name], AUDITORIUM_TYPE.AUDITORIUM_TYPE as [Auditorium type]
FROM AUDITORIUM, AUDITORIUM_TYPE
WHERE AUDITORIUM_TYPE.AUDITORIUM_TYPE like '%��-�%'
go select * from [auditorium lk-k] 

------------------
create view [Company] as 
select ������.[�������� �����-�������]
from ������

select * from [Company]
--------------

alter view [Company] as 
select ������.[�������� �����-�������]
from ������
where ������.����� like '��. ��������� 13'
---------------

select STUDENT.NAME as Student 
from STUDENT
where STUDENT.IDGROUP in (select GROUPS.IDGROUP 
from GROUPS
where GROUPS.FACULTY like '%��%')