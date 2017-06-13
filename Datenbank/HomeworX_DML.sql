
-- --------------------------------------------------------------
-- --------------------------------------------------------------
-- --------------------------SQL Data Script---------------------
-- --------------------------------------------------------------
-- --------------------------------------------------------------

-- --------------------------------------------------------------
-- -------------------------- Subject ---------------------------
-- --------------------------------------------------------------

INSERT INTO [Subject] VALUES(NEWID(),'En','Englisch','Englisch Unterricht')
INSERT INTO [Subject] VALUES(NEWID(),'Fr','Franz�sisch','Franz�sisch Unterricht')
INSERT INTO [Subject] VALUES(NEWID(),'Mat','Mathematik','Mathematik Unterricht')
INSERT INTO [Subject] VALUES(NEWID(),'De','Deutsch','Deutsch Unterricht')

-- --------------------------------------------------------------
-- --------------------------Topic ------------------------------
-- --------------------------------------------------------------

INSERT INTO [Topic] VALUES(NEWID(),'Past Simple', 'Zeit: Past Simple', (SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO [Topic] VALUES(NEWID(),'Past Perfect', 'Zeit: Past Perfect', (SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO [Topic] VALUES(NEWID(),'Past Continuous', 'Zeit: Past Continuous', (SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO [Topic] VALUES(NEWID(),'Voci', 'Voci', (SELECT UID FROM Subject WHERE Code = 'En'))

INSERT INTO [Topic] VALUES(NEWID(),'Passe Compose', 'Zeit: Passe Compose', (SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO [Topic] VALUES(NEWID(),'Passe Simple', 'Zeit: Passe Simple', (SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO [Topic] VALUES(NEWID(),'Future 1', 'Zeit: Future 1', (SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO [Topic] VALUES(NEWID(),'Future 2', 'Zeit: Future 2', (SELECT UID FROM Subject WHERE Code = 'Fr'))

INSERT INTO [Topic] VALUES(NEWID(),'Wurzeln', 'Algebra: Wurzeln', (SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO [Topic] VALUES(NEWID(),'Exponenten', 'Algebra: Exponenten', (SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO [Topic] VALUES(NEWID(),'Kugeln', 'Geometrie: Kugeln', (SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO [Topic] VALUES(NEWID(),'Pyramiden', 'Geometrie: Pyramiden', (SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO [Topic] VALUES(NEWID(),'Kreis', 'Geometrie: Kreis', (SELECT UID FROM Subject WHERE Code = 'Mat'))

INSERT INTO [Topic] VALUES(NEWID(),'Verben', 'Verben', (SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO [Topic] VALUES(NEWID(),'Pr�sens', 'Zeit: Pr�sens', (SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO [Topic] VALUES(NEWID(),'Satzzeichen', 'Satzzeichen', (SELECT UID FROM Subject WHERE Code = 'De'))

-- --------------------------------------------------------------
-- --------------------------Exam -------------------------------
-- --------------------------------------------------------------
DECLARE @UIDExam1 UNIQUEIDENTIFIER= (SELECT NEWID())
DECLARE @UIDExam2 UNIQUEIDENTIFIER= (SELECT NEWID())
DECLARE @UIDExam3 UNIQUEIDENTIFIER= (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDExam1,'Mathe Pr�fung 1', 'Detail der Pr�fung 1','13.06.2017',(SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO Exam VALUES (@UIDExam1,0,NULL,NULL)

INSERT INTO Appointment VALUES(@UIDExam2,'Mathe Pr�fung 2', 'Detail der Pr�fung 2','20.06.2017',(SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO Exam VALUES(@UIDExam2,1,'18.06.2017','MyMail@MailService.com')

INSERT INTO Appointment VALUES(@UIDExam3,'Mathe Pr�fung 3', 'Detail der Pr�fung 3','25.06.2017',(SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO Exam VALUES(@UIDExam3,0,NULL,NULL)

SET @UIDExam1 = (SELECT NEWID())
SET @UIDExam2 = (SELECT NEWID())
SET @UIDExam3 = (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDExam1,'Englisch Pr�fung 1', 'Detail der Pr�fung 1','13.06.2017',(SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO Exam VALUES (@UIDExam1,0,NULL,NULL)

INSERT INTO Appointment VALUES(@UIDExam2,'Englisch Pr�fung 2', 'Detail der Pr�fung 2','20.06.2017',(SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO Exam VALUES(@UIDExam2,1,'18.06.2017','MyMail@MailService.com')

INSERT INTO Appointment VALUES(@UIDExam3,'Englisch Pr�fung 3', 'Detail der Pr�fung 3','25.06.2017',(SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO Exam VALUES(@UIDExam3,0,NULL,NULL)

SET @UIDExam1 = (SELECT NEWID())
SET @UIDExam2 = (SELECT NEWID())
SET @UIDExam3 = (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDExam1,'Franz�sisch Pr�fung 1', 'Detail der Pr�fung 1','13.06.2017',(SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO Exam VALUES (@UIDExam1,0,NULL,NULL)

INSERT INTO Appointment VALUES(@UIDExam2,'Franz�sisch Pr�fung 2', 'Detail der Pr�fung 2','20.06.2017',(SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO Exam VALUES(@UIDExam2,1,'18.06.2017','MyMail@MailService.com')

INSERT INTO Appointment VALUES(@UIDExam3,'Franz�sisch Pr�fung 3', 'Detail der Pr�fung 3','25.06.2017',(SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO Exam VALUES(@UIDExam3,0,NULL,NULL)

SET @UIDExam1 = (SELECT NEWID())
SET @UIDExam2 = (SELECT NEWID())
SET @UIDExam3 = (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDExam1,'Deutsch Pr�fung 1', 'Detail der Pr�fung 1','13.06.2017',(SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO Exam VALUES (@UIDExam1,0,NULL,NULL)

INSERT INTO Appointment VALUES(@UIDExam2,'Deutsch Pr�fung 2', 'Detail der Pr�fung 2','20.06.2017',(SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO Exam VALUES(@UIDExam2,1,'18.06.2017','MyMail@MailService.com')

INSERT INTO Appointment VALUES(@UIDExam3,'Deutsch Pr�fung 3', 'Detail der Pr�fung 3','25.06.2017',(SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO Exam VALUES(@UIDExam3,0,NULL,NULL)

-- --------------------------------------------------------------
-- --------------------------Homework ---------------------------
-- --------------------------------------------------------------

DECLARE @UIDHomework1 UNIQUEIDENTIFIER= (SELECT NEWID())
DECLARE @UIDHomework2 UNIQUEIDENTIFIER= (SELECT NEWID())
DECLARE @UIDHomework3 UNIQUEIDENTIFIER= (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDHomework1,'Mathe Hausaufgabe 1', 'Detail der Hausaufgabe 1','10.06.2017',(SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO Homework VALUES (@UIDHomework1,0)

INSERT INTO Appointment VALUES(@UIDHomework2,'Mathe Hausaufgabe 2', 'Detail der Hausaufgabe 2','11.06.2017',(SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO Homework VALUES(@UIDHomework2,5)

INSERT INTO Appointment VALUES(@UIDHomework3,'Mathe Hausaufgabe 3', 'Detail der Hausaufgabe 3','12.06.2017',(SELECT UID FROM Subject WHERE Code = 'Mat'))
INSERT INTO Homework VALUES(@UIDHomework3,10)

SET @UIDHomework1 = (SELECT NEWID())
SET @UIDHomework2 = (SELECT NEWID())
SET @UIDHomework3 = (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDHomework1,'Deutsch Hausaufgabe 1', 'Detail der Hausaufgabe 1','10.06.2017',(SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO Homework VALUES (@UIDHomework1,0)

INSERT INTO Appointment VALUES(@UIDHomework2,'Deutsch Hausaufgabe 2', 'Detail der Hausaufgabe 2','11.06.2017',(SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO Homework VALUES(@UIDHomework2,5)

INSERT INTO Appointment VALUES(@UIDHomework3,'Deutsch Hausaufgabe 3', 'Detail der Hausaufgabe 3','12.06.2017',(SELECT UID FROM Subject WHERE Code = 'De'))
INSERT INTO Homework VALUES(@UIDHomework3,10)

SET @UIDHomework1 = (SELECT NEWID())
SET @UIDHomework2 = (SELECT NEWID())
SET @UIDHomework3 = (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDHomework1,'Franz�sisch Hausaufgabe 1', 'Detail der Hausaufgabe 1','10.06.2017',(SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO Homework VALUES (@UIDHomework1,0)

INSERT INTO Appointment VALUES(@UIDHomework2,'Franz�sisch Hausaufgabe 2', 'Detail der Hausaufgabe 2','11.06.2017',(SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO Homework VALUES(@UIDHomework2,5)

INSERT INTO Appointment VALUES(@UIDHomework3,'Franz�sisch Hausaufgabe 3', 'Detail der Hausaufgabe 3','12.06.2017',(SELECT UID FROM Subject WHERE Code = 'Fr'))
INSERT INTO Homework VALUES(@UIDHomework3,10)

SET @UIDHomework1 = (SELECT NEWID())
SET @UIDHomework2 = (SELECT NEWID())
SET @UIDHomework3 = (SELECT NEWID())

INSERT INTO Appointment VALUES(@UIDHomework1,'Englisch Hausaufgabe 1', 'Detail der Hausaufgabe 1','10.06.2017',(SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO Homework VALUES (@UIDHomework1,0)

INSERT INTO Appointment VALUES(@UIDHomework2,'Englisch Hausaufgabe 2', 'Detail der Hausaufgabe 2','11.06.2017',(SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO Homework VALUES(@UIDHomework2,5)

INSERT INTO Appointment VALUES(@UIDHomework3,'Englisch Hausaufgabe 3', 'Detail der Hausaufgabe 3','12.06.2017',(SELECT UID FROM Subject WHERE Code = 'En'))
INSERT INTO Homework VALUES(@UIDHomework3,10)

-- --------------------------------------------------------------
-- --------------------------TopicToAppointment------------------
-- --------------------------------------------------------------

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Satzzeichen'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Satzzeichen'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Satzzeichen'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Verben'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Verben'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Verben'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pr�sens'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pr�sens'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pr�sens'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kreis'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kreis'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kreis'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kugeln'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kugeln'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kugeln'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pyramiden'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pyramiden'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pyramiden'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 1'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 1'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 1'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 2'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 2'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 2'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Passe Compose'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Passe Compose'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Passe Compose'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Voci'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Voci'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Voci'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Simple'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Simple'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Simple'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Perfect'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Perfect'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Perfect'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Hausaufgabe 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Satzzeichen'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Satzzeichen'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Satzzeichen'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Verben'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Verben'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Verben'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pr�sens'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pr�sens'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pr�sens'),(SELECT UID FROM Appointment WHERE Description = 'Deutsch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kreis'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kreis'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kreis'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kugeln'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kugeln'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Kugeln'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pyramiden'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pyramiden'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Pyramiden'),(SELECT UID FROM Appointment WHERE Description = 'Mathe Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 1'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 1'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 1'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 2'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 2'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Future 2'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Passe Compose'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Passe Compose'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Passe Compose'),(SELECT UID FROM Appointment WHERE Description = 'Franz�sisch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Voci'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Voci'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Voci'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Simple'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Simple'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Simple'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 3'))

INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Perfect'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 1'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Perfect'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 2'))
INSERT INTO TopicToAppointment VALUES (NEWID(),(SELECT UID FROM Topic WHERE Description = 'Past Perfect'),(SELECT UID FROM Appointment WHERE Description = 'Englisch Pr�fung 3'))