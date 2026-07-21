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
