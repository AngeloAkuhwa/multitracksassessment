CREATE PROCEDURE [dbo].[addAlbum]
(
	@DateCreation DateTime,
	@ArtistID INTEGER,
	@Title Varchar,
	@ImageURL Varchar,
	@Year INTEGER
)
AS 
BEGIN

   INSERT INTO dbo.Album (dateCreation, artistID, title, imageURL, year)
   VALUES (@DateCreation, @ArtistID, @Title, @ImageURL,  @Year);

END
