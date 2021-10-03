﻿using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using MTBusinessLogic.Model.DTO;
using System;
using System.Collections.Generic;

public partial class artistDetails : System.Web.UI.Page
{
    public List<artistDetailsModel> ArtistDetailsModels = new List<artistDetailsModel>(); 
    public List<artistDetailsModel> ExpectedDetails {  get; set; } 


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
         
    }

    public List<ArtistDetailsDTO> GetArtistDetails()
    {
        List<ArtistDetailsDTO> artistDetails = ArtistService.GetArtistDetailAsync();

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

        return artistDetails;   
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