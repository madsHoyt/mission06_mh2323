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
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder ab)
        {
            //Seeding database
            ab.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Family" },
                new Category { CategoryId = 3, CategoryName = "Comedy" },
                new Category { CategoryId = 4, CategoryName = "Romance" },
                new Category { CategoryId = 5, CategoryName = "Horror" },
                new Category { CategoryId = 6, CategoryName = "Drama" }
                ); 
            //Seeding database
            ab.Entity<Movie>().HasData(
                new Movie
                {

                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 2,
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
                    CategoryId = 3,
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
