using AutoMapper;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.DTO;

namespace MTBusinessLogic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, SignUpDTO>().ReverseMap();
            CreateMap<Artist, AddArtistDTO>().ReverseMap();
            CreateMap<Album, AddAlbumDTO>().ReverseMap();
        }
    }
}
