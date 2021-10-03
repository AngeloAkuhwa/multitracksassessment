namespace MTBusinessLogic.Model.DTO
{
    public class ArtistDetailsDTO
    {
        public int artistID { get; set; }

        public string artistName { get; set; }

        public string biography { get; set; }

        public string artistImageURL { get; set; }

        public int albumID { get; set; }

        public string albumTitle { get; set; }

        public string albumImageURL { get; set; }

        public int songID { get; set; }

        public string songTitle { get; set; }

        public decimal songBpm { get; set; }

        public string songTimeSignature { get; set; }
    }
}
