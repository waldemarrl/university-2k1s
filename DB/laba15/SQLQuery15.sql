USE UNIVER;
GO
SELECT PULPIT.FACULTY[Факультет], TEACHER.PULPIT[Кафедра], TEACHER.TEACHER_NAME[Преподаватель]
FROM TEACHER INNER JOIN PULPIT ON TEACHER.PULPIT = PULPIT.PULPIT
WHERE TEACHER.PULPIT = 'ИСИТ' FOR XML PATH, ROOT('ПРЕПОДАВАТЕЛИ_ИСИТ');

---------------------------------2>

GO
SELECT AUDITORIUM.AUDITORIUM [АУДИТОРИЯ], AUDITORIUM.AUDITORIUM_TYPE [ТИП],AUDITORIUM.AUDITORIUM_CAPACITY [ВМЕСТИМОСТЬ] 
FROM AUDITORIUM JOIN AUDITORIUM_TYPE ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
WHERE AUDITORIUM.AUDITORIUM_TYPE = 'ЛК' FOR XML AUTO, ROOT('СПИСОК');

---------------------------------3>

GO
DECLARE @H INT = 0,
@S VARCHAR(3000) = '<?xml version="1.0" encoding="windows-1251" ?>
<ДИСЦИПЛИНЫ>
<ДИСЦИПЛИНА КОД="КС" НАЗВАНИЕ="КСИС" КАФЕДРА="ИСИТ" />
<ДИСЦИПЛИНА КОД="ТРПО" НАЗВАНИЕ="ТЕХНОЛОГИИ РАЗРАБОТКИ ПО" КАФЕДРА="ИСИТ" />
<ДИСЦИПЛИНА КОД="ТВ" НАЗВАНИЕ="ТЕОРИЯ ВЕРОЯТНОСТЕЙ" КАФЕДРА="ИСИТ" />
</ДИСЦИПЛИНЫ>';
EXEC SP_XML_PREPAREDOCUMENT @H OUTPUT, @S;
INSERT SUBJECT SELECT[КОД], [НАЗВАНИЕ], [КАФЕДРА] FROM OPENXML(@H, '/ДИСЦИПЛИНЫ/ДИСЦИПЛИНА',0)
WITH([КОД] CHAR(10), [НАЗВАНИЕ] VARCHAR(100), [КАФЕДРА] CHAR(20));

SELECT * FROM SUBJECT WHERE PULPIT = 'ИСИТ'

---------------------------------4>

GO
INSERT INTO STUDENT(IDGROUP, NAME, BDAY, INFO)
VALUES(6, 'Лобанов', '2004-04-13',
'<СТУДЕНТ>
<ПАСПОРТ СЕРИЯ="МР" НОМЕР="2222222" ДАТА="2020-10-28" />
<ТЕЛЕФОН>+375296101158</ТЕЛЕФОН>
<АДРЕС>
<СТРАНА>Беларусь</СТРАНА>
<ГОРОД>Минск</ГОРОД>
<УЛИЦА>Октябрьская</УЛИЦА>
<ДОМ>16</ДОМ>
<КВАРТИРА>9</КВАРТИРА>
</АДРЕС>
</СТУДЕНТ>');
GO
SELECT * FROM STUDENT WHERE NAME = 'Лобанов'
GO
UPDATE STUDENT SET INFO = 
'<СТУДЕНТ>
<ПАСПОРТ СЕРИЯ="МР" НОМЕР="3333333" ДАТА="19.04.2013" />
<ТЕЛЕФОН>+375296101158</ТЕЛЕФОН>
<АДРЕС>
<СТРАНА>Беларусь</СТРАНА>
<ГОРОД>Минск</ГОРОД>
<УЛИЦА>Октябрьская</УЛИЦА>
<ДОМ>16</ДОМ>
<КВАРТИРА>9</КВАРТИРА>
</АДРЕС>
</СТУДЕНТ>' WHERE NAME='Лобанов'; 
GO
SELECT NAME[ФИО], INFO.value('(СТУДЕНТ/ПАСПОРТ/@СЕРИЯ)[1]', 'CHAR(2)')[СЕРИЯ ПАСПОРТА],
INFO.value('(СТУДЕНТ/ПАСПОРТ/@НОМЕР)[1]', 'VARCHAR(20)')[НОМЕР ПАСПОРТА],
INFO.query('/СТУДЕНТ/АДРЕС')[АДРЕС]
FROM  STUDENT WHERE NAME = 'Лобанов';  

---------------------------------5>
USE UNIVER;
GO
CREATE XML SCHEMA COLLECTION STUDENT AS 
N'<?xml version="1.0" encoding="utf-16" ?>
<xs:schema attributeFormDefault="unqualified"
   elementFormDefault="qualified"
   xmlns:xs="http://www.w3.org/2001/XMLSchema">
<xs:element name="Студент">
<xs:complexType><xs:sequence>
<xs:element name="Паспорт" maxOccurs="1" minOccurs="1">
  <xs:complexType>
    <xs:attribute name="Серия" type="xs:string" use="required" />
    <xs:attribute name="Номер" type="xs:unsignedLong" use="required"/>
    <xs:attribute name="Дата"  use="required">
	<xs:simpleType>  <xs:restriction base ="xs:string">
		<xs:pattern value="[0-9]{2}.[0-9]{2}.[0-9]{4}"/>
	 </xs:restriction> 	</xs:simpleType>
     </xs:attribute>
  </xs:complexType>
</xs:element>
<xs:element maxOccurs="3" name="Телефон" type="xs:unsignedLong"/>
<xs:element name="Адрес">   <xs:complexType><xs:sequence>
   <xs:element name="Страна" type="xs:string" />
   <xs:element name="Город" type="xs:string" />
   <xs:element name="Улица" type="xs:string" />
   <xs:element name="Дом" type="xs:string" />
   <xs:element name="Квартира" type="xs:string" />
</xs:sequence></xs:complexType>  </xs:element>
</xs:sequence></xs:complexType>
</xs:element></xs:schema>';
GO
SELECT NAME, INFO FROM STUDENT WHERE NAME='Лобанов';
GO
ALTER TABLE STUDENT ALTER COLUMN INFO XML;
GO
SELECT NAME, INFO FROM STUDENT;