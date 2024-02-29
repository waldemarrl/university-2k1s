use UNIVER;
set nocount on
	if  exists (select * from  SYS.OBJECTS        
	            where OBJECT_ID= object_id(N'DBO.M') )	            
	drop table M;           
	declare @c int, @flag char = 'c';       
	--SET AUTOCOMMIT = 0;
	SET IMPLICIT_TRANSACTIONS  ON   
	CREATE table M(K int );                        
		INSERT M values (1),(2),(3);
		set @c = (select count(*) from M);
		print '���������� ����� � ������� X: ' + cast( @c as varchar(2));
		if @flag = 'c'  commit;                   
	          else   rollback;                                 
      SET IMPLICIT_TRANSACTIONS  OFF   
	
	if  exists (select * from  SYS.OBJECTS       
	            where OBJECT_ID= object_id(N'DBO.M') )
	print '������� M ����';  
      else print '������� M ���'
-----------------------------------------2>

GO
BEGIN TRY
	BEGIN TRAN                
	    INSERT FACULTY VALUES ('ISIT', 'ISITCHIK');
		INSERT FACULTY VALUES ('POIT', 'POITCHIK');
	COMMIT TRAN;               
END TRY
BEGIN CATCH
	PRINT '������: '+ CASE
		WHEN ERROR_NUMBER() = 2627 AND PATINDEX('%FACULTY_PK%', ERROR_MESSAGE()) > 0 THEN '������������ '	
		ELSE '����������� ������: '+ CAST(ERROR_NUMBER() AS  VARCHAR(5))+ ERROR_MESSAGE()
	END;
	IF @@TRANCOUNT > 0 ROLLBACK TRAN; 
END CATCH;

DELETE FACULTY WHERE FACULTY = 'ISIT';
DELETE FACULTY WHERE FACULTY = 'POIT';
SELECT * FROM FACULTY;

---------------------------------------3>
GO
DECLARE @POINT VARCHAR(32);
BEGIN TRY
	BEGIN TRAN
		SET @POINT = 'P1';
		SAVE TRAN @POINT;
		INSERT TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) VALUES
		                      ('���','������� ������ ���������', '�', '����')
		SET @POINT = 'P2';
		SAVE TRAN @POINT; 
		INSERT TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) VALUES
							  ('���', '������ ���� ��������', '�', '����');
	COMMIT TRAN;
END TRY

BEGIN CATCH
	PRINT '������: '+ CASE
		WHEN ERROR_NUMBER() = 2627 AND PATINDEX('%STUDENT_PK%', ERROR_MESSAGE()) > 0 THEN '������������'
		ELSE '����������� ������: '+ CAST(ERROR_NUMBER() AS  VARCHAR(5)) + ERROR_MESSAGE()
	END;
    IF @@TRANCOUNT > 0 
	BEGIN
	   PRINT '����������� �����: '+ @POINT;
	   ROLLBACK TRAN @POINT;
	   COMMIT TRAN; 
	END;
END CATCH;

SELECT * FROM TEACHER WHERE PULPIT= '����';
DELETE TEACHER WHERE TEACHER like '���' 
DELETE TEACHER WHERE TEACHER like '���' 

-----------------------------------------4>

GO
-----B�----
BEGIN TRANSACTION
SELECT @@SPID
INSERT FACULTY VALUES('���','���� ���');
SELECT *
FROM FACULTY WHERE FACULTY = '���';
-----T1----------
-----T2----------
ROLLBACK;

DELETE FACULTY WHERE FACULTY = '���';
---------------------------5>
-----B----
set nocount on
BEGIN TRANSACTION
------T1-----
UPDATE SUBJECT SET SUBJECT_NAME = '��' WHERE SUBJECT = '���';
--INSERT SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT) values ('FIFA', 'FOOTBALL', '��');
------T2------
Commit
--�������� ��������������� ����������������
ROLLBACK
---------------------------6>

GO
--- B ---	
BEGIN TRANSACTION 	  
--------T1---------
DELETE FROM SUBJECT WHERE SUBJECT = '���'
ROLLBACK
---------------------------------------------------7>
--- B ---	
BEGIN TRANSACTION 	  
DELETE AUDITORIUM WHERE AUDITORIUM = '123-4' 
INSERT AUDITORIUM VALUES ('123-4', '��', 10, '123-1')
UPDATE AUDITORIUM SET AUDITORIUM_NAME = '123-4' WHERE AUDITORIUM = '123-4'
SELECT AUDITORIUM FROM AUDITORIUM  WHERE AUDITORIUM = '123-4'
--------T1---------
ROLLBACK
SELECT AUDITORIUM FROM AUDITORIUM  WHERE AUDITORIUM = '123-4'
--------T2---------
---------------------------------------------8>

GO
BEGIN TRAN
	INSERT AUDITORIUM_TYPE VALUES ('TEST', 'TEST TEST');
	BEGIN TRAN
		UPDATE AUDITORIUM SET AUDITORIUM = '206-1' WHERE AUDITORIUM_TYPE = 'TES'
		COMMIT
		IF @@TRANCOUNT > 0 ROLLBACK
	SELECT
		(SELECT COUNT(*) FROM AUDITORIUM WHERE AUDITORIUM_TYPE='TEST') 'AUDIT',
		(SELECT COUNT(*) FROM AUDITORIUM_TYPE  WHERE AUDITORIUM_TYPE='TEST') 'TYPE'
DELETE  AUDITORIUM_TYPE WHERE  AUDITORIUM_TYPE = 'TEST';
ROLLBACK;