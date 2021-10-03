using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MT_API.Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IArtistService, ArtistService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<ICloudinaryService, CloudinaryService>();
            container.RegisterType<ISongService, SongService>();
            container.RegisterType<IUserService, UserService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}