Use Master
Go
Create Database BitDB
GO
CREATE TABLE Users(
    Email NVARCHAR(255) NOT NULL,
    UserPW NVARCHAR(255) NOT NULL,
    UserID INT NOT NULL,
    PhoneNumber INT NOT NULL,
    RegistartionDate DATE NOT NULL
);
ALTER TABLE
    Users ADD CONSTRAINT user_userid_primary PRIMARY KEY(UserID);
CREATE TABLE Customer(
    UserID INT NOT NULL,
    UAddress NVARCHAR(255) NOT NULL,
    Country NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(255) NOT NULL,
    Gender NCHAR(255) NOT NULL,
    CustomerType INT NOT NULL
);
ALTER TABLE
    Customers ADD CONSTRAINT customer_userid_primary PRIMARY KEY(UserID);
CREATE TABLE Admin(
    UserID INT NOT NULL,
    IsActiveAdmin INT NOT NULL,
    EnrolledCustomers INT NOT NULL,
    LastOnline DATE NOT NULL
);
ALTER TABLE
    UAdmin ADD CONSTRAINT admin_userid_primary PRIMARY KEY(UserID);
ALTER TABLE
    UAdmin ADD CONSTRAINT admin_isactiveadmin_primary PRIMARY KEY(IsActiveAdmin);
CREATE TABLE BusinessAccount(
    MainUserID INT NOT NULL,
    BusinessEmail NVARCHAR(255) NOT NULL,
    BusinessPassword NVARCHAR(255) NOT NULL,
    BusinessName NVARCHAR(255) NOT NULL,
    ActiveManagersNum INT NOT NULL,
    BusibessAdress NVARCHAR(255) NOT NULL,
    AnualIncome INT NOT NULL,
    NetWorth INT NOT NULL,
    BusinessOpenDate DATE NOT NULL,
    MainCurrency NCHAR(255) NOT NULL,
    TotalBalance FLOAT NOT NULL
);
ALTER TABLE
    BusinessAccount ADD CONSTRAINT businessaccount_mainuserid_primary PRIMARY KEY(MainUserID);
CREATE TABLE PrivateAccount(
    UserID INT NOT NULL,
    DateOfBirth DATE NOT NULL,
    MainCurrency NCHAR(255) NOT NULL,
    AnualIncome INT NOT NULL,
    TotalBalance FLOAT NOT NULL
);
ALTER TABLE
    PrivateAccount ADD CONSTRAINT privateaccount_userid_primary PRIMARY KEY(UserID);
CREATE TABLE Loan(
    UserID INT NOT NULL,
    LoanID INT NOT NULL,
    UserBalance FLOAT NOT NULL,
    Balance FLOAT NOT NULL
);
ALTER TABLE
    Loan ADD CONSTRAINT loan_userid_primary PRIMARY KEY(UserID);
CREATE TABLE TransactionLogs(
    TransactionID INT NOT NULL,
    SentAmt FLOAT NOT NULL,
    SenderID INT NOT NULL,
    ReceiverID INT NOT NULL,
    SenderType INT NOT NULL,
    ReceiverType INT NOT NULL
);
ALTER TABLE
    TransactionLogs ADD CONSTRAINT transactionlogs_transactionid_primary PRIMARY KEY(TransactionID);
CREATE TABLE CostumerType(
    id INT NOT NULL,
    UDesc NVARCHAR(255) NOT NULL
);
ALTER TABLE
    CostumerType ADD CONSTRAINT costumertype_id_primary PRIMARY KEY(id);
ALTER TABLE
    TransactionLogs ADD CONSTRAINT transactionlogs_sentamt_foreign FOREIGN KEY(SentAmt) REFERENCES Customer(UserID);
ALTER TABLE
    TransactionLogs ADD CONSTRAINT transactionlogs_senderid_foreign FOREIGN KEY(SenderID) REFERENCES Customer(UserID);
ALTER TABLE
    BusinessAccount ADD CONSTRAINT businessaccount_businessemail_foreign FOREIGN KEY(BusinessEmail) REFERENCES Customer(UserID);
ALTER TABLE
    Customer ADD CONSTRAINT customer_customertype_foreign FOREIGN KEY(CustomerType) REFERENCES CostumerType(id);










