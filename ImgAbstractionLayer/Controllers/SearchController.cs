﻿using ImgAbstractionLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
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

        [HttpGet]
        public void ThrowError()
        {
            //No arguments were provided for api call, so throw an exception 
            //(user will get rerouted to user error page)
            throw new ArgumentException("No arguments provided for API call");
        }


        //GET api/imagesearch/recent
        [HttpGet("recent")]
        public IActionResult GetRecentSearches()
        {
            return Json(repo.GetRecentSearchesJson());
        }


        [HttpGet("{term}")]
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
