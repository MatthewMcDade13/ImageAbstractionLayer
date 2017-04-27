using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Models
{
    public class Search
    {
        public int Id { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchTerm { get; set; }
    }
}
