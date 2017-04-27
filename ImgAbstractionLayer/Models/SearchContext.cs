using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Models
{
    public class SearchContext : DbContext
    {
        public DbSet<Search> Searches { get; set; }
        private IConfigurationRoot config;

        public SearchContext(IConfigurationRoot config, DbContextOptions options) 
            : base(options)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(config["Data:ConnectionString"]);
        }
    }

    
}
