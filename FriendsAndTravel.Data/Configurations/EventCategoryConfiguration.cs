using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.Configurations
{
    public class EventCategoryConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.HasKey(eu => new { eu.EventId, eu.CategoryId });

            builder
               .HasOne(eu => eu.Event)
               .WithMany(u => u.EventCategories)
               .HasForeignKey(eu => eu.EventId);

            builder
               .HasOne(eu => eu.Category)
               .WithMany(e => e.EventCategories)
               .HasForeignKey(eu => eu.CategoryId);

        }
    }
}
