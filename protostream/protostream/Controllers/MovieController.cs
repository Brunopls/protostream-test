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
    }
}
