using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using MTBusinessLogic.Model.DTO;
using MTBusinessLogic.Utils;
using System;
using System.Threading.Tasks;
using System.Web.UI;

public partial class Pages_login : Page
{
    public bool LoginResult { get; set; }
    private IAuthenticationService _authentication;
    public IAuthenticationService Authentication
    {
        get { return _authentication == null ? new AuthenticationService() : _authentication; }
        set { _authentication = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       if(Request.HttpMethod == HTTPMethods.POST.ToString())
        {
            LoginDTO model = new LoginDTO();

            model.email = email.Value;
            model.password = password.Value;

            LoginResult = Authentication.Login(model);
            if (LoginResult)
            {
                Response.Redirect("/artistDetails.aspx");
                return;
            }
           
        }
    }
}