-- Conditionally creates database and tables if there is no database on the
-- server. Should only run on first startup.

if db_id('kb_books') is null
	begin
		create database kb_books;
	end
go

use kb_books;
go

if not exists(select * from sys.tables where name = 'Users')
	begin
		create table Users(
			Id bigint identity(1, 1) primary key,
			Code varchar(50) not null,
			Name varchar(255) not null
		);
	end
go

if not exists(select * from sys.tables where name = 'Books')
	begin
		create table Books(
			Id bigint identity(1, 1) primary key,
			Code nvarchar(50) not null,
			Name nvarchar(255) not null,
			AuthorCode nvarchar(50) not null,
			PublisherCode nvarchar(50) not null,
			Borrowed bit not null default 0,
			BorrowerId bigint null,
			constraint FK_Books_Users_BorrowerId foreign key (BorrowerId) references Users(Id)
		);
	end
go

if not exists(select 1 from Users)
	begin
		insert into Users(Code, Name)
		values('KBU000001', 'John Smith');
		
		insert into Users(Code, Name)
		values('KBU000002', 'Lois Lane');
		
		insert into Users(Code, Name)
		values('KBU000003', 'Mike Tyson');
	end
go

if not exists(select 1 from Books)
	begin
		insert into Books(Code, Name, AuthorCode, PublisherCode, Borrowed, BorrowerId)
		values('KBB000001', 'The Right Thing, Right Now', 'KBA000001', 'KBP000001', 0, NULL);
		
		insert into Books(Code, Name, AuthorCode, PublisherCode, Borrowed, BorrowerId)
		values('KBB000002', 'The Process Mind', 'KBA000002', 'KBP000002', 1, 1);

			insert into Books(Code, Name, AuthorCode, PublisherCode, Borrowed, BorrowerId)
		values('KBB000003', 'The Light of the Soul', 'KBA000003', 'KBP000003', 0, NULL);
		
	end
go
