using CloudinaryDotNet.Actions;
using DataAccess;
using Microsoft.AspNetCore.Http;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Mapper;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using MTBusinessLogic.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MTBusinessLogic.Implementation
{
    public class ArtistService : IArtistService
    {
        private readonly SQL _dataProvider;
        private readonly ICloudinaryService _cloudinaryService;

        public ArtistService(ICloudinaryService cloudinaryService)
        {
            _dataProvider = new SQL("admin");
            _dataProvider.OpenConnection();

            _cloudinaryService = cloudinaryService ?? throw new ArgumentNullException(nameof(cloudinaryService));
        }

        private List<string> listOfUpLoadedImagePublicIds = new List<string>();
       
        public Response<Artist> AddArtist(AddArtistDTO artistParam, AddAlbumDTO albumParam, ImageUrlDTO imagesURL)
        {
            #region map DTO to actual table schemas
            var artistToInsert = AutoMap.Mapper.Map<Artist>(artistParam);

            var albumToInsert = AutoMap.Mapper.Map<Album>(albumParam);

            #endregion


            #region update artist and album params

            artistToInsert.imageURL = imagesURL.artistURL;

            artistToInsert.heroURL = imagesURL.heroURL;

            albumToInsert.imageURL = imagesURL.albumURL;

            #endregion

            #region SQL transcation operations

            var dateCreation = artistToInsert.dateCreation;
            var biography = artistToInsert.biography;
            var tilte = artistToInsert.title;
            var imageURL = artistToInsert.imageURL;
            var heroURL = artistToInsert.heroURL;

            var DateCreation = albumToInsert.dateCreation;
            var ArtistID = albumToInsert.artistID;
            var Title = albumToInsert.title;
            var ImageURL = albumToInsert.imageURL;  
            var Year = albumToInsert.year;  

            //var queryInsertArtist = "INSERT INTO dbo.Artist (dateCreation, biography, title, imageURL, heroURL)" +
            //    " VALUES (@dateCreation, @biography, @title, @imageURL, @heroURL);";

            //var queryInsertAlbum = "INSERT INTO dbo.Album (dateCreation, artistID, title, imageURL, year)" +
            //    "VALUES (@DateCreation, @ArtistID, @Title, @ImageURL,  @Year);";

            _dataProvider.BeginTransaction();

            var artistReader = _dataProvider.ExecuteStoredProcedureDataReader("addArtist", true);

            SqlDataReader albumReader = default;

            Artist artist = default;

            while (artistReader.Read())
            {
                //update album artistId Param
                albumToInsert.artistID = (int)artistReader[0];

                albumReader=  _dataProvider.ExecuteStoredProcedureDataReader("addAlbum", true);

                Album albumToReturn = new Album 
                {
                    albumID = (int)albumReader[0],  
                    dateCreation = (DateTime)albumReader[1],
                    artistID = (int)albumReader[2],
                    title = (string)albumReader[3],
                    imageURL = (string)albumReader[4],
                    year = (int)albumReader[5]
                };

                artist = new Artist
                {
                    artistID = (int)artistReader[0],
                   dateCreation = (DateTime)artistReader[1], 
                   biography = (string)artistReader[2],
                   title = (string)artistReader[3],
                   imageURL = (string)artistReader[4],
                   heroURL = (string)artistReader[5],
                   album = albumToReturn
                };
            }
            _dataProvider.Commit();

            #endregion

            _dataProvider.CloseConnection();

            return new Response<Artist>
            {
                StatusCode = 200,
                Success = true,
                Message = "transaction completed successful",
                Data = artist,
            };
        }

        public async Task<List<AddImageResultDTO>> AddImage(List<IFormFile> images)
        {
            List<string> listOfUploadedImagesPublicIds = new List<string>();
            List<AddImageResultDTO> response = new List<AddImageResultDTO>();

            UploadResult imageUpLoadeResult = null;
            if (images is null) throw new ApplicationException("select an image");
            foreach (IFormFile image in images)
            {
                 imageUpLoadeResult = await _cloudinaryService.UploadImage(image);

                if (imageUpLoadeResult.Error is null && imageUpLoadeResult.Url != null)
                {
                    listOfUpLoadedImagePublicIds.Add(imageUpLoadeResult.PublicId);
                }
                if (imageUpLoadeResult.Error != null)
                {
                    foreach (string imageId in listOfUploadedImagesPublicIds)
                    {
                       await _cloudinaryService.DeleteImage(imageId);
                    }
                    throw new ApplicationException("something went wring and our engineers are already moved to resolving it");
                }


                response.Add(new AddImageResultDTO { imageURL = imageUpLoadeResult.Url.ToString(), publicId = imageUpLoadeResult.PublicId });
            }

            listOfUploadedImagesPublicIds.Clear();

            return response;
        }

        public async Task<Response<List<ArtistDetailsDTO>>> GetArtistDetails()
        {
            SqlDataReader resultReader = _dataProvider.ExecuteStoredProcedureDataReader("GetArtistDetails", true);
            List<ArtistDetailsDTO> artistGroup = new List<ArtistDetailsDTO>();
            
            while(await resultReader.ReadAsync())
            {
                artistGroup.Add(new ArtistDetailsDTO
                {
                    artistID = (int)resultReader[0],
                    artistName = (string)resultReader[1],
                    biography = (string)resultReader[2],
                    artistImageURL = (string)resultReader[3],
                    albumID = (int)resultReader[4],
                    albumTitle = (string)resultReader[5],
                    albumImageURL = (string)resultReader[6],
                    songID = (int)resultReader[7],  
                    songTitle = (string)resultReader[8],
                    songBpm = (decimal)resultReader[9],
                    songTimeSignature = (string)resultReader[10],
                });
            }


            _dataProvider.CloseConnection();

            return new Response<List<ArtistDetailsDTO>>()
            {
                Data = artistGroup,
                Success= true,
                StatusCode = 200,
                Message = "Retrieved successfully",
            };
            
        }


        public List<ArtistDetailsDTO> GetArtistDetailAsync()
        {
            SqlDataReader resultReader = _dataProvider.ExecuteStoredProcedureDataReader("GetArtistDetails", true);
            List<ArtistDetailsDTO> artistGroup = new List<ArtistDetailsDTO>();

            while (resultReader.Read())
            {
                artistGroup.Add(new ArtistDetailsDTO
                {
                    artistID = (int)resultReader[0],
                    artistName = (string)resultReader[1],
                    biography = (string)resultReader[2],
                    artistImageURL = (string)resultReader[3],
                    albumID = (int)resultReader[4],
                    albumTitle = (string)resultReader[5],
                    albumImageURL = (string)resultReader[6],
                    songID = (int)resultReader[7],
                    songTitle = (string)resultReader[8],
                    songBpm = (decimal)resultReader[9],
                    songTimeSignature = (string)resultReader[10],
                });
            }

            _dataProvider.CloseConnection();

            return artistGroup;

        }




        public Response<List<ArtistDetailsDTO>> GetArtistByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;

            _dataProvider.Parameters.Add(new SqlParameter { ParameterName = "Name", Value = name });
            var resultReader = _dataProvider.ExecuteStoredProcedureDataReader("serachArtistbyName");
            List<ArtistDetailsDTO> artist = new List<ArtistDetailsDTO>();

            while (resultReader.Read())
            {
                artist.Add(new ArtistDetailsDTO
                {
                    artistID = (int)resultReader[0],
                    artistName = (string)resultReader[1],
                    biography = (string)resultReader[2],
                    artistImageURL = (string)resultReader[3],
                    albumID = (int)resultReader[4],
                    albumTitle = (string)resultReader[5],
                    albumImageURL = (string)resultReader[6],
                    songID = (int)resultReader[7],
                    songTitle = (string)resultReader[8],
                    songBpm = (decimal)resultReader[9],
                    songTimeSignature = (string)resultReader[10],
                });
                
            }

            return new Response<List<ArtistDetailsDTO>>()
            {
                Success = true,
                StatusCode = 200,
                Data = artist,
                Message = "Retrievd succesfully"
            };
        }
    }
}
