using Microsoft.EntityFrameworkCore;
using PersonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonLibrary.Repositories
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own confguration here
            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieId)
                .HasColumnName("id");

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .HasColumnName("title");

            modelBuilder.Entity<Movie>()
                .Property(m => m.Genres)
                .HasColumnName("genres");

            modelBuilder.Entity<Movie>()
                .Property(m => m.Directors)
                .HasColumnName("directors");

            modelBuilder.Entity<Movie>()
                .Property(m => m.ReleaseDate)
                .HasColumnName("release_date");

            modelBuilder.Entity<Movie>()
                .Property(m => m.Runtime)
                .HasColumnName("runtime");

            modelBuilder.Entity<Movie>()
                .Property(m => m.Type)
                .HasColumnName("type");

            modelBuilder.Entity<Movie>()
                .Property(m => m.ImdbCode)
                .HasColumnName("imdb_code");

            modelBuilder.Entity<Movie>()
                .Property(m => m.ImdbRating)
                .HasColumnName("imdb_rating");

            modelBuilder.Entity<Movie>()
                .Property(m => m.UserRating)
                .HasColumnName("rating");

            modelBuilder.Entity<Movie>()
                .Property(m => m.UserRatingDate)
                .HasColumnName("rating_date");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
