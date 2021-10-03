using Microsoft.AspNetCore.Http;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using MTBusinessLogic.Model.DTO;
using System.Threading.Tasks;

namespace MTBusinessLogic.Contract
{
    public interface IUserService
    {
        Response<AppUser> SignUp(SignUpDTO param);
    }
}
