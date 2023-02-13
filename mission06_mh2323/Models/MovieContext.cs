using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission06_mh2323.Models
{
    public class MovieContext:DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            
        }

        //setting connection 
        public DbSet<Movie> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder ab)
        {
            //Seeding database
            ab.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Category = "Action/Comedy",
                    Title = "Speed Racer",
                    Year = 2008,
                    Director = "The Wachowskis",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Becky",
                    Notes = "Trying to convince Becky Speed Racer is the best movie"
                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Family/Musical",
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno/Byron Howard",
                    Rating = "PG",
                    Edited = false,
                    LentTo =  null,
                    Notes = null

                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Comedy/Fantasy",
                    Title = "Shrek",
                    Year = 2001,
                    Director = "Vicky Jenson/Andrew Adamson",
                    Rating = "PG",
                    Edited = false,
                    LentTo = null,
                    Notes = null

                }
            ) ;
        }
    }
}
