using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using MTBusinessLogic.Model;
using MTBusinessLogic.Utils;
using System;

public partial class Pages_SignUp : System.Web.UI.Page
{
    private IUserService _userservice;
    public IUserService UserService
    {
        get { return _userservice == null ? new UserService() : _userservice; }
        set { _userservice = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == HTTPMethods.POST.ToString())
        {
            AppUser model = new AppUser();
            model.firstName =firstname.Value;
            model.lastName = lastname.Value;
            model.church = church.Value; ;
            model.language = church.Value;
            model.country = country.Value;
            model.address = address.Value;
            model.password = password.Value;
            model.email = email.Value;  
            int number;
            bool isParsable = Int32.TryParse(zip.Value, out number);
            model.zip = number;

            var signUpresult = UserService.SignUp(model);
            if (signUpresult.Success)
            {
                Response.Redirect(RouteNavigator.GetRout(Route.login.ToString()));
            }
            else
            {
                Response.Redirect(RouteNavigator.GetRout(Route.SignUp.ToString()));
            }
        }
    }
}