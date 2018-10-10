CREATE DATABASE PurchaseOrderDb
USE PurchaseOrderDb

CREATE TABLE SUPPLIER (
SupplierNumber CHAR(4) PRIMARY KEY,
SupplierName VARCHAR(15) NOT NULL,
SupplierAddress VARCHAR(40))

CREATE TABLE ITEM (
ItemCode CHAR(4) PRIMARY KEY,
ItemDescription VARCHAR(15) NOT NULL,
ItemRate MONEY)

CREATE TABLE POMASTER (
PurchaseOrderNO CHAR(4) PRIMARY KEY,
PurchaseDate DATETIME,
SupplierNumber CHAR(4) REFERENCES SUPPLIER(SupplierNumber))

CREATE TABLE PODETAIL (
PurchaseOrderNO CHAR(4) REFERENCES POMASTER(PurchaseOrderNO),
ItemCode CHAR(4) REFERENCES ITEM(ItemCode),
Quantity INT,
CONSTRAINT PODetail_PK PRIMARY KEY(PurchaseOrderNO, ItemCode))



INSERT INTO SUPPLIER VALUES('S001', 'WIPRO', 'BENGALURU')
INSERT INTO SUPPLIER VALUES('S002', 'HP', 'CHENNAI')
INSERT INTO SUPPLIER VALUES('S003', 'SATYAM', 'HYDERABAD')
INSERT INTO SUPPLIER VALUES('S004', 'LnT', 'MUMBAI')
INSERT INTO SUPPLIER VALUES('S005', 'IBM', 'DELHI')

INSERT INTO ITEM VALUES('I001', 'MOUSE', 600)
INSERT INTO ITEM VALUES('I002', 'KEYBOARD', 1200)
INSERT INTO ITEM VALUES('I003', 'PRINTER', 6500)
INSERT INTO ITEM VALUES('I004', '80GB HDD', 4500)
INSERT INTO ITEM VALUES('I005', 'MONITOR', 8750)

INSERT INTO POMASTER VALUES('P101', '05/01/2008', 'S002')
INSERT INTO POMASTER VALUES('P102', '05/01/2008', 'S005')
INSERT INTO POMASTER VALUES('P103', '05/03/2008', 'S001')
INSERT INTO POMASTER VALUES('P104', '05/04/2008', 'S002')
INSERT INTO POMASTER VALUES('P105', '05/05/2008', 'S003')

INSERT INTO PODETAIL VALUES('P101', 'I002', 10)
INSERT INTO PODETAIL VALUES('P101', 'I005', 5)
INSERT INTO PODETAIL VALUES('P102', 'I003', 4)
INSERT INTO PODETAIL VALUES('P103', 'I005', 7)
INSERT INTO PODETAIL VALUES('P103', 'I004', 2)
INSERT INTO PODETAIL VALUES('P104', 'I003', 5)
INSERT INTO PODETAIL VALUES('P104', 'I004', 3)
INSERT INTO PODETAIL VALUES('P104', 'I005', 6)
INSERT INTO PODETAIL VALUES('P105', 'I002', 8)

Create Procedure AddSupplier
(
	@SupplierNumber char(4),
	@SupplierName varchar(15),
	@SupplierAddress varchar(40)
)
as
 Begin
	Insert into SUPPLIER ( SupplierNumber, SupplierName, SupplierAddress)
					values(@SupplierNumber, @SupplierName, @SupplierAddress)
 End


Create Procedure AddItem
(
	@ItemCode char(4),
	@ItemDescription varchar(15),
	@ItemRate Money
)
 as
	Begin
		Insert into ITEM ( ItemCode, ItemDescription, ItemRate)
				values( @ItemCode, @ItemDescription, @ItemRate)
	End

Create Procedure AddPOMaster
(
	@PurchaseOrderNO char(4),
	@PurchaseDate DateTime,
	@SupplierNumber char(4)
)
as
 Begin
	Insert into POMASTER ( PurchaseOrderNO, PurchaseDate, SupplierNumber )
				values( @PurchaseOrderNO, @PurchaseDate, @SupplierNumber)
 End

Create Procedure AddPODetail
(
	@PurchaseOrderNO char(4),
	@ItemCode char(4),
	@Quantity int
)
as
 Begin
	Insert into PODETAIL ( PurchaseOrderNO, ItemCode, Quantity)
				values (@PurchaseOrderNO, @ItemCode, @Quantity)
 End