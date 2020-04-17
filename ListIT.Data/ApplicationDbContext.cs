using ListIT.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Data
{
    public class ApplicationDbContext:IdentityDbContext<User, Role, string>
    {
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PlacePerk> PlacePerks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PlacePerk>().HasKey(pp => new { pp.PlaceId, pp.PerkId });

            builder.Entity<PlacePerk>()
                .HasOne<Place>(sc => sc.Place)
                .WithMany(s => s.PlacePerks)
                .HasForeignKey(sc => sc.PlaceId);


            builder.Entity<PlacePerk>()
                .HasOne<Perk>(sc => sc.Perk)
                .WithMany(s => s.PlacePerks)
                .HasForeignKey(sc => sc.PerkId);
        }
    }
}
