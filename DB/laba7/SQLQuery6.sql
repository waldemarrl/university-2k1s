alter view [���������� ������] with schemabinding
as select FACULTY.FACULTY_NAME [���������],
count(PULPIT.PULPIT) [���������� ������]
from FACULTY join PULPIT on FACULTY.FACULTY = PULPIT.FACULTY
group by FACULTY.FACULTY_NAME

select * from [���������� ������]