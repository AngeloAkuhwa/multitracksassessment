using MTBusinessLogic.Model.DTO;

namespace MTBusinessLogic.Contract
{
    public interface IAuthenticationService
    {

        bool Login(LoginDTO param);

        void LogOut();
    }
}
