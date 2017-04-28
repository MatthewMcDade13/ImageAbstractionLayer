using ImgAbstractionLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ImgAbstractionLayer.Services;

namespace ImgAbstractionLayer.Controllers
{
    [Route("api/imagesearch")]
    public class SearchController : Controller
    {
        private ISearchRepository repo;
        private IApiParser parser;

        public SearchController(ISearchRepository repo, IApiParser parser)
        {
            this.parser = parser;
            this.repo = repo;
        }

        [HttpGet("{term:alpha}")]
        public async Task<IActionResult> SearchImages(string term)
        {
            await AddSearchToDb(term);
            int offset = 0;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "dcd10e0a6efe49ab9fe4f5e1ddd459a5");
               
                try
                {
                    offset = int.Parse(Request.Query["offset"].ToString());
                }
                catch (FormatException)
                {
                    //Use value assigned at initilization
                }

                using (HttpResponseMessage response =
                    await client.GetAsync($"https://api.cognitive.microsoft.com/bing/v5.0/images/search?q={term}&offset={offset}"))
                {
                    response.EnsureSuccessStatusCode();

                    string jsonString = await response.Content.ReadAsStringAsync();

                    dynamic json = JsonConvert.DeserializeObject(jsonString);

                    json = parser.ParseApi(json);

                    return Json(json);
                }
            }
        }

        [HttpGet("test/{test:alpha}")]
        public IActionResult Test(string test)
        {
            string query = Request.QueryString.ToString();
            

            return Json(new { Query = query, TestString = test , Param = Request.Query["a"].ToString() });
        }

        //GET api/imagesearch/recent
        [HttpGet("recent")]
        public IActionResult GetRecentSearches()
        {
            return Json(repo.GetRecentSearchesJson());
        }

        private async Task AddSearchToDb(string term)
        {
            repo.AddSearch(new Search
            {
                SearchTerm = term,
                SearchTime = DateTime.UtcNow
            });

            await repo.SaveChangesAsync();
        }
    }
}
