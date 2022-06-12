Use master
Create Database BitDB
GO

Use BitDB
GO


CREATE TABLE "Users"(
    "Email" NVARCHAR(255) NOT NULL,
    "Password" NVARCHAR(255) NOT NULL,
    "UserName" NVARCHAR(255) NOT NULL,
    "UserID" INT IDENTITY(1 ,1) NOT NULL,
    "Phone Number" NVARCHAR(255) NOT NULL, 
);

ALTER TABLE
    "Users" ADD CONSTRAINT "users_userid_primary" PRIMARY KEY("UserID");


CREATE TABLE "Customers"(
    "CustomerID" INT NOT NULL,
    
    "UserID" INT NOT NULL
);
ALTER TABLE
    "Customers" ADD CONSTRAINT "customers_customerid_primary" PRIMARY KEY("CustomerID");

CREATE TABLE "BusinessAccounts"(
    "AccountID"INT NOT NULL,
   
    "TotalBalance" FLOAT NOT NULL,
    "CustomerID" INT NOT NULL
);
ALTER TABLE
    "BusinessAccounts" ADD CONSTRAINT "businessaccounts_accountid_primary" PRIMARY KEY("AccountID");
CREATE TABLE "PrivateAccounts"(
    "AccountID" INT NOT NULL,
    
    "TotalBalance" FLOAT NOT NULL,
    "CustomerID" INT NOT NULL
);
ALTER TABLE
    "PrivateAccounts" ADD CONSTRAINT "privateaccounts_accountid_primary" PRIMARY KEY("AccountID");

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
CREATE TABLE [dbo].[Cards](
	[Name] [nvarchar](50) NOT NULL,
	[ID] [nvarchar](16) NOT NULL,
	[Date] [date] NOT NULL,
	[CVC] [nchar](3) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Cards] FOREIGN KEY([ID])
REFERENCES [dbo].[Cards] ([ID])
GO

ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Cards]
ALTER TABLE
    "TransactionLogs" ADD CONSTRAINT "transactionlogs_transactionid_primary" PRIMARY KEY("TransactionID");
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


    USE [BitDB]
GO

INSERT INTO [dbo].[Users]
           ([Email]
           ,[Password]
           ,[UserName]
           ,[Phone Number])
           
     VALUES
           ('itay@gmail.com'
           ,'123'
           ,'Itay'
           ,'0532214510')
GO