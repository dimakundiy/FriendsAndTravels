using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FriendsAndTravel.Data.Configurations;
using Microsoft.AspNetCore.Identity;

using FriendsAndTravel.BAL.DTO;
using Model.Entities;

namespace FriendsAndTravel.Data
{
   public class FriendsAndTravelDbContext : IdentityDbContext<User>
    {
        public DbSet<UserCategories> UserCategories { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
         public DbSet<Location> Locations { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventPhoto> EventPhotos { get; set; }
        public DbSet<Categories> Categories { get; set; }
        
        public FriendsAndTravelDbContext(DbContextOptions<FriendsAndTravelDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserCategoriesConfiguration());
            builder.ApplyConfiguration(new EventUserConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new EventCategoryConfiguration());
            base.OnModelCreating(builder);

            

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            );
            builder
          .Entity<User>()
          .Property(p => p.Gender)
          .HasConversion(
              v => v.ToString(),
              v => (Gender)Enum.Parse(typeof(Gender),v));
            builder.Entity<IdentityUser>().ToTable("IdentityUser");
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        }
    }
}
