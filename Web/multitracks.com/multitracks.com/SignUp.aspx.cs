using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using MTBusinessLogic.Model;
using MTBusinessLogic.Utils;
using System;
using System.Threading;

public partial class Pages_SignUp : System.Web.UI.Page
{
    private IUserService _userservice;
    public IUserService UserService
    {
        get { return _userservice ?? new UserService(); }
        set { _userservice = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == HTTPMethods.POST.ToString())
        {
            int number;
            bool isParsable = Int32.TryParse(zip.Value, out number);

            if (!isParsable && string.IsNullOrWhiteSpace(firstname.Value)
                || string.IsNullOrWhiteSpace(lastname.Value) || string.IsNullOrWhiteSpace(church.Value)
                || string.IsNullOrWhiteSpace(country.Value) || string.IsNullOrWhiteSpace(address.Value)
                || string.IsNullOrWhiteSpace(password.Value) || string.IsNullOrWhiteSpace(email.Value))
            {
                throw new ApplicationException("Invalid entry values");
            }
            AppUser model = new AppUser
            {
                firstName = firstname.Value,
                lastName = lastname.Value,
                church = church.Value,
                language = church.Value,
                country = country.Value,
                address = address.Value,
                password = password.Value,
                email = email.Value,
                zip =number
            };

            var signUpresult = UserService.SignUp(model);
            if (signUpresult.Success)
            {
                Response.Redirect(RouteNavigator.GetRout(Route.login.ToString()));
            }
            else if(!signUpresult.Success && signUpresult.Message.Equals("Registration failed, User already exist"))
            {
                Response.Redirect(RouteNavigator.GetRout(Route.login.ToString()));
            }
            else
            {
                Response.Write(
                    "<script language='javascript'>"
                    +

                    "window.alert('Registration Successful');"
                    +
                    "</script>;");

                Thread.Sleep(7000);

                Response.Redirect(RouteNavigator.GetRout(Route.SignUp.ToString()));
            }
        }
    }
}