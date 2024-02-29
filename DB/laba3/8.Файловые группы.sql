use master  
create database Â_MyBase on primary
( name = N'P_BD_mdf', filename = N'D:\belstu\2k1s\DB\laba3\Data\P_BD_mdf.mdf', 
   size = 10240Kb, maxsize=UNLIMITED, filegrowth=1024Kb),
( name = N'P_BD_ndf', filename = N'D:\belstu\2k1s\DB\laba3\Data\P_BD_ndf.ndf', 
   size = 10240KB, maxsize=1Gb, filegrowth=25%),
filegroup FG1
( name = N'P_BD_fg1_1', filename = N'D:\belstu\2k1s\DB\laba3\Data\P_BD_fgq-1.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%),
( name = N'P_BD_fg1_2', filename = N'D:\belstu\2k1s\DB\laba3\Data\P_BD_fgq-2.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%)
log on
( name = N'P_BD_log', filename=N'D:\belstu\2k1s\DB\laba3\Data\P_BD_log.ldf',       
   size=10240Kb,  maxsize=2048Gb, filegrowth=10%)
