CREATE VIEW [Аудитории] (AUDITORIUM_TYPE, AUDITORIUM)
as select AUDITORIUM_TYPE as [Наименование аудитории],
AUDITORIUM as [Код]
FROM AUDITORIUM
WHERE AUDITORIUM_TYPE LIKE 'ЛК%'

INSERT  [Аудитории] VALUES ('ЛК','ЛК')
DELETE FROM Аудитории where AUDITORIUM='ЛК'
UPDATE Аудитории SET AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = 'ЛК'

drop view [Аудитории];
select * from Аудитории