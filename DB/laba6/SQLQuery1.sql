SELECT  STUDENT.NAME , PROGRESS.NOTE
FROM STUDENT, PROGRESS
WHERE STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT And
PROGRESS.SUBJECT In (SELECT SUBJECT
FROM PROGRESS
WHERE SUBJECT Like '%����%')
---------------

SELECT AVG(PROGRESS.NOTE)
FROM PROGRESS

