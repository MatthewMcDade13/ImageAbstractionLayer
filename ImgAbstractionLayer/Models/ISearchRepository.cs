using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Models
{
    public interface ISearchRepository
    {
        IEnumerable<Search> GetAllSearches();

        IEnumerable<Search> GetRecentSearches();

        List<Object> GetRecentSearchesJson();

        void AddSearch(Search search);

        Task<bool> SaveChangesAsync();
    }
}
