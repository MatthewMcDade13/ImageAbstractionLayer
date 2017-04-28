using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// Iterates through database and returns an IEnumerable of the last 
        /// 10 Searches.
        /// </summary>
        /// <returns>last 10 entries in Database</returns>
        public IEnumerable<Search> GetRecentSearches()

        {
            List<Search> recentSearches = new List<Search>();
            Search[] allSearches = GetAllSearches().ToArray();

            //Loops through Searches in database backwards to get the most recent searches.
            //Loop condition is based on size of allSearches variable to eliminate possible index
            //out of range exceptions in case the database contains less than 10 items
            for (int i = allSearches.Length - 1,
                count = 1; i >= 0; i--, count++)
            {
                //We only want the last 10 searches. So if we have
                //iterated though this loop 10 times, break;
                if (count >= 10)
                {
                    break;
                }

                recentSearches.Add(allSearches[i]);
            }

            return recentSearches;
        }

        /// <summary>
        /// Gets Recent searches and returns a List of anoymous objects to be used for JSON responses
        /// </summary>
        /// <returns></returns>
        public List<Object> GetRecentSearchesJson()
        {
            Search[] recentSearches = GetRecentSearches().ToArray();
            List<Object> json = new List<Object>();

            for (int i = 0; i < recentSearches.Length; i++)
            {
                json.Add(new
                {
                    Term = recentSearches[i].SearchTerm,
                    When = recentSearches[i].SearchTime
                });
            }

            return json;
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
