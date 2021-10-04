
using Microsoft.AspNetCore.Cors;
using MT_API.Presentation.AuthProvider;
using MT_API.Presentation.Data;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using MTBusinessLogic.Model.DTO;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace MT_API.Presentation.Controllers
{
    [RoutePrefix("api.multitracks.com")]
    [EnableCorsAttribute("*")]
    public class AuthenticationController : ApiController
    {
        public AuthenticationController() : base()
        {

        }

        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }
        [HttpPost]
        [Route("User/SignUp")]
        [AllowAnonymous]
        [ResponseType(typeof(AppUser))]
        public HttpResponseMessage SignUp(SignUpDTO param)
        {
            if (!ModelState.IsValid)
            {
                var errors = JsonConvert.SerializeObject(ModelState.Values.Select(err => err.Errors).ToList());

                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
            Response<AppUser> signUpResult = _userService.SignUp(param);

            if (signUpResult.Success) return Request.CreateResponse(HttpStatusCode.Created, signUpResult);

            return Request.CreateResponse(HttpStatusCode.Created, signUpResult);
        }

        [HttpPost]
        [Route("User/Login")]
        [AllowAnonymous]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage Login(LoginDTO param)
        {
            if (!ModelState.IsValid)
            {
                var errors = JsonConvert.SerializeObject(ModelState.Values.Select(err => err.Errors).ToList());

                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
            var signUpResult = _authenticationService.Login(param);

            if (signUpResult) return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse();
        }


        [BasicAuthentication]
        public HttpResponseMessage Get(string gender = null)
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;

            ApplicationDbContext entities = new ApplicationDbContext();
            switch (userName.ToLower())
            {
                case "male":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        entities.AppUsers.Where(u => u.gender.ToLower() == "male"));
                case "female":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        entities.AppUsers.Where(u => u.gender.ToLower() == "female"));
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
