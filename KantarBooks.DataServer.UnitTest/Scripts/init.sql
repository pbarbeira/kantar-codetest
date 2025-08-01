drop table if exists Books;

create table Books(
	Id integer primary key autoincrement,
	Title nvarchar(255) not null,
	AuthorCode nvarchar(50) not null,
	PublisherCode nvarchar(50) not null,
	Borrowed bit not null default 0
);

insert into Books(Id, Title, AuthorCode, PublisherCode, Borrowed)
values(1, 'The Right Thing, Right Now', 'KBA1', 'KBP1', 0);

insert into Books(Id, Title, AuthorCode, PublisherCode, Borrowed)
values(2, 'The Process Mind', 'KBA2', 'KBP2', 1);

	insert into Books(Id, Title, AuthorCode, PublisherCode, Borrowed)
values(3, 'The Light of the Soul', 'KBA3', 'KBP3', 0);
