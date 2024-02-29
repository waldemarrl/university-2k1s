alter view [Количество кафедр] with schemabinding
as select FACULTY.FACULTY_NAME [Факультет],
count(PULPIT.PULPIT) [Количество кафедр]
from FACULTY join PULPIT on FACULTY.FACULTY = PULPIT.FACULTY
group by FACULTY.FACULTY_NAME

select * from [Количество кафедр]