CREATE TABLE Company ( 
	Company_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	CompanyName VARCHAR(30) NOT NULL
);

CREATE TABLE Department (
	Department_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	DepartmentName VARCHAR(70) NOT NULL,
	Company_id UNIQUEIDENTIFIER NOT NULL
		CONSTRAINT Department_fk_Company
        REFERENCES Company(Company_id)
);

CREATE TABLE Employee (
	Employee_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Email VARCHAR(40) NOT NULL,
	Department_id UNIQUEIDENTIFIER NOT NULL
		CONSTRAINT Employee_fk_Department
        REFERENCES Department(Department_id)
);


INSERT INTO Company VALUES(default, 'Mono Ltd.');

SELECT* FROM Company;

INSERT INTO Department VALUES(default, 'IT Department', '54B79A93-5718-47BE-A4E8-5A443840A812');
INSERT INTO Department VALUES(default, 'The Tehnical Office', '54B79A93-5718-47BE-A4E8-5A443840A812');
INSERT INTO Department VALUES(default, 'Planning Department', '54B79A93-5718-47BE-A4E8-5A443840A812');
INSERT INTO Department VALUES(default, 'Finances & Accounting Department', '54B79A93-5718-47BE-A4E8-5A443840A812');
INSERT INTO Department VALUES(default, 'Contacts Department', '54B79A93-5718-47BE-A4E8-5A443840A812');
INSERT INTO Department VALUES(default, 'Purchasing Department', '54B79A93-5718-47BE-A4E8-5A443840A812');

SELECT * FROM Department;

INSERT INTO Employee VALUES(default, 'Jelena', 'Tufeković', 'notifications@smartrecruiters.com', 'DC8E4BF0-18BF-4A63-AAC0-16EC588CF56E');
INSERT INTO Employee VALUES(default, 'Josip', 'Pavičić', 'josip.pavicic@gmail.com', 'DC8E4BF0-18BF-4A63-AAC0-16EC588CF56E');
INSERT INTO Employee VALUES(default, 'Tea', 'Bašić', 'tteabasic98@gmail.com', 'F204EEA5-F875-4F1C-AAE9-2B73C8AF5CB3');
INSERT INTO Employee VALUES(default, 'Dunja', 'Markulak', 'dunja.markulak@gmail.com', 'F204EEA5-F875-4F1C-AAE9-2B73C8AF5CB3');
INSERT INTO Employee VALUES(default, 'Roko', 'Erceg', 'erceg.roko@gmail.com', 'B3AD0776-BD7D-46F0-9C19-4318157BB661');
INSERT INTO Employee VALUES(default, 'Borna', 'Sirovec', 'siro@borna.hr', 'B3AD0776-BD7D-46F0-9C19-4318157BB661');
INSERT INTO Employee VALUES(default, 'Petar', 'Kelava', 'kelly@petar.hr', '7AFD5A69-CB37-461E-B27B-8C75AF65C67B');
INSERT INTO Employee VALUES(default, 'Borna', 'Gajić', 'borna.gajic@yahoo.com', '7AFD5A69-CB37-461E-B27B-8C75AF65C67B');
INSERT INTO Employee VALUES(default, 'Dražen', 'Šokčević', 'drazen@gmail.com', '692D399C-D93E-4D77-9111-9272050D9C8C');
INSERT INTO Employee VALUES(default, 'Antonio', 'Vidaković', 'avida@mathos.hr', '692D399C-D93E-4D77-9111-9272050D9C8C');
INSERT INTO Employee VALUES(default, 'Filip', 'Vuković', 'iamfilip@vukovic.hr', '402D6F15-E7A6-419F-9127-A6F78D74107F');
INSERT INTO Employee VALUES(default, 'Krunoslav', 'Vrkljan', 'vrki99@gmail.com', '402D6F15-E7A6-419F-9127-A6F78D74107F');

SELECT * FROM Employee;

SELECT CompanyName, DepartmentName, FirstName, LastName, Email
FROM Company c, Department d, Employee e
WHERE c.Company_id = d.Company_id
AND d.Department_id = e.Department_id;
