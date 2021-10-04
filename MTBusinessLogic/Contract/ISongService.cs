using MTBusinessLogic.Model;
using System.Collections.Generic;

namespace MTBusinessLogic.Contract
{
    public interface ISongService
    {
        int TotalNumberOfItems { get; set; }

        int TotalNumberOfPages { get; set; }

        int PageNumber { get; set; }

        int ItemsPerPage { get; set; }

        IReadOnlyList<Song> GetAllAvailableSongs();

        ICollection<T> GetPaginated<T>(int pageNumber, int itemsPerPage, IList<T> items);

        ICollection<Song> PaginateSongs();
    }
}
