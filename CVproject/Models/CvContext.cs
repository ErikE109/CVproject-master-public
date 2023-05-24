using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CVproject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CVproject.Controllers;
using Microsoft.CodeAnalysis;

namespace CVproject.Models
{
    
    public class CvContext : IdentityDbContext<Person>
    {
        public CvContext(DbContextOptions <CvContext> options) : base(options)
        {

        }

        public DbSet<CV> Cvs { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Competence> Competences { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<ProjectMember> ProjectMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Lägger till Composite keys i M-N tabellerna


            modelBuilder.Entity<ProjectMember>().HasKey(km => new { km.ProjectId, km.PersonId });



            //Modiferar constraints


            modelBuilder.Entity<CV>()
                .HasOne(e => e.Person)
                .WithOne(e => e.CV)
                .OnDelete(DeleteBehavior.Restrict);
            
           modelBuilder.Entity<ProjectMember>()
                .HasOne(e => e.Person)
                .WithMany(e => e.ProjectMembers)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectMember>()
              .HasOne(e => e.Project)
              .WithMany(e =>e.ProjectMembers)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Message>()
              .HasOne(e => e.Receiver)
              .WithMany(e => e.ReceivedMessages)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Competence>()
                .HasOne(e => e.Cv)
                .WithMany(e => e.Competences)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.Cv)
                .WithMany(e => e.Educations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Cv)
                .WithMany(e => e.Experiences)
                .OnDelete(DeleteBehavior.Restrict);




            modelBuilder.Entity<CV>()
               .HasData(
               new CV
               {
                   Id = 1,

               },

               new CV()
               {
                   Id = 2,
               },

               new CV()
               {
                   Id = 3,
               },

               new CV()
               {
                   Id = 4,
               }
               );



            modelBuilder.Entity<Person>()
                .HasData(
                new Person
                {
                    Name = "Peter Griffin",
                    Email = "peter.griffin@gmail.com",
                    Picture = null,
                    CvId = 1,
                    IsPrivate = true,
                    UserName = "Griff007",
                    PasswordHash = null
                },

                new Person
                {
                    Name = "Homer Simpson",
                    Email = "homer.simpson@gmail.com",
                    Picture = null,
                    CvId = 2,
                    UserName = "Springfield",
                    PasswordHash = null
                },
                new Person
                {
                    Name = "Peter Pan",
                    Email = "peter.pan@gmail.com",
                    Picture = null,
                    CvId = 3,
                    UserName = "Neverland",
                    PasswordHash = null
                },
                new Person
                {
                    Name = "Mojo Jojo",
                    Email = "mojo.jojo@gmail.com",
                    Picture = null,
                    CvId = 4,
                    UserName = "KingMojo",
                    PasswordHash = null
                }
                );

            modelBuilder.Entity<Competence>()
                .HasData(
                new Competence
                {
                    Id = 1,
                    Name = ".NET",
                    CvId = 1

                },

                new Competence
                {
                    Id = 2,
                    Name = "Behaviour science",
                    CvId = 2
                },

                new Competence
                {
                    Id = 3,
                    Name = "Leadership",
                    CvId = 3
                },

                new Competence
                {
                    Id = 4,
                    Name = "Ambitious",
                    CvId = 4
                }


                );

            modelBuilder.Entity<Education>()
              .HasData(
              new Education
              {
                  Id = 1,
                  University = "Örebro",
                  Orientation = "Software Engineering",
                  StartYear = 2011,
                  EndYear = 2014,
                  CvId = 1

              },
              new Education
              {
                  Id = 2,
                  University = "Mälardalens högskola",
                  Orientation = "Behaviour science",
                  StartYear = 2014,
                  EndYear = 2015,
                  CvId = 2
              },
              new Education
              {
                  Id = 3,
                  University = "Mälardalens högskola",
                  Orientation = "Nuclear safety",
                  StartYear = 2015,
                  EndYear = 2020,
                  CvId = 2
              },
              new Education
              {
                  Id = 4,
                  University = "Mälardalens högskola",
                  Orientation = "Finding Neverland",
                  StartYear = 2014,
                  EndYear = 2020,
                  CvId = 3
              },
              new Education
              {
                  Id = 5,
                  University = "Townville",
                  Orientation = "Lab science",
                  StartYear = 2000,
                  EndYear = 2006,
                  CvId = 4
              },
              new Education
              {
                  Id = 6,
                  University = "Townville",
                  Orientation = "Lab assistent",
                  StartYear = 2007,
                  EndYear = 2008,
                  CvId = 4
              }
              );

            modelBuilder.Entity<Experience>()
              .HasData(
              new Experience
              {
                  Id = 1,
                  Employer = "PN",
                  Title = "Customs Administrator",
                  StartYear = 2015,
                  EndYear = 2021,
                  CvId = 1
              },
              new Experience
              {
                  Id = 2,
                  Employer = "Happy-Go-Lucky",
                  Title = "Senior developer",
                  StartYear = 2021,
                  EndYear = 2022,
                  CvId = 1
              },
              new Experience
              {
                  Id = 3,
                  Employer = "Power Plant",
                  Title = "Inspector",
                  StartYear = 2016,
                  EndYear = 2022,
                  CvId = 2
              },
              new Experience
              {
                  Id = 4,
                  Employer = "Öppenvård",
                  Title = "Kurator",
                  StartYear = 2020,
                  EndYear = 2022,
                  CvId = 3
              },
              new Experience
              {
                  Id = 5,
                  Employer = "Professor Utonium",
                  Title = "Lab assistent",
                  StartYear = 2009,
                  EndYear = 2022,
                  CvId = 4
              }
              );






        }

        public DbSet<CVproject.Models.Project> Project { get; set; }


    }
}
