create view [Количество кафедр]
as select f.FACULTY_NAME [Факультет],
count(PULPIT.PULPIT) [Количество кафедр]
from FACULTY as f inner join PULPIT
on f.FACULTY = PULPIT.FACULTY
group by f.FACULTY_NAME

select * from [Количество кафедр]