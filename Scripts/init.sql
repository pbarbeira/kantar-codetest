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
			Title nvarchar(255) not null,
			AuthorCode nvarchar(50) not null,
			PublisherCode nvarchar(50) not null,
			Borrowed bit not null default 0,
		);
	end
go


if not exists(select 1 from Books)
	begin
		insert into Books(Title, AuthorCode, PublisherCode, Borrowed)
		values('The Right Thing, Right Now', 'KBA1', 'KBP1', 0);
		
		insert into Books(Title, AuthorCode, PublisherCode, Borrowed)
		values('The Process Mind', 'KBA2', 'KBP2', 1);

			insert into Books(Title, AuthorCode, PublisherCode, Borrowed)
		values('The Light of the Soul', 'KBA3', 'KBP3', 0);
		
	end
go
