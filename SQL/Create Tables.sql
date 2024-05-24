--create database RepCenter;
use RepCenter;

create table Student
(
	student_id int PRIMARY KEY IDENTITY,
	FIO varchar(250) NOT NULL,
	Date_Birth varchar(25) NOT NULL,
	Number_Phone varchar(25) UNIQUE NOT NULL,
	Predmet varchar(25) NOT NULL
);

create table Repetitors
(
	tutor_id int PRIMARY KEY IDENTITY,
	FIO varchar(250) NOT NULL,
	Phone_Number varchar(25) UNIQUE NOT NULL,
	Kvalification varchar(250) UNIQUE NOT NULL,
	Predmets varchar(25) NOT NULL
);

create table Raspisanie_Zaniyatiy
(
	schedule_id int PRIMARY KEY IDENTITY,
	student_id int,
	tutor_id int,
	Time_Begin varchar(25) NOT NULL,
	Time_of_Zaniyatia varchar(25) NOT NULL,

	FOREIGN KEY (student_id) REFERENCES Student(student_id),
	FOREIGN KEY (tutor_id) REFERENCES Repetitors(tutor_id),
);

create table Pridments
(
	subject_id int PRIMARY KEY IDENTITY,
	Name_Pridment varchar(45) NOT NULL
);

create table Payment
(
	payment_id int PRIMARY KEY IDENTITY,
	student_id int,
	tutor_id int,
	Date_of_Payment varchar(45) NOT NULL,
	Summ_Payment int NOT NULL,

	FOREIGN KEY (student_id) REFERENCES Student(student_id),
	FOREIGN KEY (tutor_id) REFERENCES Repetitors(tutor_id),
);