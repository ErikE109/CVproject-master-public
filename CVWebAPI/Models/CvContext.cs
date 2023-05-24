using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;

namespace CVWebAPI.Models
{
    
    public class CvContext : DbContext
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
                IConfigurationRoot root = builder.Build();
            
                var connectionString = root.GetConnectionString("CVprojectContext");
                optionsBuilder.UseSqlServer(connectionString); 
            }
        }

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

         




        }

        public DbSet<CVWebAPI.Models.Project> Project { get; set; }


    }
}
