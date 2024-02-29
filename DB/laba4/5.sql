SELECT 
GROUPS.FACULTY as ���������,
GROUPS.PROFESSION as �������������,
SUBJECT.PULPIT as �������,
PROGRESS.SUBJECT as �������,
STUDENT.NAME as ���_��������,
Case PROGRESS.NOTE
When 6 then '�����'
When 7 then '����'
When 8 then '������'
end as ������
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