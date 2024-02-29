CREATE VIEW [Лекционнные аудитории] (AUDITORIUM_TYPE,AUDITORIUM)
as select AUDITORIUM_TYPE as [Наименование аудитории],
AUDITORIUM as [Код]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE '%ЛК%' with check option

INSERT into [Лекционнные аудитории] VALUES ('ЛБ-К','ЛБ')
DELETE FROM [Лекционнные аудитории] where AUDITORIUM='ЛК'
UPDATE [Лекционнные аудитории] SET AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = 'ЛК'

select * from [Лекционнные аудитории]