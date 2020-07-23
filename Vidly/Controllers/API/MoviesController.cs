using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        //private VidlyContext Context;

        private ApplicationDbContext Context;

        public MoviesController()
        {
            Context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult GetMovies(string query = null)
        {
            //return Ok(Context.Movies.Include(g => g.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>));


            var moviesQuery = Context.Movies.Include(g => g.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var moviesDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDtos);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = Context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.ID == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/<controller>
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            Context.Movies.Add(movie);
            Context.SaveChanges();
            //movieDto.ID = movie.ID;

            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        // PUT api/<controller>/5
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = Context.Movies.SingleOrDefault(m => m.ID == id);

            if (movieInDb == null)
                return NotFound();

            movieDto.ID = id;

            Mapper.Map(movieDto, movieInDb);

            Context.SaveChanges();
            return Ok();

        }

        // DELETE api/<controller>/5
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = Context.Movies.SingleOrDefault(m => m.ID == id);

            if (movieInDb == null)
                return NotFound();

            Context.Movies.Remove(movieInDb);
            Context.SaveChanges();

            return Ok();
        }
    }
}