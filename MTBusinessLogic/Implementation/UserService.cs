using DataAccess;
using Microsoft.AspNetCore.Http;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Model;
using MTBusinessLogic.Model.Common;
using MTBusinessLogic.Model.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

       

        public Response<AppUser> SignUp(SignUpDTO param)
        {
            Response <AppUser> response  = new Response<AppUser>();
            if (param is null)
            {
                response.StatusCode = 400;
                response.Success = false;
                return response;
            }
            InstantiateParameters(param);

            var query = "INSERT INTO AppUser (firstName, lastName, church, address, language,zip, country, password)" +
                "VALUES (@param.firsName, @param.lastName, @param.church, @param.address, @param.language, @param.zip, @param.country, @param.password)";

            var insertResultCount = _dataProvider.Execute(query);

            if(insertResultCount > 0)
            {
                response.StatusCode = 200;
                response.Success = true;
                response.Message = "Registration Successful";
                return response;
            }

            throw new ApplicationException("service is unavailable at the moment, our engineers have been informed and are on it already");
        }

        private void InstantiateParameters(SignUpDTO param)
        {
            SqlParameter sqlParamFirstName = new SqlParameter();
            sqlParamFirstName.ParameterName = param.firstName;
            sqlParamFirstName.SqlDbType = SqlDbType.VarChar;
            sqlParamFirstName.Direction = ParameterDirection.Input;


            SqlParameter sqlParamLastName = new SqlParameter();
            sqlParamLastName.ParameterName = param.lastName;
            sqlParamLastName.SqlDbType = SqlDbType.VarChar;
            sqlParamLastName.Direction = ParameterDirection.Input;

            SqlParameter sqlParamChurch = new SqlParameter();
            sqlParamChurch.ParameterName = param.church;
            sqlParamChurch.SqlDbType = SqlDbType.VarChar;
            sqlParamChurch.Direction = ParameterDirection.Input;


            SqlParameter sqlParamAddress = new SqlParameter();
            sqlParamAddress.ParameterName = param.address;
            sqlParamAddress.SqlDbType = SqlDbType.NVarChar;
            sqlParamAddress.Direction = ParameterDirection.Input;

            SqlParameter sqlParamLastLanguage = new SqlParameter();
            sqlParamLastLanguage.ParameterName = param.language;
            sqlParamLastLanguage.SqlDbType = SqlDbType.VarChar;
            sqlParamLastLanguage.Direction = ParameterDirection.Input;

            SqlParameter sqlParamZip = new SqlParameter();
            sqlParamZip.ParameterName = param.zip;
            sqlParamZip.SqlDbType = SqlDbType.VarChar;
            sqlParamZip.Direction = ParameterDirection.Input;


            SqlParameter sqlParamCountry = new SqlParameter();
            sqlParamCountry.ParameterName = param.country;
            sqlParamCountry.SqlDbType = SqlDbType.NVarChar;
            sqlParamCountry.Direction = ParameterDirection.Input;

            SqlParameter sqlParamPassword = new SqlParameter();
            sqlParamCountry.ParameterName = param.password;
            sqlParamCountry.SqlDbType = SqlDbType.NVarChar;
            sqlParamCountry.Direction = ParameterDirection.Input;

            _dataProvider.Parameters.Add(sqlParamFirstName);
            _dataProvider.Parameters.Add(sqlParamLastName);
            _dataProvider.Parameters.Add(sqlParamChurch);
            _dataProvider.Parameters.Add(sqlParamAddress);
            _dataProvider.Parameters.Add(sqlParamLastLanguage);
            _dataProvider.Parameters.Add(sqlParamZip);
            _dataProvider.Parameters.Add(sqlParamCountry);
            _dataProvider.Parameters.Add(sqlParamPassword);
        }
    }
}
