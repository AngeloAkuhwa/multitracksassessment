//using Microsoft.Owin;
//using Microsoft.Owin.Cors;
//using Microsoft.Owin.Security.OAuth;
//using MT_API.Presentation.AuthProvider;
//using MT_API.Presentation.Data;
//using Owin;
//using System;
//using System.Web.Http;

//[assembly: OwinStartup(typeof(MT_API.Presentation.App_Start.Startup))]

//namespace MT_API.Presentation.App_Start
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
//            //// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
//            //app.CreatePerOwinContext(ApplicationDbContext.Create);

//            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

//            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

//            //app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

//            app.UseCors(CorsOptions.AllowAll);

//            //var myProvider = new BasicAuthenticationAttribute();
//            //OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
//            //{
//            //    AllowInsecureHttp = true,
//            //    TokenEndpointPath = new PathString("/token"),
//            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
//            //    Provider = myProvider
//            //};
//            app.UseOAuthAuthorizationServer(options);
//            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

//            HttpConfiguration config = new HttpConfiguration();
//            WebApiConfig.Register(config);

//        }
//    }
//}
