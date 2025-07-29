-- Conditionally creates database and tables if there is no database on the
-- server. Should only run on first startup.

if db_id('kb_books') is null
	begin
		create database kb_books;
	end
go

use kb_books;
go


if not exists(select * from sys.tables where name = 'Books')
	begin
		create table Books(
			Id bigint identity(1, 1) primary key,
			Code nvarchar(50) not null,
			Title nvarchar(255) not null,
			AuthorCode nvarchar(50) not null,
			PublisherCode nvarchar(50) not null,
			Borrower nvarchar(50) not null,
		);
	end
go


if not exists(select 1 from Books)
	begin
		insert into Books(Code, Title, AuthorCode, PublisherCode, Borrower)
		values('KBB000001', 'The Right Thing, Right Now', 'KBA000001', 'KBP000001', "");
		
		insert into Books(Code, Title, AuthorCode, PublisherCode, Borrower)
		values('KBB000002', 'The Process Mind', 'KBA000002', 'KBP000002', "");

			insert into Books(Code, Title, AuthorCode, PublisherCode, Borrower)
		values('KBB000003', 'The Light of the Soul', 'KBA000003', 'KBP000003', "");
		
	end
go
