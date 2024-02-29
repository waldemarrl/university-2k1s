use В_MyBase
CREATE table [ВИД КРЕДИТА]
(
[Номер вида] int not null primary key,
[Название вида кредита] nvarchar(20),
[Ставка %] real
) on FG1;

CREATE table КЛИЕНТ
(
[Название фирмы-клиента] nvarchar(20) not null primary key,
Адрес nvarchar(20),
Телефон nvarchar(20),
[Контактное лицо] nvarchar(20),
[Вид собственности] nvarchar(20)
) on FG1;

CREATE table КРЕДИТ
(
[Номер кредита] int not null primary key,
[Номер вида] int foreign key references [ВИД КРЕДИТА]([Номер вида]),
[Название фирмы-клиента] nvarchar(20) foreign key references КЛИЕНТ([Название фирмы-клиента]),
[Дата выдачи] date,
[Дата возврата] date
) on FG1;