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
        Response<List<ArtistDetailsDTO>> GetArtistByName(string search);
        List<ArtistDetailsDTO> GetArtistDetailInternal();
    }
}
