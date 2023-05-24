﻿// <auto-generated />
using System;
using CVproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CVproject.Migrations
{
    [DbContext(typeof(CvContext))]
    [Migration("20230104141348_NROFViewsProperty")]
    partial class NROFViewsProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CVproject.Models.CV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cvs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfViews = 0
                        },
                        new
                        {
                            Id = 2,
                            NumberOfViews = 0
                        },
                        new
                        {
                            Id = 3,
                            NumberOfViews = 0
                        },
                        new
                        {
                            Id = 4,
                            NumberOfViews = 0
                        });
                });

            modelBuilder.Entity("CVproject.Models.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CvId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.ToTable("Competences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CvId = 1,
                            Name = ".NET"
                        },
                        new
                        {
                            Id = 2,
                            CvId = 2,
                            Name = "Behaviour science"
                        },
                        new
                        {
                            Id = 3,
                            CvId = 3,
                            Name = "Leadership"
                        },
                        new
                        {
                            Id = 4,
                            CvId = 4,
                            Name = "Ambitious"
                        });
                });

            modelBuilder.Entity("CVproject.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CvId")
                        .HasColumnType("int");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Orientation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.ToTable("Educations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CvId = 1,
                            EndYear = 2014,
                            Orientation = "Software Engineering",
                            StartYear = 2011,
                            University = "Örebro"
                        },
                        new
                        {
                            Id = 2,
                            CvId = 2,
                            EndYear = 2015,
                            Orientation = "Behaviour science",
                            StartYear = 2014,
                            University = "Mälardalens högskola"
                        },
                        new
                        {
                            Id = 3,
                            CvId = 2,
                            EndYear = 2020,
                            Orientation = "Nuclear safety",
                            StartYear = 2015,
                            University = "Mälardalens högskola"
                        },
                        new
                        {
                            Id = 4,
                            CvId = 3,
                            EndYear = 2020,
                            Orientation = "Finding Neverland",
                            StartYear = 2014,
                            University = "Mälardalens högskola"
                        },
                        new
                        {
                            Id = 5,
                            CvId = 4,
                            EndYear = 2006,
                            Orientation = "Lab science",
                            StartYear = 2000,
                            University = "Townville"
                        },
                        new
                        {
                            Id = 6,
                            CvId = 4,
                            EndYear = 2008,
                            Orientation = "Lab assistent",
                            StartYear = 2007,
                            University = "Townville"
                        });
                });

            modelBuilder.Entity("CVproject.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CvId")
                        .HasColumnType("int");

                    b.Property<string>("Employer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.ToTable("Experiences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CvId = 1,
                            Employer = "PN",
                            EndYear = 2021,
                            StartYear = 2015,
                            Title = "Customs Administrator"
                        },
                        new
                        {
                            Id = 2,
                            CvId = 1,
                            Employer = "Happy-Go-Lucky",
                            EndYear = 2022,
                            StartYear = 2021,
                            Title = "Senior developer"
                        },
                        new
                        {
                            Id = 3,
                            CvId = 2,
                            Employer = "Power Plant",
                            EndYear = 2022,
                            StartYear = 2016,
                            Title = "Inspector"
                        },
                        new
                        {
                            Id = 4,
                            CvId = 3,
                            Employer = "Öppenvård",
                            EndYear = 2022,
                            StartYear = 2020,
                            Title = "Kurator"
                        },
                        new
                        {
                            Id = 5,
                            CvId = 4,
                            Employer = "Professor Utonium",
                            EndYear = 2022,
                            StartYear = 2009,
                            Title = "Lab assistent"
                        });
                });

            modelBuilder.Entity("CVproject.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CVproject.Models.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CvId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CvId")
                        .IsUnique()
                        .HasFilter("[CvId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "14ad059c-f280-446d-bbd2-a4196d35e1c6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a0d3fd3a-96f0-4949-be5b-67d3ca682b7f",
                            CvId = 1,
                            Email = "peter.griffin@gmail.com",
                            EmailConfirmed = false,
                            IsPrivate = true,
                            LockoutEnabled = false,
                            Name = "Peter Griffin",
                            PhoneNumberConfirmed = false,
                            Picture = "pic.jpg",
                            SecurityStamp = "ec7d4230-7dba-4aa2-bf02-f23bb26f427d",
                            TwoFactorEnabled = false,
                            UserName = "Griff007"
                        },
                        new
                        {
                            Id = "18d491ef-a1b0-4d96-9555-65aaadad5946",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b146d1b4-8949-4dfa-9882-66aa4ce18d04",
                            CvId = 2,
                            Email = "homer.simpson@gmail.com",
                            EmailConfirmed = false,
                            IsPrivate = false,
                            LockoutEnabled = false,
                            Name = "Homer Simpson",
                            PhoneNumberConfirmed = false,
                            Picture = "koala.jpg",
                            SecurityStamp = "70b2fff7-5a84-42c7-b8fe-f9a4a54afb29",
                            TwoFactorEnabled = false,
                            UserName = "Springfield"
                        },
                        new
                        {
                            Id = "0809527e-b3b9-4387-8953-a86f79de13cc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6afa4981-035e-4137-bb07-20f76250580b",
                            CvId = 3,
                            Email = "peter.pan@gmail.com",
                            EmailConfirmed = false,
                            IsPrivate = false,
                            LockoutEnabled = false,
                            Name = "Peter Pan",
                            PhoneNumberConfirmed = false,
                            Picture = "dino.jpg",
                            SecurityStamp = "de642445-3bd2-494e-bd28-cd27c50c3530",
                            TwoFactorEnabled = false,
                            UserName = "Neverland"
                        },
                        new
                        {
                            Id = "6ce8b41c-6722-49d6-ad1b-91d04479cb96",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9e68b546-7576-40ca-b969-fd3ea54f1b6f",
                            CvId = 4,
                            Email = "mojo.jojo@gmail.com",
                            EmailConfirmed = false,
                            IsPrivate = false,
                            LockoutEnabled = false,
                            Name = "Mojo Jojo",
                            PhoneNumberConfirmed = false,
                            Picture = "pic2.jpg",
                            SecurityStamp = "1d5bfff3-cb94-4935-bbd4-d49c04539efc",
                            TwoFactorEnabled = false,
                            UserName = "KingMojo"
                        });
                });

            modelBuilder.Entity("CVproject.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectOwner");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("CVproject.Models.ProjectMember", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CVproject.Models.Competence", b =>
                {
                    b.HasOne("CVproject.Models.CV", "Cv")
                        .WithMany("Competences")
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cv");
                });

            modelBuilder.Entity("CVproject.Models.Education", b =>
                {
                    b.HasOne("CVproject.Models.CV", "Cv")
                        .WithMany("Educations")
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cv");
                });

            modelBuilder.Entity("CVproject.Models.Experience", b =>
                {
                    b.HasOne("CVproject.Models.CV", "Cv")
                        .WithMany("Experiences")
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cv");
                });

            modelBuilder.Entity("CVproject.Models.Message", b =>
                {
                    b.HasOne("CVproject.Models.Person", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("CVproject.Models.Person", b =>
                {
                    b.HasOne("CVproject.Models.CV", "CV")
                        .WithOne("Person")
                        .HasForeignKey("CVproject.Models.Person", "CvId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CV");
                });

            modelBuilder.Entity("CVproject.Models.Project", b =>
                {
                    b.HasOne("CVproject.Models.Person", "Person")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CVproject.Models.ProjectMember", b =>
                {
                    b.HasOne("CVproject.Models.Person", "Person")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CVproject.Models.Project", "Project")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CVproject.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CVproject.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CVproject.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CVproject.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVproject.Models.CV", b =>
                {
                    b.Navigation("Competences");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CVproject.Models.Person", b =>
                {
                    b.Navigation("ProjectMembers");

                    b.Navigation("Projects");

                    b.Navigation("ReceivedMessages");
                });

            modelBuilder.Entity("CVproject.Models.Project", b =>
                {
                    b.Navigation("ProjectMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
