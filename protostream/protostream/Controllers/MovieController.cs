using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using protostream.Models;

namespace protostream.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MovieContext _dbContext;
        public MovieController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            var movie = _dbContext.Movies.Single(x => x.id == id);
            return movie;
        }

        [HttpGet]
        public IEnumerable<Movie> Get([FromQuery(Name = "filter")] String? filter, [FromQuery(Name = "order")] string? order)
        {
            var movies = from m in _dbContext.Movies
                         select m;

            if (!String.IsNullOrEmpty(filter))
            {
                movies = movies.Where(x => x.film.ToLower().Contains(filter.ToLower()));
            }

            if (!String.IsNullOrEmpty(order))
            {
                switch (order)
                {
                    case "year":
                        movies = movies.OrderBy(x => x.year);
                        break;
                    case "audienceScore":
                        movies = movies.OrderBy(x => x.audienceScore);
                        break;
                }
            }


            return movies.AsEnumerable<Movie>();
        }
    }
}
