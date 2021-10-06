using DataAccess;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Model.DTO;
using System.Data;
using System.Data.SqlClient;

namespace MTBusinessLogic.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SQL _dataProvider;
        public AuthenticationService()
        {
            _dataProvider = new SQL("admin");
            _dataProvider.OpenConnection();
        }
        public bool Login(LoginDTO param)
        {

            InstantiateParamters(param);

            var query = "SELECT email, password, FROM dbo.AppUser WHERE email = @email AND password = @passWord";

            var resultCount =  _dataProvider.Execute(query);

            return resultCount > 0;
        }

        private void InstantiateParamters(LoginDTO param)
        {
            SqlParameter sqlParamEmail = new SqlParameter
            {
                ParameterName = "email",
                SqlDbType = SqlDbType.VarChar,
                Value = param.email
            };


            SqlParameter sqlParamPassword = new SqlParameter
            {
                ParameterName = "password",
                SqlDbType = SqlDbType.VarChar,
                Value = param.password
            };

            _dataProvider.Parameters.Add(sqlParamEmail);
            _dataProvider.Parameters.Add(sqlParamPassword);
        }
    }
}
