create table Users(
	Id bigint identity(1, 1) primary key,
	Code varchar(50) not null,
	Name varchar(255) not null
);

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

