using System;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string church { get; set; }

        public string langauge { get; set; }

        public string country { get; set; }

        public string Address { get; set; }

        public string zip { get; set; }

        public string deateCReation { get; set; } = DateTime.UtcNow.ToString();

        public string dateUpdated { get; set; } = DateTime.UtcNow.ToString();
    }
}
