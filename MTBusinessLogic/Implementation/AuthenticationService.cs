using DataAccess;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Model.DTO;
using System;
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

            var query = "SELECT COUNT(*) FROM dbo.AppUser WHERE userName = @param.userName AND password = @param.passWord";

            int resultCount =  _dataProvider.Execute(query,true);

           if(resultCount > 0)
           {
                return true;
           }
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        private void InstantiateParamters(LoginDTO param)
        {
            SqlParameter sqlParamEmail = new SqlParameter();
            sqlParamEmail.ParameterName = param.email;
            sqlParamEmail.SqlDbType = SqlDbType.VarChar;
            sqlParamEmail.Direction = ParameterDirection.Output;


            SqlParameter sqlParamPassword = new SqlParameter();
            sqlParamPassword.ParameterName = param.email;
            sqlParamPassword.SqlDbType = SqlDbType.VarChar;
            sqlParamPassword.Direction = ParameterDirection.Output;

            _dataProvider.Parameters.Add(sqlParamPassword);
            _dataProvider.Parameters.Add(sqlParamPassword);
        }
    }
}
