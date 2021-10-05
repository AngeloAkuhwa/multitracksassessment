using System;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string email { get; set; }

        public string lastName { get; set; }

        public string church { get; set; }

        public string language { get; set; }

        public string country { get; set; }

        public string address { get; set; }

        public string password { get; set; }

        public int zip { get; set; }

        public DateTime dateCreation { get; set; } = DateTime.UtcNow;

        public DateTime dateUpdated { get; set; } = DateTime.UtcNow;
    }
}
