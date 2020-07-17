CREATE TABLE Company ( 
	Company_id INTEGER CONSTRAINT Company_pk PRIMARY KEY,
	CompanyName VARCHAR(30) NOT NULL
);

CREATE TABLE Department (
	Department_id INTEGER CONSTRAINT Department_pk PRIMARY KEY,
	DepartmentName VARCHAR(70) NOT NULL,
	Company_id INTEGER NOT NULL
		CONSTRAINT Department_fk_Company
        REFERENCES Company(Company_id)
);

CREATE TABLE Employee (
	Employee_id INTEGER CONSTRAINT Employee_pk PRIMARY KEY,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Email VARCHAR(40) NOT NULL,
	Company_id INTEGER NOT NULL
		CONSTRAINT Employee_fk_Department
        REFERENCES Department(Department_id)
);

INSERT INTO Company VALUES(1, 'Mono Ltd.');

INSERT INTO Department VALUES(1, 'IT Department', 1);
INSERT INTO Department VALUES(2, 'The Tehnical Office', 1);
INSERT INTO Department VALUES(3, 'Planning Department', 1);
INSERT INTO Department VALUES(4, 'Finances & Accounting Department', 1);
INSERT INTO Department VALUES(5, 'Contacts Department', 1);
INSERT INTO Department VALUES(6, 'Purchasing Department', 1);

INSERT INTO Employee VALUES(1, 'Jelena', 'Tufeković', 'notifications@smartrecruiters.com', 1);
INSERT INTO Employee VALUES(2, 'Josip', 'Pavičić', 'josip.pavicic@gmail.com', 1);
INSERT INTO Employee VALUES(3, 'Tea', 'Bašić', 'tteabasic98@gmail.com', 2);
INSERT INTO Employee VALUES(4, 'Dunja', 'Markulak', 'dunja.markulak@gmail.com', 2);
INSERT INTO Employee VALUES(5, 'Roko', 'Erceg', 'erceg.roko@gmail.com', 3);
INSERT INTO Employee VALUES(6, 'Borna', 'Sirovec', 'siro@borna.hr', 3);
INSERT INTO Employee VALUES(7, 'Petar', 'Kelava', 'kelly@petar.hr', 4);
INSERT INTO Employee VALUES(8, 'Borna', 'Gajić', 'borna.gajic@yahoo.com', 4);
INSERT INTO Employee VALUES(9, 'Dražen', 'Šokčević', 'drazen@gmail.com', 5);
INSERT INTO Employee VALUES(10, 'Antonio', 'Vidaković', 'avida@mathos.hr', 5);
INSERT INTO Employee VALUES(11, 'Filip', 'Vuković', 'iamfilip@vukovic.hr', 6);
INSERT INTO Employee VALUES(12, 'Krunoslav', 'Vrkljan', 'vrki99@gmail.com', 6);


SELECT CompanyName, DepartmentName, FirstName, LastName, Email
FROM Company c, Department d, Employee e
WHERE c.Company_id = d.Company_id
AND c.Company_id = e.Company_id;

