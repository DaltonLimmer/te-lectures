CREATE TABLE users
(
	id			int				identity(1,1),
	name		varchar(50)		not null,
	username	varchar(50)		not null unique,
	email		varchar(100)	not null unique,	
);

INSERT INTO users VALUES ('Steve Ro', 'SteveR', 'Steve.Ro@gmail.com');
INSERT INTO users VALUES ('Bo John', 'Bo', 'Bo@msn.com');
INSERT INTO users VALUES ('Melinda French', 'MGates', 'melinda@microsoft.com');
INSERT INTO users VALUES ('Grace Hopper', 'Grace', 'grace@us.navy.mil');
