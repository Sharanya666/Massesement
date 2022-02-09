using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovie.Models;
using Microsoft.AspNetCore.Authentication;


namespace MyMovie.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _MovieDbContext;
        public MovieController(MovieDbContext MovieDbContext)
        {
            _MovieDbContext = MovieDbContext;
        }

        [HttpGet("GetMovie")]
        public IEnumerable<MovieModel> GetMovie()
        {
            return _MovieDbContext.moviemodel.ToList();
        }
        [HttpGet("MovieById")]
        public MovieModel MovieById(int MovieId)
        {
            return _MovieDbContext.moviemodel.Find(MovieId);
        }

        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie([FromBody]MovieModel moviemodel)
        {
            if (moviemodel.MovieId.ToString() != "")
            {
                _MovieDbContext.moviemodel.Add(moviemodel);
                _MovieDbContext.SaveChanges();
                return Ok("Movie Inserted  Successfully");                
            }
            else
                return BadRequest(); 
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody]MovieModel moviemodel)
        {
            if (moviemodel.MovieId.ToString() != "")
            {                
                _MovieDbContext.Entry(moviemodel).State = EntityState.Modified;
                _MovieDbContext.SaveChanges();
                return Ok("Movie Updated successfully");
            }
            else
                return BadRequest();
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int MovieId)
        {
            var result = _MovieDbContext.moviemodel.Find(MovieId);
            _MovieDbContext.moviemodel.Remove(result);
            _MovieDbContext.SaveChanges();
            return Ok("Movie Deleted  successfully");
        }
    }
}

