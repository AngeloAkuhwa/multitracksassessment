CREATE PROCEDURE [dbo].[GetArtistDetails]
	AS 
BEGIN

    SELECT dbo.Artist.artistID, dbo.Artist.title as artistName, dbo.Artist.biography, dbo.Artist.imageURL, dbo.Album.albumID,dbo.Album.title as albumTitle, dbo.Album.imageURL, dbo.Song.songID, dbo.Song.title as songTitle, dbo.Song.bpm, dbo.Song.timeSignature
	FROM dbo.Artist
	INNER JOIN dbo.Album ON dbo.Artist.artistID = dbo.Album.artistID
	INNER JOIN dbo.Song ON dbo.Artist.artistID = dbo.Song.artistID;

END
