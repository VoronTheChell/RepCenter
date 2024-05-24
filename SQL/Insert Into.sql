use RepCenter;

INSERT INTO Student (FIO, Date_Birth, Number_Phone, Predmet) VALUES ('Дефеченко Виталий Дмитривич', '09/01/2005', '+7905384687', 'Математика');
INSERT INTO Repetitors (FIO, Phone_Number, Kvalification, Predmets) VALUES ('Федоровна Анастасия Александровна', '+749865149814198', 'Мастер наук', 'Математика');
INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Begin, Time_of_Zaniyatia) VALUES (1, 1, '18:30', '3 часа 30 мин.');
INSERT INTO Pridments (Name_Pridment) VALUES ('Математика');
INSERT INTO Payment (student_id, tutor_id, Date_of_Payment, Summ_Payment) VALUES (1, 1, '25/09/22', 5000);

