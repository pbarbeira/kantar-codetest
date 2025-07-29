
create table Books(
	Id integer primary key autoincrement,
	Title nvarchar(255) not null,
	AuthorCode nvarchar(50) not null,
	PublisherCode nvarchar(50) not null,
	Borrowed bit not null default 0
);

