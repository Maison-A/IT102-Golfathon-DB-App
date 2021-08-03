-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes


-- --------------------------------------------------------------------------------
-- Drop procedure statements
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'uspAddGolfer' )					IS NOT NULL DROP PROCEDURE  uspAddGolfer
IF OBJECT_ID( 'uspAddEvent' )					IS NOT NULL DROP PROCEDURE  uspAddEvent
IF OBJECT_ID( 'uspAddGolferEvent' )				IS NOT NULL DROP PROCEDURE  uspAddGolferEvent


-- --------------------------------------------------------------------------------
-- Drop views
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'VGolfersIn' )				IS NOT NULL DROP VIEW		VGolfersIn
IF OBJECT_ID( 'VGolfersOut' )				IS NOT NULL DROP VIEW		VGolfersOut


-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER			NOT NULL
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID			INTEGER			NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER			NOT NULL
	,intGolferID			INTEGER			NOT NULL
	,intEventYearID			INTEGER			NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER			NOT NULL
	,intGolferID					INTEGER			NOT NULL
	,intEventYearID					INTEGER			NOT NULL
	,intSponsorID					INTEGER			NOT NULL
	,monPledgeAmount				MONEY			NOT NULL
	,intSponsorTypeID				INTEGER			NOT NULL
	,intPaymentTypeID				INTEGER			NOT NULL
	,blnPaid						BIT				NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)

-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )



-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES	 (1, 'Female')
		,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES	(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2018)
			,( 2, 2019)
			,(3, 2020)

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )

---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )
		,(3, 'name','last','address','city','state','00000','112222222','email',4,2)
---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)
	VALUES (1, 1, 1)
		,(2, 2, 1)
		,(3, 1, 2)
		,(4, 2, 2)
		

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
VALUES	 ( 1, 1, 1, 1, 25.00, 1, 1, 1 )
		,( 2, 1, 1, 2, 25.00, 1, 1, 1 )
		
-- --------------------------------------------------------------------------------
-- Create Views
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- View to select golfers IN events
-- --------------------------------------------------------------------------------
GO
CREATE VIEW VGolfersIn
AS
SELECT
	TG.intGolferID
	,TG.strFirstName
	,TG.strLastName
	,TEY.intEventYear
	,TEY.intEventYearID

FROM
	TGolfers AS TG
		JOIN TGolferEventYears AS TGEY
			ON TG.intGolferID = TGEY.intGolferID
		JOIN TEventYears AS TEY
			ON TEY.intEventYearID = TGEY.intEventYearID

GO

--SELECT * FROM VGolfersIn

-- --------------------------------------------------------------------------------
-- View to select golfers NOT in events
-- --------------------------------------------------------------------------------

GO
CREATE VIEW VGolfersOut
AS
SELECT
	 TG.intGolferID
	,TG.strFirstName
	,TG.strLastName

FROM
	TGolfers AS TG
		--JOIN TGolferEventYears AS TGEY
		--	ON TG.intGolferID = TGEY.intGolferID
		--JOIN TEventYears AS TEY
		--	ON TEY.intEventYearID = TGEY.intEventYearID

WHERE
	intGolferID NOT IN (SELECT intGolferID FROM TGolferEventYears)

GO

--SELECT * FROM VGolfersOut

GO
-- --------------------------------------------------------------------------------
-- Create Stored Procedures
-- --------------------------------------------------------------------------------
GO

CREATE PROCEDURE uspAddGolfer
	  @intGolferID				AS INTEGER OUTPUT
	, @strFirstName				AS VARCHAR(50)
	, @strLastName				AS VARCHAR(50)
	, @strStreetAddress			AS VARCHAR(50)
	, @strCity					AS VARCHAR(50)
	, @strState					AS VARCHAR(50)
	, @strZip					AS VARCHAR(50)
	, @strPhoneNumber			AS VARCHAR(50)
	, @strEmail					AS VARCHAR(50)
	, @intShirtSizeID			AS INTEGER
	, @intGenderID				AS INTEGER

AS
SET XACT_ABORT ON -- terminate and rollback if fail


BEGIN TRANSACTION

	-- remove @ sign on right side of equals
	SELECT @intGolferID = MAX(intGolferID) + 1
	FROM TGolfers (TABLOCKX) -- lock til end of transaction

	-- set deafult if empty
	SELECT @intGolferID = COALESCE(@intGolferID, 1)

	-- set default if empty
	SELECT @intShirtSizeID = COALESCE(@intShirtSizeID, 1) 

	-- set default if empty
	SELECT @intGenderID = COALESCE(@intGenderID, 1) 

	INSERT INTO TGolfers(intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState
	, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
	
	Values (@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState
	, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID)

COMMIT TRANSACTION

GO
-- test
--DECLARE @intGolferID AS INTEGER = 0
--DECLARE @intShirtSizeID AS INTEGER = 2
--DECLARE @intGenderID AS INTEGER = 1
--EXECUTE uspAddGolfer @intGolferID OUTPUT, 'First', 'Last', 'Address', 'City', 'State', 'Zip', 'Phone', 'Email', 3, 1 
--PRINT 'Golfer ID = ' + CONVERT(VARCHAR, @intGolferID) 

GO

CREATE PROCEDURE uspAddEvent
	  @intEventYearID			AS INTEGER OUTPUT
	, @intEventYear				AS INTEGER


AS
SET XACT_ABORT ON -- terminate and rollback if fail


BEGIN TRANSACTION

	SELECT @intEventYearID = MAX(intEventYearID) + 1
	FROM TEventYears

	-- set deafult if empty
	SELECT @intEventYearID = COALESCE(@intEventYearID, 1) 

	--SELECT @intEventYear = MAX(intEventYear) +1
	--FROM TEventYears

	-- set deafult if empty
	SELECT @intEventYear = COALESCE(@intEventYear, 1) 

	INSERT INTO TEventYears(intEventYearID, intEventYear)
	
	Values (@intEventYearID, @intEventYear)

COMMIT TRANSACTION

GO
--DECLARE @intEventYearID AS INTEGER = 0
--DECLARE @intEventYear AS INTEGER = 0
--EXECUTE uspAddEvent @intEventYearID OUTPUT, @intEventYear
--PRINT 'Event ID = ' + CONVERT(VARCHAR, @intEventYearID) 



GO

CREATE PROCEDURE uspAddGolferEvent
	  @intGolferEventYearID		AS INTEGER OUTPUT
	, @intEventYearID			AS INTEGER
	, @intGolferID				AS INTEGER


AS
-- terminate and rollback if fail
SET XACT_ABORT ON 

BEGIN TRANSACTION
	SELECT @intGolferEventYearID = MAX(intGolferEventYearID) + 1
	FROM TGolferEventYears

	SELECT @intGolferID = (intGolferID) 
	FROM TGolfers

	SELECT @intEventYearID = MAX(intEventYearID)
	FROM TEventYears

	INSERT INTO TGolferEventYears WITH (TABLOCKX) (intGolferEventYearID, intGolferID, intEventYearID)
	VALUES( @intGolferEventYearID, @intGolferID, @intEventYearID )



COMMIT TRANSACTION

GO








