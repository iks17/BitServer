Use master
Create Database BitDB
GO

Use BitDB
GO

CREATE TABLE "Users"(
    "Email" NVARCHAR(255) NOT NULL,
    "Password" NVARCHAR(255) NOT NULL,
    "UserID" INT NOT NULL,
    "Phone Number" INT NOT NULL,
    "RegistartionDate" DATE NOT NULL
);
ALTER TABLE
    "Users" ADD CONSTRAINT "users_userid_primary" PRIMARY KEY("UserID");
CREATE TABLE "Customers"(
    "CustomerID" INT NOT NULL,
    "Address" NVARCHAR(255) NOT NULL,
    "Country" NVARCHAR(255) NOT NULL,
    "First Name" NVARCHAR(255) NOT NULL,
    "Gender" NCHAR(255) NOT NULL,
    "UserID" INT NOT NULL
);
ALTER TABLE
    "Customers" ADD CONSTRAINT "customers_customerid_primary" PRIMARY KEY("CustomerID");
CREATE TABLE "Admins"(
    "AdminID" INT NOT NULL,
    "EnrolledCustomers" INT NOT NULL,
    "LastOnline" DATE NOT NULL,
    "UserID" INT NOT NULL
);
ALTER TABLE
    "Admins" ADD CONSTRAINT "admins_adminid_primary" PRIMARY KEY("AdminID");
CREATE TABLE "BusinessAccounts"(
    "AccountID" NVARCHAR(255) NOT NULL,
    "BusinessEmail" NVARCHAR(255) NOT NULL,
    "BusinessPassword" NVARCHAR(255) NOT NULL,
    "BusinessName" NVARCHAR(255) NOT NULL,
    "ActiveManagersNum" INT NOT NULL,
    "BusibessAdress" NVARCHAR(255) NOT NULL,
    "Anual Income" INT NOT NULL,
    "NetWorth" INT NOT NULL,
    "BusinessOpenDate" DATE NOT NULL,
    "MainCurrency" NCHAR(255) NOT NULL,
    "TotalBalance" FLOAT NOT NULL,
    "CustomerID" INT NOT NULL
);
ALTER TABLE
    "BusinessAccounts" ADD CONSTRAINT "businessaccounts_accountid_primary" PRIMARY KEY("AccountID");
CREATE TABLE "PrivateAccounts"(
    "AccountID" NVARCHAR(255) NOT NULL,
    "DateOfBirth" DATE NOT NULL,
    "MainCurrency" NCHAR(255) NOT NULL,
    "AnualIncome" INT NOT NULL,
    "TotalBalance" FLOAT NOT NULL,
    "CustomerID" INT NOT NULL
);
ALTER TABLE
    "PrivateAccounts" ADD CONSTRAINT "privateaccounts_accountid_primary" PRIMARY KEY("AccountID");
CREATE TABLE "Loans"(
    "LoanID" INT NOT NULL,
    "UserBalance" FLOAT NOT NULL,
    "Balance" FLOAT NOT NULL,
    "ApprovedBy" INT NOT NULL,
    "BusinessID" NVARCHAR(255) NOT NULL,
    "PrivateID" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Loans" ADD CONSTRAINT "loans_loanid_primary" PRIMARY KEY("LoanID");
CREATE TABLE "TransactionLogs"(
    "TransactionID" INT NOT NULL,
    "SentAmt" INT NOT NULL,
    "SenderID" INT NOT NULL,
    "ReceiverID" INT NOT NULL,
    "SenderAccount" NVARCHAR(255) NOT NULL,
    "ReceiverAccount" NVARCHAR(255) NOT NULL,
    "TransactionDate" DATE NOT NULL,
    "IsConfirmed" BIT NOT NULL
);
ALTER TABLE
    "TransactionLogs" ADD CONSTRAINT "transactionlogs_transactionid_primary" PRIMARY KEY("TransactionID");
ALTER TABLE
    "Admins" ADD CONSTRAINT "admins_userid_foreign" FOREIGN KEY("UserID") REFERENCES "Users"("UserID");
ALTER TABLE
    "Customers" ADD CONSTRAINT "customers_userid_foreign" FOREIGN KEY("UserID") REFERENCES "Users"("UserID");
ALTER TABLE
    "BusinessAccounts" ADD CONSTRAINT "businessaccounts_customerid_foreign" FOREIGN KEY("CustomerID") REFERENCES "Customers"("CustomerID");
ALTER TABLE
    "TransactionLogs" ADD CONSTRAINT "transactionlogs_receiverid_foreign" FOREIGN KEY("ReceiverID") REFERENCES "Customers"("CustomerID");
ALTER TABLE
    "PrivateAccounts" ADD CONSTRAINT "privateaccounts_customerid_foreign" FOREIGN KEY("CustomerID") REFERENCES "Customers"("CustomerID");
ALTER TABLE
    "TransactionLogs" ADD CONSTRAINT "transactionlogs_senderid_foreign" FOREIGN KEY("SenderID") REFERENCES "Customers"("CustomerID");
ALTER TABLE
    "Loans" ADD CONSTRAINT "loans_approvedby_foreign" FOREIGN KEY("ApprovedBy") REFERENCES "Admins"("AdminID");
ALTER TABLE
    "Loans" ADD CONSTRAINT "loans_businessid_foreign" FOREIGN KEY("BusinessID") REFERENCES "BusinessAccounts"("AccountID");
ALTER TABLE
    "Loans" ADD CONSTRAINT "loans_privateid_foreign" FOREIGN KEY("PrivateID") REFERENCES "PrivateAccounts"("AccountID");