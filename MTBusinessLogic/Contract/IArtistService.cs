using Microsoft.AspNetCore.Http;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using MTBusinessLogic.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTBusinessLogic.Contract
{
    public interface IArtistService
    {
        Task<Response<List<ArtistDetailsDTO>>> GetArtistDetails();

        Response<Artist> AddArtist(AddArtistDTO param, AddAlbumDTO albumParam, ImageUrlDTO imagesDTO);

        Task<List<AddImageResultDTO>> AddImage(List<IFormFile> images);

        Response<List<ArtistDetailsDTO>> GetArtistByName(string search);

        List<ArtistDetailsDTO> GetArtistDetailAsync();
    }
}
