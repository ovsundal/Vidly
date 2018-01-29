﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //defensive approach (good for public apis). Gives a detailed explanation of what went wrong,
        //but is polluting the code. Not suitable in this case, because api is not public
        //[HttpPost]
        //public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        //{
        //    if (newRental.MovieIds.Count == 0)
        //    {
        //        return BadRequest("No Movie Ids have been given.");
        //    }

        //    var customer = _context.Customers.SingleOrDefault(
        //        c => c.Id == newRental.CustomerId);

        //    if (customer == null)
        //    {
        //        return BadRequest("CustomerId is not valid.");
        //    }

        //    var movies = _context.Movies.Where(
        //        m => newRental.MovieIds.Contains(m.Id)).ToList();

        //    if (movies.Count != newRental.MovieIds.Count)
        //    {
        //        return BadRequest("One or more movieIds are invalid");
        //    }

        //    foreach (var movie in movies)
        //    {
        //        if (movie.NumberAvailable == 0)
        //        {
        //            return BadRequest("Movie is not available");
        //        }

        //        movie.NumberAvailable--;

        //            var rental = new Rental
        //            {
        //                Customer = customer,
        //                Movie = movie,
        //                DateRented = DateTime.Now
        //            };

        //            _context.Rentals.Add(rental);
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}

        //optimistic approach: cleaner code, better for private apis
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
