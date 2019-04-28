﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManagement.Data;

namespace MovieManagement.Data.Migrations
{
    [DbContext(typeof(MovieManagementContext))]
    [Migration("20190428200320_JsonAdded")]
    partial class JsonAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "0e78767e-b4d2-456f-b029-5ad4c454589a",
                            ConcurrencyStamp = "6e63ab39-a514-4e99-ba86-296cfe8d15b5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
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

                    b.ToTable("AspNetRoleClaims");
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

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "0b8ddcfb-ef03-487b-affb-766611dc9e17",
                            RoleId = "0e78767e-b4d2-456f-b029-5ad4c454589a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MovieManagement.DataModels.Actor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "JeffGoldblum"
                        },
                        new
                        {
                            ID = 2,
                            Name = "ChrisEvans"
                        },
                        new
                        {
                            ID = 3,
                            Name = "ScarlettJohansson"
                        },
                        new
                        {
                            ID = 4,
                            Name = "SandraBullock"
                        },
                        new
                        {
                            ID = 5,
                            Name = "JohnnyDepp"
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "0b8ddcfb-ef03-487b-affb-766611dc9e17",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b318fa87-5d53-4bc3-8019-23d7aa37da20",
                            Email = "admin@admin.admin",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEHzP/Ds0oHiv5C7IjlaA+ce9X9hucPveVIL0EgYgT7ScxgYCFnZFsMQQZLRC5BPKLw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7I2NUNAXILZUAHNGX7TRSNQCNRWCEOSX",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.ApplicationUserMovie", b =>
                {
                    b.Property<string>("UserID");

                    b.Property<int>("MovieID");

                    b.HasKey("UserID", "MovieID");

                    b.HasIndex("MovieID");

                    b.ToTable("UserMovies");
                });

            modelBuilder.Entity("MovieManagement.DataModels.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Horror"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Psycho"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Duration");

                    b.Property<int>("GenreID");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Rating");

                    b.Property<string>("Storyline");

                    b.Property<int>("VotesCount");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Director = "Anna Boden",
                            Duration = 90,
                            GenreID = 2,
                            IsDeleted = false,
                            Name = "Marvel",
                            Rating = 0.0,
                            Storyline = "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.",
                            VotesCount = 0
                        },
                        new
                        {
                            ID = 2,
                            Director = "Guy Ritchie",
                            Duration = 120,
                            GenreID = 1,
                            IsDeleted = false,
                            Name = "Aladdin",
                            Rating = 0.0,
                            Storyline = "A kindhearted Arabian street urchin and a power-hungry Grand Vizier vie for a magic lamp that has the power to make the deepest wishes come true.",
                            VotesCount = 0
                        },
                        new
                        {
                            ID = 3,
                            Director = "Travis Knight",
                            Duration = 90,
                            GenreID = 2,
                            IsDeleted = false,
                            Name = "Bumblebee",
                            Rating = 0.0,
                            Storyline = "On the run in the year of 1987, Bumblebee finds refuge in a junkyard in a small Californian beach town. Charlie, on the cusp of turning 18 and trying to find her place in the world, discovers Bumblebee, battle-scarred and broken.",
                            VotesCount = 0
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.MovieActor", b =>
                {
                    b.Property<int>("MovieID");

                    b.Property<int>("ActorID");

                    b.HasKey("MovieID", "ActorID");

                    b.HasIndex("ActorID");

                    b.ToTable("MovieActor");
                });

            modelBuilder.Entity("MovieManagement.DataModels.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DatePosted = new DateTime(2019, 4, 8, 5, 12, 56, 511, DateTimeKind.Utc),
                            Text = "This year will mark the last Avengers movie",
                            Title = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            DatePosted = new DateTime(2012, 12, 21, 12, 0, 56, 511, DateTimeKind.Utc),
                            Text = "According to Maya's people today will be the day the world ends. There will be no more movies",
                            Title = "WorldEnds"
                        },
                        new
                        {
                            Id = 3,
                            DatePosted = new DateTime(2018, 11, 12, 4, 13, 56, 511, DateTimeKind.Utc),
                            Text = "Manchester lost to Barca on Old Trafford.",
                            Title = "ManchesterLost"
                        },
                        new
                        {
                            Id = 4,
                            DatePosted = new DateTime(2019, 4, 10, 23, 52, 56, 511, DateTimeKind.Utc),
                            Text = "Tickets have been soldout for the premirer of Shazam",
                            Title = "TicketsSoldout"
                        });
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
                    b.HasOne("MovieManagement.DataModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MovieManagement.DataModels.ApplicationUser")
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

                    b.HasOne("MovieManagement.DataModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MovieManagement.DataModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieManagement.DataModels.ApplicationUserMovie", b =>
                {
                    b.HasOne("MovieManagement.DataModels.Movie", "Movie")
                        .WithMany("ApplicationUserMovie")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieManagement.DataModels.ApplicationUser", "User")
                        .WithMany("ApplicationUserMovie")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieManagement.DataModels.Movie", b =>
                {
                    b.HasOne("MovieManagement.DataModels.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieManagement.DataModels.MovieActor", b =>
                {
                    b.HasOne("MovieManagement.DataModels.Actor", "Actor")
                        .WithMany("MovieActor")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieManagement.DataModels.Movie", "Movie")
                        .WithMany("MovieActor")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
