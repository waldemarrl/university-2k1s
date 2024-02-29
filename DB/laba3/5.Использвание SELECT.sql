SELECT * From КЛИЕНТ;
SELECT Адрес, Телефон From КЛИЕНТ;
SELECT count(*) From КЛИЕНТ;
SELECT [Название вида кредита] [Выгодные кредиты] from [ВИД КРЕДИТА]
Where [Ставка %] < 6
SELECT Distinct Top(2)  Адрес, [Контактное лицо] from КЛИЕНТ;