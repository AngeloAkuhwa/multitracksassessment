using System;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model
{
    public class Song
    {
        [Key]
        public int songID { get; set; }

        public DateTime dateCreation { get; set; }

        public int albumID { get; set; }

        public int artistID { get; set; }

        public string title { get; set; }

        public decimal bpm { get; set; }

        public string timeSignature { get; set; }

        public bool multitracks { get; set; }

        public bool customix { get; set; }

        public bool chart { get; set; }

        public bool rehearsalMix { get; set; }

        public bool patches { get; set; }

        public bool songSpecialPatches { get; set; }

        public bool proPresenter { get; set; }
    }
}
