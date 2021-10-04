using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace MT_API.Presentation.Model
{
    public class AppUser
    {
        
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string gender { get; set; }
        public string church { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }

        public string langauge { get; set; }

        public string country { get; set; }

        public string Address { get; set; }

        public int zip { get; set; }
        public string password { get; set; }

        public DateTime deteCreation { get; set; }

        public DateTime dateUpdated { get; set; } 
    }
}