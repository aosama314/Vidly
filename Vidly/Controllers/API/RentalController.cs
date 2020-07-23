using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext Context;

        public RentalController()
        {
            Context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIDs.Count == 0)
                return BadRequest("No Movies IDs Have been given.");

            var customer = Context.Customers.SingleOrDefault(c => c.ID == newRental.CustomerID);

            if (customer == null)
                return BadRequest("Invalid customer ID.");
            
            var movies = Context.Movies.Where(m => newRental.MovieIDs.Contains(m.ID)).ToList();

            if (movies.Count != newRental.MovieIDs.Count)
                return BadRequest("One or more movies IDs invalid.");

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                Context.Rentals.Add(rental);
            }

            Context.SaveChanges();

            return Ok();
        }
    }
}
