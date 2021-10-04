using MT_API.Presentation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT_API.Presentation.AuthProvider
{
    public class BasicAuthenticationService
    {
        public static bool Login(string userName, string password)
        {
            ApplicationDbContext entities= new ApplicationDbContext();
            return entities.AppUsers.Any(u => u.userName.Equals(userName, StringComparison.OrdinalIgnoreCase)
            && u.password == password);
        }
    }
}