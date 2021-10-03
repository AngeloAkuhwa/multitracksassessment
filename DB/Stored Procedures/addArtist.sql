CREATE PROCEDURE [dbo].[addArtist]
(
	@dateCreation DateTime,
	@biography Varchar,
	@title Varchar,
	@imageURL Varchar,
	@heroURL Varchar
)
AS 
BEGIN

   INSERT INTO dbo.Artist (dateCreation, biography, title, imageURL, heroURL)
   VALUES (@dateCreation, @biography, @title, @imageURL, @heroURL);

END
