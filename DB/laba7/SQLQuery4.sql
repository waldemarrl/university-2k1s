CREATE VIEW [����������� ���������] (AUDITORIUM_TYPE,AUDITORIUM)
as select AUDITORIUM_TYPE as [������������ ���������],
AUDITORIUM as [���]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE '%��%' with check option

INSERT into [����������� ���������] VALUES ('��-�','��')
DELETE FROM [����������� ���������] where AUDITORIUM='��'
UPDATE [����������� ���������] SET AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = '��'

select * from [����������� ���������]