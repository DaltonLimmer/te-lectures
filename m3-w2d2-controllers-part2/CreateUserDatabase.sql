create database UserDatabase;
go

use UserDatabase;
go

--drop table SiteUser;

CREATE TABLE SiteUser (
    UserId integer identity NOT NULL,
    EmailAddress varchar(128) NOT NULL,
	Password varchar(30) NOT NULL
    CONSTRAINT pk_user_id PRIMARY KEY (UserId)
);
