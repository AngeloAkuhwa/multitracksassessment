//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;

//namespace MT_API.Presentation.App_Start
//{
//    public class ApplicationRoleManager : RoleManager<IdentityRole>
//    {
//        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
//            : base(roleStore)
//        {

//        }
//        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
//        {
//            var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));



//            return appRoleManager;
//        }
//    }
//}