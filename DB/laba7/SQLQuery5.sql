create view [Дисциплины] as select
top(100) SUBJECT [Код],
SUBJECT_NAME [Наименование дисциплины],
PULPIT [Код кафедры]
from SUBJECT
order by SUBJECT_NAME

select * from [Дисциплины]