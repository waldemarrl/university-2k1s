SELECT isnull (TEACHER.TEACHER_NAME, '***') [�������������],
PULPIT.PULPIT_NAME as �������
FROM PULPIT Left Outer Join TEACHER
ON PULPIT.PULPIT = TEACHER.PULPIT