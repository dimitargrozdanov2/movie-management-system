﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManagement.Data;

namespace MovieManagement.Data.Migrations
{
    [DbContext(typeof(MovieManagementContext))]
    partial class MovieManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        },
                        new
                        {
                            Id = "a73fda7b-0ba7-4a28-a339-4f4b1aa36b99",
                            ConcurrencyStamp = "96b58363-85f1-4d20-a7a4-f2a2e4159676",
                            Name = "User",
                            NormalizedName = "USER"
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
                        },
                        new
                        {
                            UserId = "0b8ddcfb-ef03-487b-affb-766611dc9e17",
                            RoleId = "a73fda7b-0ba7-4a28-a339-4f4b1aa36b99"
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
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = "395ff6d8-1d31-4326-97d8-af0474ad9e2a",
                            Name = "JeffGoldblum"
                        },
                        new
                        {
                            Id = "b09e23ef-0974-4cb7-a073-3641cb152690",
                            Name = "ChrisEvans"
                        },
                        new
                        {
                            Id = "06e06210-f637-4c75-b775-a128ae9f6a28",
                            Name = "ScarlettJohansson"
                        },
                        new
                        {
                            Id = "fe75908b-30b6-4ad8-a1dc-076f8c9b1648",
                            Name = "SandraBullock"
                        },
                        new
                        {
                            Id = "142df8e1-a1d5-4ed2-958e-6185ec3a7b36",
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

                    b.Property<string>("MovieID");

                    b.HasKey("UserID", "MovieID");

                    b.HasIndex("MovieID");

                    b.ToTable("UserMovies");
                });

            modelBuilder.Entity("MovieManagement.DataModels.Genre", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            ID = "3f957cb7-339b-4efe-b38d-6e6d478ba76a",
                            Name = "Horror"
                        },
                        new
                        {
                            ID = "6637840b-113b-4d9f-8448-2b320201d01f",
                            Name = "Psycho"
                        },
                        new
                        {
                            ID = "b9d2ef8e-662a-4c7c-b903-d3d8cd2a95a4",
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.Movie", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Duration");

                    b.Property<string>("GenreID");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Rating");

                    b.Property<string>("Storyline");

                    b.Property<int>("VotesCount");

                    b.HasKey("Id");

                    b.HasIndex("GenreID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = "42af373f-8aba-45a5-932b-9e20cc46c0c5",
                            Director = "Anna Boden",
                            Duration = 90,
                            GenreID = "b9d2ef8e-662a-4c7c-b903-d3d8cd2a95a4",
                            ImageUrl = "marvel.png",
                            IsDeleted = false,
                            Name = "Marvel",
                            Rating = 0,
                            Storyline = "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.",
                            VotesCount = 0
                        },
                        new
                        {
                            Id = "79087c1f-07ee-4747-924a-ab6b6a2ede1d",
                            Director = "Guy Ritchie",
                            Duration = 120,
                            GenreID = "3f957cb7-339b-4efe-b38d-6e6d478ba76a",
                            ImageUrl = "aladdin.png",
                            IsDeleted = false,
                            Name = "Aladdin",
                            Rating = 0,
                            Storyline = "A kindhearted Arabian street urchin and a power-hungry Grand Vizier vie for a magic lamp that has the power to make the deepest wishes come true.",
                            VotesCount = 0
                        },
                        new
                        {
                            Id = "4f643260-3675-48ca-bd80-b461e8e6f7ea",
                            Director = "Travis Knight",
                            Duration = 90,
                            GenreID = "b9d2ef8e-662a-4c7c-b903-d3d8cd2a95a4",
                            ImageUrl = "bumblebee.png",
                            IsDeleted = false,
                            Name = "Bumblebee",
                            Rating = 0,
                            Storyline = "On the run in the year of 1987, Bumblebee finds refuge in a junkyard in a small Californian beach town. Charlie, on the cusp of turning 18 and trying to find her place in the world, discovers Bumblebee, battle-scarred and broken.",
                            VotesCount = 0
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.MovieActor", b =>
                {
                    b.Property<string>("MovieId");

                    b.Property<string>("ActorId");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MovieActor");

                    b.HasData(
                        new
                        {
                            MovieId = "42af373f-8aba-45a5-932b-9e20cc46c0c5",
                            ActorId = "395ff6d8-1d31-4326-97d8-af0474ad9e2a"
                        });
                });

            modelBuilder.Entity("MovieManagement.DataModels.News", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("ImageUrl");

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
                            Id = "3848d835-fdc3-497c-a3dd-6cea088dfdf4",
                            DatePosted = new DateTime(2019, 4, 8, 5, 12, 56, 511, DateTimeKind.Utc),
                            ImageUrl = "Endgame.jpg",
                            Text = "This year will mark the last Avengers movie",
                            Title = "Avengers"
                        },
                        new
                        {
                            Id = "4e75e75e-dfdb-4da7-a516-f82ede490535",
                            DatePosted = new DateTime(2012, 12, 21, 12, 0, 56, 511, DateTimeKind.Utc),
                            ImageUrl = "Worldends.jpg",
                            Text = "According to Maya's people today will be the day the world ends. There will be no more movies",
                            Title = "WorldEnds"
                        },
                        new
                        {
                            Id = "3c758ab5-73d0-4e6e-87d4-69d60136a016",
                            DatePosted = new DateTime(2018, 11, 12, 4, 13, 56, 511, DateTimeKind.Utc),
                            ImageUrl = "barcaman.jpg",
                            Text = "Manchester lost to Barca on Old Trafford.",
                            Title = "ManchesterLost"
                        },
                        new
                        {
                            Id = "815149c8-8721-4046-9e67-1b80a964be39",
                            DatePosted = new DateTime(2019, 4, 10, 23, 52, 56, 511, DateTimeKind.Utc),
                            ImageUrl = "shazam.jpg",
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
                        .HasForeignKey("GenreID");
                });

            modelBuilder.Entity("MovieManagement.DataModels.MovieActor", b =>
                {
                    b.HasOne("MovieManagement.DataModels.Actor", "Actor")
                        .WithMany("MovieActor")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieManagement.DataModels.Movie", "Movie")
                        .WithMany("MovieActor")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
