use П_MyBase
SELECT Distinct [Контактное лицо], Адрес, Телефон From КЛИЕНТ
Where [Контактное лицо] Like 'Ш%'
SELECT [Название фирмы-клиента], [Номер вида] From КРЕДИТ
Where [Дата выдачи] between '2014-07-12' and '2023-06-10'
SELECT Distinct [Название вида кредита] From [ВИД КРЕДИТА]
Where [Ставка %] in (10, 5)