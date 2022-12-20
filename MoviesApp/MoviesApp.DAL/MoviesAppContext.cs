using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL
{
    public partial class MoviesAppContext : DbContext
    {
        public MoviesAppContext(DbContextOptions<MoviesAppContext> options) : base(options) 
        {

        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<CrewMember> CrewMembers { get; set; }
        public virtual DbSet<MovieCredit> MovieCredits { get; set; }
        public virtual DbSet<CrewMemberMovieCredit> CrewMemberMovieCredits { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-TMG3LQD\\SQLEXPRESS;initial catalog=MovieDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                .HasIndex(g => g.TmdbId).IsUnique();
            modelBuilder.Entity<Movie>()
                .HasIndex(m => m.TmbdId).IsUnique();
            modelBuilder.Entity<CrewMember>();

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.MovieGenres)
                .WithOne(mg => mg.Genre);
            
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.MovieGenres)
                .WithOne(mg => mg.Movie);
            
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.CrewMemberMovieCredits)
                .WithOne(cmmc => cmmc.Movie);
            
            modelBuilder.Entity<MovieCredit>()
                .HasMany(mc => mc.CrewMemberMovieCredits)
                .WithOne(cmmc => cmmc.MovieCredit);

            modelBuilder.Entity<CrewMember>()
                .HasMany(cm => cm.CrewMemberMovieCredits)
                .WithOne(cmmc => cmmc.CrewMember);
        }
    }
}
