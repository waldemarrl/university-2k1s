create view [���������� ������]
as select f.FACULTY_NAME [���������],
count(PULPIT.PULPIT) [���������� ������]
from FACULTY as f inner join PULPIT
on f.FACULTY = PULPIT.FACULTY
group by f.FACULTY_NAME

select * from [���������� ������]