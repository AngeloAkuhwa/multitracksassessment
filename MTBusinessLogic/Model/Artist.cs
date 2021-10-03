using System;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model
{
    public class Artist
    {
        [Key]
        public int artistID { get; set; }

        public DateTime dateCreation { get; set; }

        public string biography { get; set; }

        public string title { get; set; }

        public string imageURL { get; set; }

        public string heroURL { get; set; }

        public virtual Album album { get; set; } = null;
    }
}
