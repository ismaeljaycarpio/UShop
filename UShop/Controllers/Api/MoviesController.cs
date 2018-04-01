using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UShop.Models;
using UShop.Dto;
using UShop.Entities;
using System.Data.Entity;
using AutoMapper;


namespace UShop.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return context.Movies
                .Include(a => a.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //create
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            context.Movies.Add(movie);
            context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            //update
            Mapper.Map<MovieDto, Movie>(movieDto, movie);
            context.SaveChanges();
            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            //delete
            context.Movies.Remove(movie);
            context.SaveChanges();
            return Ok();
        }

    }
}
