ALTER table КЛИЕНТ ADD Счёт int;
ALTER table КЛИЕНТ ADD Пол nchar(1) default 'м' check (Пол in ('м', 'ж'));