--create database RepCenter;
use RepCenter;

create table register
(
	id_User int PRIMARY KEY IDENTITY,
	login_user varchar(250) UNIQUE NOT NULL,
	password_user varchar(25) NOT NULL,
	subject_user varchar(25) NOT NULL,
	status_user varchar(25) NOT NULL,
);

insert into register (login_user, password_user, subject_user, status_user) values ('admin', 'admin', 'All', 'admin');

--insert into register (login_user, password_user, subject_user, status_user) values ('2', '2', 'Математика', 'учитель');

select * from register;