using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Models
{
    public interface ISearchRepository
    {
        IEnumerable<Search> GetAllSearches();

        void AddSearch(Search search);

        Task<bool> SaveChangesAsync();
    }
}
