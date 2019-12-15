using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=best-komp;Database=FootballApplicationDataBase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(t => t.Id);
            modelBuilder.Entity<Stadium>()
                .HasMany(g => g.Games)
                .WithOne(s => s.Stadium)
                .HasForeignKey(p => p.StadiumId)
                .HasPrincipalKey(t => t.Id);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(t => t.HomeTeamId)
                .HasPrincipalKey(t => t.Id);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(t => t.AwayTeamId).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(t => t.Id);
        }

    }
}
