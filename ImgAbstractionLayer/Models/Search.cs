using System;

namespace ImgAbstractionLayer.Models
{
    public class Search
    {
        public int Id { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchTerm { get; set; }
    }
}
