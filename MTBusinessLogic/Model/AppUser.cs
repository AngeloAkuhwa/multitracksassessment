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

        public int zip { get; set; }

        public DateTime deateCreation { get; set; } = DateTime.UtcNow;

        public DateTime dateUpdated { get; set; } = DateTime.UtcNow;
    }
}
