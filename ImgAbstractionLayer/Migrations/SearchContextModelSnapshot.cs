using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ImgAbstractionLayer.Models;

namespace ImgAbstractionLayer.Migrations
{
    [DbContext(typeof(SearchContext))]
    partial class SearchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImgAbstractionLayer.Models.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SearchTerm");

                    b.Property<DateTime>("SearchTime");

                    b.HasKey("Id");

                    b.ToTable("Searches");
                });
        }
    }
}
