﻿// <auto-generated />
using System;
using FriendsAndTravel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FriendsAndTravel.Migrations
{
    [DbContext(typeof(FriendsAndTravelDbContext))]
    [Migration("20190701191545_01")]
    partial class _01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnds");

                    b.Property<DateTime>("DateStarts");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Location");

                    b.Property<int>("LocationId");

                    b.Property<string>("OwnerId");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.EventUser", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<string>("UserId");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUsers");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsProfilePicture");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<byte[]>("PhotoAsBytes")
                        .IsRequired()
                        .HasMaxLength(5242880);

                    b.Property<int?>("PostId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Feeling");

                    b.Property<int>("Likes");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<byte[]>("Avatar");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("LocationId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.UserCategories", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("CategoriesId");

                    b.HasKey("UserId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("UserCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = "b870668d-24b3-4cb3-b9b9-9935fcd3cc0b", ConcurrencyStamp = "ebbab970-d7b8-4698-985a-1e08df4bdb56", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "55aad979-0689-4267-b76d-b76d30b2b6c1", ConcurrencyStamp = "4682c920-6222-4ad3-9337-e9d8d4f2a76c", Name = "User", NormalizedName = "USER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Model.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("PostId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Model.Entities.EventCategory", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("CategoryId");

                    b.Property<int>("Id");

                    b.HasKey("EventId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("Model.Entities.EventPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("PhotoId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PhotoId");

                    b.ToTable("EventPhotos");
                });

            modelBuilder.Entity("Model.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameLocation");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Event", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.EventUser", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FriendsAndTravel.Data.Entities.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Photo", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("FriendsAndTravel.Data.Entities.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.Post", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.User", b =>
                {
                    b.HasOne("Model.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("FriendsAndTravel.Data.Entities.UserCategories", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.Categories", "Categories")
                        .WithMany("Users")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FriendsAndTravel.Data.Entities.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FriendsAndTravel.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Entities.Comment", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FriendsAndTravel.Data.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Model.Entities.EventCategory", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.Categories", "Category")
                        .WithMany("EventCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FriendsAndTravel.Data.Entities.Event", "Event")
                        .WithMany("EventCategories")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Entities.EventPhoto", b =>
                {
                    b.HasOne("FriendsAndTravel.Data.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FriendsAndTravel.Data.Entities.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
