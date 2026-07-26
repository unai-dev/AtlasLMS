CREATE OR ALTER VIEW [dbo].[vw_Authors] AS
	SELECT A.*

	--Related
	,B.Title AS [BookTitle]
	,B.ISBN AS [BookISBN]
	,B.ID AS [BookID]

	FROM Authors AS A
	INNER JOIN Books AS B ON A.ID = B.AuthorID
GO

CREATE OR ALTER VIEW [dbo].[vw_Books] AS
	SELECT B.*

	--Related
	,CONCAT(A.FirstName, ' ', A.LastName) AS [AuthorName]

	,C.Name AS [CategoryName]

	,CONCAT(L.Aisle, '-', L.[Column], '-', L.Shelf) AS [CompleteLocation]

	FROM Books AS B
	INNER JOIN Authors AS A ON B.AuthorID = A.ID
	INNER JOIN Categories AS C ON B.CategoryID = C.ID
	LEFT JOIN Locations AS L ON B.LocationID = L.ID
GO

CREATE OR ALTER VIEW [dbo].[vw_Categories] AS
	SELECT C.*

	--Related
	,B.Title AS [BookTitle]
	,B.ISBN AS [BookISBN]

	FROM Categories AS C
	INNER JOIN Books AS B ON C.ID = B.CategoryID
GO

CREATE OR ALTER VIEW [dbo].[vw_Loans] AS
	SELECT L.*

	,U.UserName AS [UserName]
	,U.Email AS [UserEmail]
	,U.CIF AS [UserCIF]

	,B.ISBN AS [BookISBN]
	,B.Title AS [BookTitle]

	FROM Loans AS L
	INNER JOIN AspNetUsers AS U ON L.UserID = U.Id
	INNER JOIN Books AS B ON L.BookID = B.ID
GO
	
CREATE OR ALTER VIEW [dbo].[vwg_Users] AS
	SELECT U.*

	,L.ID AS [LoanID]
	
	,B.ID AS [BookingID]


	FROM  AspNetUsers AS U
	LEFT JOIN Loans AS L ON U.Id = L.UserID
	LEFT JOIN Bookings AS B ON U.Id = B.UserID
GO
	