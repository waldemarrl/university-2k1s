SELECT MIN(AUDITORIUM_CAPACITY) [���������� ������ ���������],
MAX(AUDITORIUM_CAPACITY) [���������� ������ ���������],
AVG(AUDITORIUM_CAPACITY) [������� ������ ���������],
SUM(AUDITORIUM_CAPACITY) [��������� �����������],
COUNT(AUDITORIUM_TYPE) [����� ���������� ���������]
FROM AUDITORIUM

SELECT AUDITORIUM_TYPENAME as [�������� ���������],
MIN(AUDITORIUM_CAPACITY) [���������� ������ ���������],
MAX(AUDITORIUM_CAPACITY) [���������� ������ ���������],
AVG(AUDITORIUM_CAPACITY) [������� ������ ���������],
SUM(AUDITORIUM_CAPACITY) [��������� �����������],
COUNT(AUDITORIUM) [����� ���������� ���������]
FROM AUDITORIUM_TYPE INNER JOIN AUDITORIUM
ON AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
GROUP BY AUDITORIUM_TYPENAME

SELECT *
FROM (SELECT CASE 
WHEN NOTE BETWEEN 7 AND 8 THEN '7-8'
WHEN NOTE BETWEEN 4 AND 6 THEN '4-6'
ELSE '9'
END [������],
COUNT(*)[����������]
FROM PROGRESS 
GROUP BY CASE
WHEN NOTE BETWEEN 7 AND 8 THEN '7-8'
WHEN NOTE BETWEEN 4 AND 6 THEN '4-6'
ELSE '9'
END) AS T
ORDER BY CASE [������] 
WHEN '4-6' THEN 3
WHEN '7-8' THEN 2
WHEN '9' THEN 1
ELSE 0
END

SELECT F.FACULTY as ���������,
G.PROFESSION  as �������������,
(2014 - G.YEAR_FIRST) [����],
ROUND(AVG(CAST(NOTE AS FLOAT (4))), 2) AS [������� ������]
FROM FACULTY F INNER JOIN GROUPS G 
ON F.FACULTY = G.FACULTY INNER JOIN STUDENT S 
ON G.IDGROUP = S.IDGROUP INNER JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY F.FACULTY, G.PROFESSION, G.YEAR_FIRST
ORDER BY [������� ������] DESC

SELECT F.FACULTY as ���������,
G.PROFESSION as �������������,
(2014 - G.YEAR_FIRST) [����],
ROUND(AVG(CAST(NOTE AS FLOAT (4))), 2) AS [������� ������]
FROM FACULTY F
INNER JOIN GROUPS G ON F.FACULTY = G.FACULTY
INNER JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
INNER JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT AND P.SUBJECT IN ('����', '����')
GROUP BY F.FACULTY, G.PROFESSION, G.YEAR_FIRST
ORDER BY [������� ������] DESC

SELECT PROFESSION, SUBJECT, AVG(NOTE) AS [������� ������]
FROM FACULTY 
JOIN GROUPS G ON FACULTY.FACULTY= G.FACULTY AND G.FACULTY = '��'
JOIN STUDENT S ON G.IDGROUP=S.IDGROUP
JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY G.FACULTY, PROFESSION, ROLLUP(SUBJECT)

SELECT PROFESSION, SUBJECT, AVG(NOTE) AS [������� ������]
FROM FACULTY 
JOIN GROUPS G ON FACULTY.FACULTY= G.FACULTY AND G.FACULTY = '��'
JOIN STUDENT S ON G.IDGROUP=S.IDGROUP
JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY CUBE(G.FACULTY, PROFESSION, SUBJECT)

-----7


SELECT GROUPS.PROFESSION, P.SUBJECT, AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS  FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='���' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
UNION
SELECT GROUPS.PROFESSION, P.SUBJECT, AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='����' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION

SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS  FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='���' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
UNION ALL
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='����' FULL JOIN PROGRESS P
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION

--------8


SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS  FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='���' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
UNION
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='����' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
INTERSECT
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS  FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='���' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
UNION ALL
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='����' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION


----------9
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS  FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='���' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
UNION
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='����' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
EXCEPT
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS  FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='���' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION
UNION ALL
SELECT GROUPS.PROFESSION,P.SUBJECT,AVG(NOTE) AS AVERAGE_NOTE
FROM GROUPS FULL JOIN STUDENT S 
ON GROUPS.IDGROUP = S.IDGROUP AND GROUPS.FACULTY='����' FULL JOIN PROGRESS P 
ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY P.SUBJECT, GROUPS.PROFESSION

SELECT SUBJECT, NOTE,COUNT(NOTE) AS [����������]
FROM PROGRESS
GROUP BY SUBJECT, NOTE HAVING NOTE IN (8, 9)
ORDER BY NOTE DESC
-------------------

SELECT ������.[���]
From ������
WHERE ������.[�������� �����-�������] like '%AMD%'
UNION
SELECT ������.[���]
From ������
WHERE ������.[�������� �����-�������] like '%Intel%'

--------------------
SELECT ������.[���]
From ������
WHERE ������.[�������� �����-�������] like '%AMD%'
UNION
SELECT ������.[���]
From ������
WHERE ������.[�������� �����-�������] like '%Intel%'

---------------------
SELECT ������.[�������� �����-�������], ������.�������
FROM ������
GROUP BY ������.[�������� �����-�������],
������.������� HAVING ������.������� like '+375444404040'