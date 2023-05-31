create database vizsga

use vizsga

create table kategoria
(
	id int identity(1,1) primary key,
	kategorianev varchar(50) not null,
	timestamps date default(getdate()) 
)

create table teszt
(
	id int identity(1,1) primary key,
	kerdes varchar(60) not null,
	v1 varchar(60) not null,
	v2 varchar(60) not null,
	v3 varchar(60) not null,
	v4 varchar(60) not null,
	helyes varchar(60),
	kategoriaId int not null,
	timestamps date default(getdate())
	foreign key(kategoriaId) references kategoria(id)
)

alter trigger alapHelyesValasz
on teszt 
after insert
as
begin
declare @id as int
	
	set @id = (SELECT TOP 1 *
	FROM teszt
	ORDER
    BY id DESC)
	
	if ((select helyes from inserted) is null ) 
	begin
	
	update teszt
	set helyes = (select v1 from inserted)
	where id = @id
	end
end

