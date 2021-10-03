using System;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model
{
    public class Album
    {
        [Key]
        public int albumID { get; set; }

        public DateTime dateCreation { get; set; }

        public int artistID { get; set; }

        public string title { get; set; }

        public string imageURL { get; set; }

        public int year { get; set; }
    }
}
