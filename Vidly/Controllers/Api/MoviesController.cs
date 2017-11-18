using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }



        public IEnumerable<MovieDto> GetMovies(string query = null)  // GET /api/movies
        {
            var moviesQuery = _context.Movies
          .Include(m => m.Genre)
          .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));


            // We can also have the action return an IEnumerable<MovieDto> and use this line to replace the below code.
            return moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            //var movieDtos = moviesQuery
            //    .ToList()
            //    .Select(Mapper.Map<Movie, MovieDto>);

            //return Ok(movieDtos);
        }




        public IHttpActionResult GetMovie(int id)  // GET /api/movies/1
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }



        
        [HttpPost]
        [Authorize(Roles = RoleName.Manager)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)  // POST /api/movies
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }




        [HttpPut]
        [Authorize(Roles = RoleName.Manager)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)  // PUT /api/movies/1
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }




        [HttpDelete]
        [Authorize(Roles = RoleName.Manager)]
        public IHttpActionResult DeleteMovie(int id)  // DELETE /api/movies/1
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
