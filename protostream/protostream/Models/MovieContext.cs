using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace protostream.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public string DbPath { get; }

        public MovieContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "movie.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Movie
    {
        public int id { get; set; }
        public String film { get; set; }
        public String genre { get; set; }
        public String leadStudio { get; set; }
        public byte audienceScore { get; set; }
        public decimal profitability { get; set; }
        public byte rottenTomatoes { get; set; }
        public decimal worldwideGross { get; set; }
        public UInt16 year { get; set; }

    }

}