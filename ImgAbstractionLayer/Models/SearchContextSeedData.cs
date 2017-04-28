using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Models
{
    public class SearchContextSeedData
    {
        private ISearchRepository repo;

        public SearchContextSeedData(ISearchRepository repo)
        {
            this.repo = repo;
        }

        public async Task EnsureSeedData()
        {
            if (repo.GetAllSearches().Any() == false)
            {
                Search lolCatsSearch = new Search
                {
                    SearchTime = new DateTime(2017, 1, 25, 12, 30, 56),
                    SearchTerm = "lolcats funny"
                };

                repo.AddSearch(lolCatsSearch);

                Search grumpyCatsSearch = new Search
                {
                    SearchTime = new DateTime(2017, 2, 18, 8, 24, 41),
                    SearchTerm = "grumpycats"
                };

                repo.AddSearch(grumpyCatsSearch);

                Search memeSearch = new Search
                {
                    SearchTime = new DateTime(2017, 3, 8, 13, 54, 8),
                    SearchTerm = "funny memes"
                };

                repo.AddSearch(memeSearch);

                await repo.SaveChangesAsync();
            }
        }
    }
}
