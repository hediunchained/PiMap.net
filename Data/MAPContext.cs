using Microsoft.AspNet.Identity.EntityFramework;
using Domain.Entity;
using System.Data.Entity;

namespace Data
{
   public class MAPContext : IdentityDbContext<Users, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public static MAPContext Create()
        {
            return new MAPContext();
        }

        static MAPContext()
        {
            Database.SetInitializer<MAPContext>(null);
        }
        public MAPContext() : base("name=DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Ressource>().ToTable("Ressource");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Projet>().ToTable("Projet");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Application_Lettre>().ToTable("Application_Lettre");
            modelBuilder.Entity<Mandate>().ToTable("Mandate");
            modelBuilder.Entity<Organizational_chart>().ToTable("Organiational_chart");

            //// Configure StudentId as FK for StudentAddress

            //modelBuilder.Entity<Client>()
            //            .HasRequired(s => s.Organizational_chart)
            //            .WithRequiredPrincipal(ad => ad.Client);
            ////modelBuilder.Entity<Message>()
            ////            .HasRequired(s => s.Client)
            ////            .WithRequiredPrincipal(ad => ad.Message);
            //modelBuilder.Entity<Message>()
            //            .HasRequired(s => s.Ressource)
            //            .WithRequiredPrincipal(ad => ad.Message);
            //modelBuilder.Entity<Application_Lettre>()
            //           .HasRequired(s => s.Ressource)
            //           .WithRequiredPrincipal(ad => ad.Application_Lettre);
            //modelBuilder.Entity<Organizational_chart>()
            //          .HasRequired(s => s.Projet)
            //          .WithRequiredPrincipal(ad => ad.Organizational_chart);



        }
        public DbSet<Application_Lettre> Application_Lettre { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Mandate> Mandate { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Organizational_chart> Organizational_chart { get; set; }
        public DbSet<Projet> Projet { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Ressource> Ressource { get; set; }
      


    }
}
