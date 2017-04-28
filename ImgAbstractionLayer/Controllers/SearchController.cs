using ImgAbstractionLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace ImgAbstractionLayer.Controllers
{
    [Route("api/imagesearch")]
    public class SearchController : Controller
    {
        private ISearchRepository repo;

        public SearchController(ISearchRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("{term:alpha}")]
        public async Task<IActionResult> SearchImages(string term)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://wind-bow.glitch.me/twitch-api/channels/classypax"))
                {
                    response.EnsureSuccessStatusCode();

                    string jsonString = await response.Content.ReadAsStringAsync();

                    Object json = JsonConvert.DeserializeObject(jsonString);

                    return Json(json);
                }
            }
        }

        //GET api/imagesearch/recent
        [HttpGet("recent")]
        public IActionResult GetRecentSearches()
        {

            //var test = repo.GetRecentSearches().ToArray();
            return Json(repo.GetRecentSearchesJson());
        }
    }
}
