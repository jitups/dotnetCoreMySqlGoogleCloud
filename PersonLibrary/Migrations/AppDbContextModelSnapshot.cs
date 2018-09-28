﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonLibrary.Repositories;

namespace PersonLibrary.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PersonLibrary.Entities.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Directors")
                        .HasColumnName("directors");

                    b.Property<string>("Genres")
                        .HasColumnName("genres");

                    b.Property<string>("ImdbCode")
                        .HasColumnName("imdb_code");

                    b.Property<decimal>("ImdbRating")
                        .HasColumnName("imdb_rating");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnName("release_date");

                    b.Property<int>("Runtime")
                        .HasColumnName("runtime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .HasColumnName("type");

                    b.Property<int>("UserRating")
                        .HasColumnName("rating");

                    b.Property<DateTime>("UserRatingDate")
                        .HasColumnName("rating_date");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("PersonLibrary.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DoB");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Note");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonLibrary.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersonLibrary.Entities.UserMovieRatings", b =>
                {
                    b.Property<int>("UserMovieRatingID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieId");

                    b.Property<short>("Rating");

                    b.HasKey("UserMovieRatingID");

                    b.HasIndex("MovieId");

                    b.ToTable("UserMovieRatings");
                });

            modelBuilder.Entity("PersonLibrary.Entities.UserMovieRatings", b =>
                {
                    b.HasOne("PersonLibrary.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
