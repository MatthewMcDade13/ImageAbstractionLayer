using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Models
{
    public class SearchRepository : ISearchRepository
    {
        SearchContext context;

        public SearchRepository(SearchContext context)
        {
            this.context = context;
        }

        public IEnumerable<Search> GetAllSearches()
        {
            return context.Searches.ToList();
        }

        public void AddSearch(Search search)
        {
            context.Add(search);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
