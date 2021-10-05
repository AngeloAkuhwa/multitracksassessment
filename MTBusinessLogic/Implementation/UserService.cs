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
            SqlParameter sqlParamFirstName = new SqlParameter();
            sqlParamFirstName.ParameterName = "firstName";
            sqlParamFirstName.SqlDbType = SqlDbType.VarChar;
            sqlParamFirstName.Direction = ParameterDirection.Input;
            sqlParamFirstName.Value = param.firstName;


            SqlParameter sqlParamLastName = new SqlParameter();
            sqlParamLastName.ParameterName = "lastName";
            sqlParamLastName.SqlDbType = SqlDbType.VarChar;
            sqlParamLastName.Direction = ParameterDirection.Input;
            sqlParamLastName.Value = param.lastName;

            SqlParameter sqlParamChurch = new SqlParameter();
            sqlParamChurch.ParameterName = "church";
            sqlParamChurch.SqlDbType = SqlDbType.VarChar;
            sqlParamChurch.Direction = ParameterDirection.Input;
            sqlParamChurch.Value = param.church;


            SqlParameter sqlParamAddress = new SqlParameter();
            sqlParamAddress.ParameterName = "address";
            sqlParamAddress.SqlDbType = SqlDbType.NVarChar;
            sqlParamAddress.Direction = ParameterDirection.Input;
            sqlParamAddress.Value = param.address;

            SqlParameter sqlParamLastLanguage = new SqlParameter();
            sqlParamLastLanguage.ParameterName = "language";
            sqlParamLastLanguage.SqlDbType = SqlDbType.VarChar;
            sqlParamLastLanguage.Direction = ParameterDirection.Input;
            sqlParamLastLanguage.Value = param.language;

            SqlParameter sqlParamZip = new SqlParameter();
            sqlParamZip.ParameterName = "zip";
            sqlParamZip.SqlDbType = SqlDbType.Int;
            sqlParamZip.Direction = ParameterDirection.Input;
            sqlParamZip.Value = param.zip;


            SqlParameter sqlParamCountry = new SqlParameter();
            sqlParamCountry.ParameterName = "country";
            sqlParamCountry.SqlDbType = SqlDbType.VarChar;
            sqlParamCountry.Direction = ParameterDirection.Input;
            sqlParamCountry.Value = param.country;

            SqlParameter sqlParamPassword = new SqlParameter();
            sqlParamPassword.ParameterName = "password";
            sqlParamPassword.SqlDbType = SqlDbType.VarChar;
            sqlParamPassword.Direction = ParameterDirection.Input;
            sqlParamPassword.Value = param.password;

            SqlParameter sqlParamEmail = new SqlParameter();
            sqlParamEmail.ParameterName = "email";
            sqlParamEmail.SqlDbType = SqlDbType.VarChar;
            sqlParamEmail.Direction = ParameterDirection.Input;
            sqlParamEmail.Value = param.email;

            SqlParameter sqlParamDateCreation = new SqlParameter();
            sqlParamDateCreation.ParameterName = "dateCreation";
            sqlParamDateCreation.SqlDbType = SqlDbType.VarChar;
            sqlParamDateCreation.Direction = ParameterDirection.Input;
            sqlParamDateCreation.Value = param.dateCreation;

            SqlParameter sqlParamDateUpdated = new SqlParameter();
            sqlParamDateUpdated.ParameterName = "dateUpdated";
            sqlParamDateUpdated.SqlDbType = SqlDbType.VarChar;
            sqlParamDateUpdated.Direction = ParameterDirection.Input;
            sqlParamDateUpdated.Value = param.dateUpdated;

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
