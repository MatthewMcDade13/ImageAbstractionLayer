using ImgAbstractionLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //GET api/imagesearch/latest
        [HttpGet("latest")]
        public IActionResult GetRecentSearches()
        {

            //var test = repo.GetRecentSearches().ToArray();
            return Json(repo.GetRecentSearchesJson());
        }
    }
}
