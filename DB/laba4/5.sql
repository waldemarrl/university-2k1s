SELECT 
GROUPS.FACULTY as Факультет,
GROUPS.PROFESSION as Специальность,
SUBJECT.PULPIT as Кафедра,
PROGRESS.SUBJECT as Предмет,
STUDENT.NAME as Имя_Студента,
Case PROGRESS.NOTE
When 6 then 'шесть'
When 7 then 'семь'
When 8 then 'восемь'
end as Оценка
FROM STUDENT
Inner Join PROGRESS on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
Inner Join GROUPS on GROUPS.IDGROUP = STUDENT.IDGROUP
Inner Join SUBJECT on SUBJECT.SUBJECT = PROGRESS.SUBJECT
WHERE PROGRESS.NOTE between 6 and 8
ORDER BY 
(Case
when(PROGRESS.NOTE like 6) then 3
when(PROGRESS.NOTE like 7) then 1
else 2
end
)