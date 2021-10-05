using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using MTBusinessLogic.Model.DTO;
using System;
using System.Collections.Generic;

public partial class artistDetails : System.Web.UI.Page
{
    public List<artistDetailsModel> ArtistDetailsModels = new List<artistDetailsModel>(); 
    public List<artistDetailsModel> ExpectedDetails {  get; set; }
    public int PageNumber = 1;
    public double itemsPerPage = 10;

    private ISongService _songService;
    public ISongService SongService
    {
        get { return _songService == null ? new SongService() : _songService; }
        set { _songService = value; }
    }

    private ICloudinaryService _cloudinaryService;
    public ICloudinaryService CloudinaryService
    {
        get { return _cloudinaryService == null ? new CloudinaryService() : _cloudinaryService;}
        set {  _cloudinaryService = value; }
    }

    private  IArtistService _artistService;
    public IArtistService ArtistService
    {
        get { return this._artistService == null? new ArtistService(CloudinaryService) : _artistService; }
        set {  this._artistService = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
    }

    public ICollection<ArtistDetailsDTO> GetArtistDetails()
    {
        List<ArtistDetailsDTO> artistDetails = ArtistService.GetArtistDetailInternal();
        var itemsPerPage = 10;

        foreach (var item in artistDetails)
        {
            ArtistDetailsModels.Add(new artistDetailsModel
            {
                artistID = item.artistID,
                artistName = item.artistName,
                biography = item.biography,
                artistImageURL = item.artistImageURL,
                albumID = item.albumID,
                albumTitle = item.albumTitle,
                albumImageURL = item.albumImageURL,
                songID = item.songID,
                songTitle = item.songTitle,
                songBpm = item.songBpm,
                songTimeSignature = item.songTimeSignature
            });
        }

        ExpectedDetails = ArtistDetailsModels;
        var result = SongService.GetPaginated<ArtistDetailsDTO>(PageNumber, itemsPerPage, artistDetails);
        return result;
    }

    public int ArtistDetailsPageCount()
    {
        double itemsPerPage = 15;
       var TotalNumberOfPages = (int)Math.Ceiling(GetArtistDetails().Count / itemsPerPage);

        return TotalNumberOfPages;

    }
}
public class artistDetailsModel
{

    public int artistID { get; set; }

    public string artistName { get; set; }

    public string biography { get; set; }

    public string artistImageURL { get; set; }

    public int albumID { get; set; }

    public string albumTitle { get; set; }

    public string albumImageURL { get; set; }

    public int songID { get; set; }

    public string songTitle { get; set; }

    public decimal songBpm { get; set; }

    public string songTimeSignature { get; set; }
}