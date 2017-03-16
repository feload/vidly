using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private Context _context;
        public MoviesController()
        {
            _context = new Context();
        }
        // GET: api/Movie
        public IEnumerable<MovieDTO> GetMovie()
        {
            return _context.Movies
                        .Include(m => m.Genre)
                        .ToList()
                        .Select(Mapper.Map<Movie, MovieDTO>);
        }

        // GET: api/Movie/1
        public MovieDTO GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if(movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Movie, MovieDTO>(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public MovieDTO CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return movieDTO;
        }

        // PUT: api/Movies/1
        [HttpPut]
        public void UpdateMovie(int Id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();            
        }

        // DELETE: api/Movies/1
        public Movie DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return movieInDb;

        }

    }
}
