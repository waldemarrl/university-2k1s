USE UNIVER;
GO
SELECT PULPIT.FACULTY[���������], TEACHER.PULPIT[�������], TEACHER.TEACHER_NAME[�������������]
FROM TEACHER INNER JOIN PULPIT ON TEACHER.PULPIT = PULPIT.PULPIT
WHERE TEACHER.PULPIT = '����' FOR XML PATH, ROOT('�������������_����');

---------------------------------2>

GO
SELECT AUDITORIUM.AUDITORIUM [���������], AUDITORIUM.AUDITORIUM_TYPE [���],AUDITORIUM.AUDITORIUM_CAPACITY [�����������] 
FROM AUDITORIUM JOIN AUDITORIUM_TYPE ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
WHERE AUDITORIUM.AUDITORIUM_TYPE = '��' FOR XML AUTO, ROOT('������');

---------------------------------3>

GO
DECLARE @H INT = 0,
@S VARCHAR(3000) = '<?xml version="1.0" encoding="windows-1251" ?>
<����������>
<���������� ���="��" ��������="����" �������="����" />
<���������� ���="����" ��������="���������� ���������� ��" �������="����" />
<���������� ���="��" ��������="������ ������������" �������="����" />
</����������>';
EXEC SP_XML_PREPAREDOCUMENT @H OUTPUT, @S;
INSERT SUBJECT SELECT[���], [��������], [�������] FROM OPENXML(@H, '/����������/����������',0)
WITH([���] CHAR(10), [��������] VARCHAR(100), [�������] CHAR(20));

SELECT * FROM SUBJECT WHERE PULPIT = '����'

---------------------------------4>

GO
INSERT INTO STUDENT(IDGROUP, NAME, BDAY, INFO)
VALUES(6, '�������', '2004-04-13',
'<�������>
<������� �����="��" �����="2222222" ����="2020-10-28" />
<�������>+375296101158</�������>
<�����>
<������>��������</������>
<�����>�����</�����>
<�����>�����������</�����>
<���>16</���>
<��������>9</��������>
</�����>
</�������>');
GO
SELECT * FROM STUDENT WHERE NAME = '�������'
GO
UPDATE STUDENT SET INFO = 
'<�������>
<������� �����="��" �����="3333333" ����="19.04.2013" />
<�������>+375296101158</�������>
<�����>
<������>��������</������>
<�����>�����</�����>
<�����>�����������</�����>
<���>16</���>
<��������>9</��������>
</�����>
</�������>' WHERE NAME='�������'; 
GO
SELECT NAME[���], INFO.value('(�������/�������/@�����)[1]', 'CHAR(2)')[����� ��������],
INFO.value('(�������/�������/@�����)[1]', 'VARCHAR(20)')[����� ��������],
INFO.query('/�������/�����')[�����]
FROM  STUDENT WHERE NAME = '�������';  

---------------------------------5>
USE UNIVER;
GO
CREATE XML SCHEMA COLLECTION STUDENT AS 
N'<?xml version="1.0" encoding="utf-16" ?>
<xs:schema attributeFormDefault="unqualified"
   elementFormDefault="qualified"
   xmlns:xs="http://www.w3.org/2001/XMLSchema">
<xs:element name="�������">
<xs:complexType><xs:sequence>
<xs:element name="�������" maxOccurs="1" minOccurs="1">
  <xs:complexType>
    <xs:attribute name="�����" type="xs:string" use="required" />
    <xs:attribute name="�����" type="xs:unsignedLong" use="required"/>
    <xs:attribute name="����"  use="required">
	<xs:simpleType>  <xs:restriction base ="xs:string">
		<xs:pattern value="[0-9]{2}.[0-9]{2}.[0-9]{4}"/>
	 </xs:restriction> 	</xs:simpleType>
     </xs:attribute>
  </xs:complexType>
</xs:element>
<xs:element maxOccurs="3" name="�������" type="xs:unsignedLong"/>
<xs:element name="�����">   <xs:complexType><xs:sequence>
   <xs:element name="������" type="xs:string" />
   <xs:element name="�����" type="xs:string" />
   <xs:element name="�����" type="xs:string" />
   <xs:element name="���" type="xs:string" />
   <xs:element name="��������" type="xs:string" />
</xs:sequence></xs:complexType>  </xs:element>
</xs:sequence></xs:complexType>
</xs:element></xs:schema>';
GO
SELECT NAME, INFO FROM STUDENT WHERE NAME='�������';
GO
ALTER TABLE STUDENT ALTER COLUMN INFO XML;
GO
SELECT NAME, INFO FROM STUDENT;