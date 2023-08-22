CREATE TABLE Admin (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(255) NOT NULL,
    UserPassword NVARCHAR(255) NOT NULL
);

INSERT INTO Admin (UserName, UserPassword)
VALUES ('A', 'B');


CREATE TABLE Customer (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Birthday DATETIME,
    Address NVARCHAR(500),
    Job NVARCHAR(255)
);

INSERT INTO Customer (Name, Surname, Email, PhoneNumber, Birthday, Address, Job)
VALUES ('John', 'Doe', 'john.doe@example.com', '1234567890', '1990-01-15', '123 Main St', 'Engineer');

INSERT INTO Customer (Name, Surname, Email, PhoneNumber, Birthday, Address, Job)
VALUES ('Jane', 'Smith', 'jane.smith@example.com', '9876543210', '1985-05-20', '456 Elm St', 'Teacher');

INSERT INTO Customer (Name, Surname, Email, PhoneNumber, Birthday, Address, Job)
VALUES ('Michael', 'Johnson', 'michael.johnson@example.com', '5551234567', '1995-11-08', '789 Oak Ave', 'Doctor');
