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

Create Procedure spAddSupplier
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


Create Procedure spAddItem
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

Create Procedure spAddPOMaster
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

Create Procedure spAddPODetail
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

Create Procedure spGetAllItems
as
 Begin
	Select * From ITEM
 End

Create Procedure spGetAllSuppliers
as
 Begin
	Select * From SUPPLIER
 End

Create Procedure spGetAllOrders
as
 Begin
	 Select T1.PurchaseOrderNo, T3.ItemDescription , T2.Quantity, T1.PurchaseDate, T4.SupplierName from POMASTER as T1
		right join PODETAIL as T2 ON T1.PurchaseOrderNO = T2.PurchaseOrderNO 
		right join ITEM as T3 ON T2.ItemCode = T3.ItemCode
		right join SUPPLIER as T4 ON T1.SupplierNumber = T4.SupplierNumber
 End

Create Procedure spUpdateSupplier
(
	@SupplierNumber CHAR(4),
	@SupplierName VARCHAR(15),
	@SupplierAddress VARCHAR(40)
)
as
 Begin
	Update SUPPLIER set SupplierName = @SupplierName, SupplierAddress = @SupplierAddress
	where SupplierNumber = @SupplierNumber
 End

Create Procedure spUpdateItem
(
	@ItemCode CHAR(4),
	@ItemDescription VARCHAR(15),
	@ItemRate MONEY
)
as
 Begin
	Update ITEM set ItemDescription = @ItemDescription, ItemRate = @ItemRate
	 where ItemCode = @ItemCode
 End

Create Procedure spDeleteSupplier
(
	@SupplierNumber CHAR(4)
)
as
 Begin
	Delete From SUPPLIER
	 where SupplierNumber = @SupplierNumber
 End

Create Procedure spDeleteItem
(
	@ItemCode CHAR(4)
)
as
 Begin
	Delete From ITEM
	 where ItemCode = @ItemCode
 End

Create Procedure spDeleteOrder
(
	@PurchaseOrderNO char(4)
)
as
 Begin
	Delete From PODETAIL
	 where PurchaseOrderNO = @PurchaseOrderNO;
	Delete From POMASTER
	 where PurchaseOrderNO = @PurchaseOrderNO;
 End