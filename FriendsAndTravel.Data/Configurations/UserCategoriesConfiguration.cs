using FriendsAndTravel.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.Configurations
{
    public class UserCategoriesConfiguration : IEntityTypeConfiguration<UserCategories>
    {
        public void Configure(EntityTypeBuilder<UserCategories> builder)
        {
            builder.HasKey(ui => new { ui.UserId, ui.CategoriesId });

            builder
                .HasOne(ui => ui.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(ui => ui.UserId);

            builder
                .HasOne(ui => ui.Categories)
                .WithMany(i => i.Users)
                .HasForeignKey(ui => ui.CategoriesId);
        }
    }
}
