using LLQ0P5_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LLQ0P5_HFT_2022231.Repository
{
    public class PlayDbContext : DbContext
    {
        public DbSet<Play> Play { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public PlayDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("play");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Play>(play => play
            .HasOne(play => play.Director)
            .WithMany(director => director.Play)
            .HasForeignKey(play => play.DirectorId)
            .OnDelete(DeleteBehavior.Cascade)
            );
            modelBuilder.Entity<Actor>()
               .HasMany(x => x.Play)
               .WithMany(x => x.Actors)
               .UsingEntity<Role>(
                x => x.HasOne(x => x.Play)
                .WithMany().HasForeignKey(x => x.PlayId).OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne(x => x.Actor)
                .WithMany().HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Cascade)

                );
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Actor)
                .WithMany(actor => actor.Roles)
                .HasForeignKey(r => r.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Play)
                .WithMany(play => play.Roles)
                .HasForeignKey(r => r.PlayId)
                .OnDelete(DeleteBehavior.Cascade);
            #region data creating
            Director director1 = new Director()
            {
                DirectorId = 1,
                Name = "Goldmark Károly ",
            };
            Director director2 = new Director()
            {
                DirectorId = 2,
                Name = "Erkel Ferenc",
            };
            Director director3 = new Director()
            {
                DirectorId = 3,
                Name = "Kodály Zoltán ",
            };

            Actor actor1 = new Actor()
            {
                ActorId = 2,
                ActorName = "Elek Ferenc",
            };
            Actor actor2 = new Actor()
            {
                ActorId = 1,
                ActorName = "Ádám Kornél",
            };
            Actor actor3 = new Actor()
            {
                ActorId = 3,
                ActorName = "Szegedi Csaba",
            };
            Play play1 = new Play()
            {
                PlayID = 1,
                Title = "Merlin",
                ReleaseDate = DateTime.Parse("1889.11.19"),
                Rating = 2,
                DirectorId = 1,
                Income = 5000,
            };
            Play play2 = new Play()
            {
                PlayID = 2,
                Title = "Bánk bán",
                ReleaseDate = DateTime.Parse("1883.02.19"),
                Rating = 3,
                DirectorId = 2,
                Income = 10000,
            };
            Play play3 = new Play()
            {
                PlayID = 3,
                Title = "Háry János",
                ReleaseDate = DateTime.Parse("1926.10.16"),
                Rating = 5,
                DirectorId = 3,
                Income = 15000,
            };
            Role role1 = new Role()
            {
                RoleID = 1,
                ActorId = 1,
                PlayId = 1,
                Rolename = "Tankred Dorst",
            };
            Role role2 = new Role()
            {
                RoleID = 2,
                ActorId = 2,
                PlayId = 2,
                Rolename = "II.Endre",
            };
            Role role3 = new Role()
            {
                RoleID = 3,
                ActorId = 3,
                PlayId = 3,
                Rolename = "Háry János",
            };


            #endregion
            modelBuilder.Entity<Actor>().HasData(actor1, actor2, actor3);
            modelBuilder.Entity<Director>().HasData(director1, director2, director3);
            modelBuilder.Entity<Play>().HasData(play1, play2, play3);
            modelBuilder.Entity<Role>().HasData(role1, role2, role3);



        }

    }
}
