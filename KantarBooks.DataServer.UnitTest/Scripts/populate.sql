insert into Users(Id, Code, Name)
values(1, 'KBU1', 'John Smith');

insert into Users(Id, Code, Name)
values(2, 'KBU2', 'Lois Lane');

insert into Users(Id, Code, Name)
values(3, 'KBU3', 'Mike Tyson');

insert into Books(Id, Code, Name, AuthorCode, PublisherCode, Borrowed, BorrowerId)
values(1, 'KBB1', 'The Right Thing, Right Now', 'KBA1', 'KBP1', 0, NULL);

insert into Books(Id, Code, Name, AuthorCode, PublisherCode, Borrowed, BorrowerId)
values(2, 'KBB2', 'The Process Mind', 'KBA2', 'KBP2', 1, 1);

	insert into Books(Id, Code, Name, AuthorCode, PublisherCode, Borrowed, BorrowerId)
values(3, 'KBB3', 'The Light of the Soul', 'KBA3', 'KBP3', 0, NULL);
