use �_MyBase
CREATE table [��� �������]
(
[����� ����] int not null primary key,
[�������� ���� �������] nvarchar(20),
[������ %] real
) on FG1;

CREATE table ������
(
[�������� �����-�������] nvarchar(20) not null primary key,
����� nvarchar(20),
������� nvarchar(20),
[���������� ����] nvarchar(20),
[��� �������������] nvarchar(20)
) on FG1;

CREATE table ������
(
[����� �������] int not null primary key,
[����� ����] int foreign key references [��� �������]([����� ����]),
[�������� �����-�������] nvarchar(20) foreign key references ������([�������� �����-�������]),
[���� ������] date,
[���� ��������] date
) on FG1;