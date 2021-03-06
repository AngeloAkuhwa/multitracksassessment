using MTBusinessLogic.Contract;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using MTBusinessLogic.Model.DTO;
using MTBusinessLogic.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MT_API.Presentation.Controllers
{
    [RoutePrefix("api.multitracks.com") ]
    public class MultiTracksController : ApiController
    {
        public MultiTracksController() : base()
        {

        }
       
        private readonly IArtistService _artistService;
        private readonly ISongService _songtService;
        private readonly ICloudinaryService _cloudinaryService;
        public ImageUrlDTO ImagesDTO { get; set; }

        public MultiTracksController(IArtistService artistService, ISongService songtService, ICloudinaryService cloudinaryService)
        {
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));

            _songtService = songtService ?? throw new ArgumentNullException(nameof(songtService));
            _cloudinaryService = cloudinaryService?? throw new ArgumentNullException(nameof(cloudinaryService));
        }

        [HttpPost]
        [Route("artist/search")]
        [AllowAnonymous]
        [ResponseType(typeof(List<Artist>))]
        public HttpResponseMessage SearchArtist(string serachParamsbyTitle)
        {
            if (string.IsNullOrWhiteSpace(serachParamsbyTitle)) { return null; }

            Response<List<ArtistDetailsDTO>> artist =  _artistService.GetArtistByName(serachParamsbyTitle);

            if (artist.Success) return Request.CreateResponse(HttpStatusCode.OK, artist);

            return Request.CreateResponse(HttpStatusCode.BadRequest, artist);
        }


        [HttpPost]
        [Route("song/list")]
        [AllowAnonymous]
        [ResponseType(typeof(ICollection<Song>))]
        public HttpResponseMessage listAllSongs([FromBody] GetAllSongsWithPaginationDTO param)
        {
            if (!ModelState.IsValid)
            {
                var errors = JsonConvert.SerializeObject(ModelState.Values.Select(err => err.Errors).ToList());

                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
            _songtService.PageNumber = param.PageNumber;    
            _songtService.ItemsPerPage = param.ItemsPerPage;

            var songs = _songtService.PaginateSongs();

            return Request.CreateResponse(HttpStatusCode.OK, songs);

        }

        [HttpPost]
        [Route("artist/add")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> PostImage(AddArtistParamsBinder param)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                if (HttpContext.Current.Request.Files.Count < 3 || HttpContext.Current.Request.Files.Count > 3) throw new ApplicationException("all images are required");

                var httpRequest = HttpContext.Current.Request;
                int i = 1;
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        int MaxContentLength = PhotoExtensions.GetPhotoLength();  

                        var AllowedFileExtensions = PhotoExtensions.GetPhotoExtensions();

                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();


                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }

                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }

                        else
                        {
                            var newFileName = "Image_" + Guid.NewGuid().ToString() + postedFile.FileName + extension;
                           
                            List<string> urls = new List<string>();
                            var imageUploadResult = await _cloudinaryService.UploadImageStream(postedFile.InputStream, newFileName);
                            if (i == 1) 
                            {
                                ImagesDTO.artistURL = imageUploadResult.Url.ToString();
                                i++;
                            }
                            else if (i == 2)
                            {
                                ImagesDTO.heroURL = imageUploadResult.Url.ToString();
                                i++;
                            }
                            else ImagesDTO.albumURL = imageUploadResult.Url.ToString();
                        }
                    }

                }

                AddAlbumDTO addAlbumParam = new AddAlbumDTO { title = param.albumTitle, year = param.year};
               
                AddArtistDTO addArtistParam = new AddArtistDTO { biography = param.biography, title = param.artistTitle};
               
                var artist = _artistService.AddArtist(addArtistParam, addAlbumParam, ImagesDTO);

                if(artist.Success)
                {
                    var success = string.Format("Artist Added successfully.");
                    dict.Add("success", success);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }

                var error = string.Format("Please Upload a image.");
                dict.Add("error", error);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("something went wrong",ex);
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
        }
    }
}
