using DataAccess;
using MTBusinessLogic.Contract;
using MTBusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTBusinessLogic.Implementation
{
    public class SongService : ISongService
    {
        public int TotalNumberOfItems { get; set; }

        public int TotalNumberOfPages { get; set; }

        public int PageNumber { get; set; }

        public int ItemsPerPage { get; set; }

        private readonly SQL _dataProvider;

        public SongService()
        {
            _dataProvider = new SQL("admin");
            _dataProvider.OpenConnection();
        }

        public IReadOnlyList<Song> GetAllAvailableSongs()
        {
            IReadOnlyList <Song> songsToFetch = new List<Song>(); 

           // string query = "SELECT * FROM dbo.Song;";

            var reader = _dataProvider.ExecuteStoredProcedureDataReader("getAllSongs", true);
           
            List<Song> songs = null;
            while (reader.Read())
            {
                Song availableSongs = new Song
                {
                    songID = (int)reader[0],
                    dateCreation = (DateTime)reader[1],
                    albumID = (int)reader[2],
                    artistID = (int)reader[3],  
                    title = (string)reader[4],
                    bpm = (decimal)reader[5],
                    timeSignature = (string)reader[6],
                    multitracks = (bool)reader[7],
                    customix = (bool)reader[8], 
                    chart = (bool)reader[9],
                    rehearsalMix = (bool)reader[10],
                    patches = (bool)reader[11],
                    songSpecialPatches = (bool)reader[12],
                    proPresenter = (bool)reader[13]
                };
              songs = new List<Song>();

              songs.Add(availableSongs);

            }

            songsToFetch = songs;

            return songsToFetch;


        }

        public ICollection<T> GetPaginated<T>(int pageNumber, int itemsPerPage, IList<T> items)
        {
            TotalNumberOfItems = items.Count();

            TotalNumberOfPages = (int)Math.Ceiling(TotalNumberOfItems / (double)itemsPerPage);

            if (pageNumber > TotalNumberOfPages || pageNumber < 1)
            {
                return null;
            }
            var pagedItems = items.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return pagedItems;
        }

        public ICollection<Song> PaginateSongs()
        {
            var availableSongs = GetAllAvailableSongs();
            var paginatedSongs = GetPaginated(PageNumber, ItemsPerPage, availableSongs.ToList());

            return paginatedSongs;
        }
    }
}
