SELECT STUDENT.NAME AS [���], PROGRESS.NOTE AS [������]
FROM  STUDENT INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT 
WHERE SUBJECT LIKE '%����%'

SELECT AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from  AUDITORIUM, AUDITORIUM_TYPE
where AUDITORIUM.AUDITORIUM_NAME in (select AUDITORIUM.AUDITORIUM
from AUDITORIUM
where AUDITORIUM.AUDITORIUM like '301-1')