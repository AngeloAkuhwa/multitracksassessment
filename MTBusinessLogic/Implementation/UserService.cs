using DataAccess;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MTBusinessLogic.Implementation
{

    public class UserService : IUserService
    {
        private readonly SQL _dataProvider;
        public UserService()
        {
            _dataProvider = new SQL("admin");
            _dataProvider.OpenConnection();
        }



        public Response<AppUser> SignUp(AppUser param)
        {
            Response<AppUser> response = new Response<AppUser>();
            if (param is null)
            {
                response.StatusCode = 400;
                response.Success = false;
                return response;
            }

            _dataProvider.Parameters.Clear();

            InstantiateParameters(param);

            var userExist = "SELECT email,FROM dbo.AppUser WHERE email = @email";
            var userExistResult = _dataProvider.Execute(userExist);
            if (userExistResult > 0)
            {
                response.StatusCode = 200;
                response.Success = false;
                response.Message = "Registration failed, User already exist";
                return response;
            }

            var query = "INSERT INTO AppUser (firstName,lastName,church,language,country,address,zip,password,email,dateCreation,dateUpdated)" +
                "VALUES (@firstName,@lastName,@church,@language,@country,@address,@zip,@password,@email,@dateCreation,@dateUpdated)";

            var insertResultCount = _dataProvider.Execute(query, true);

            
            if (insertResultCount > 0)
            {
                response.StatusCode = 200;
                response.Success = true;
                response.Message = "Registration Successful";
                return response;
            }

            throw new ApplicationException("service is unavailable at the moment, our engineers have been informed and are on it already");
        }

        private void InstantiateParameters(AppUser param)
        {
            SqlParameter sqlParamFirstName = new SqlParameter
            {
                ParameterName = "firstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.firstName
            };


            SqlParameter sqlParamLastName = new SqlParameter
            {
                ParameterName = "lastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.lastName
            };

            SqlParameter sqlParamChurch = new SqlParameter
            {
                ParameterName = "church",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.church
            };


            SqlParameter sqlParamAddress = new SqlParameter
            {
                ParameterName = "address",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = param.address
            };

            SqlParameter sqlParamLastLanguage = new SqlParameter
            {
                ParameterName = "language",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.language
            };

            SqlParameter sqlParamZip = new SqlParameter
            {
                ParameterName = "zip",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = param.zip
            };


            SqlParameter sqlParamCountry = new SqlParameter
            {
                ParameterName = "country",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.country
            };

            SqlParameter sqlParamPassword = new SqlParameter
            {
                ParameterName = "password",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.password
            };

            SqlParameter sqlParamEmail = new SqlParameter
            {
                ParameterName = "email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.email
            };

            SqlParameter sqlParamDateCreation = new SqlParameter
            {
                ParameterName = "dateCreation",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.dateCreation
            };

            SqlParameter sqlParamDateUpdated = new SqlParameter
            {
                ParameterName = "dateUpdated",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = param.dateUpdated
            };

            _dataProvider.Parameters.Add(sqlParamFirstName);
            _dataProvider.Parameters.Add(sqlParamLastName);
            _dataProvider.Parameters.Add(sqlParamChurch);
            _dataProvider.Parameters.Add(sqlParamAddress);
            _dataProvider.Parameters.Add(sqlParamLastLanguage);
            _dataProvider.Parameters.Add(sqlParamZip);
            _dataProvider.Parameters.Add(sqlParamCountry);
            _dataProvider.Parameters.Add(sqlParamPassword);
            _dataProvider.Parameters.Add(sqlParamEmail);
            _dataProvider.Parameters.Add(sqlParamDateCreation);
            _dataProvider.Parameters.Add(sqlParamDateUpdated);


        }
    }
}
