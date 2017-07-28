using System.Data.Entity;
using EventPoint.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventPoint.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public  DbSet<Genre> Genres { get; set; }
        public  DbSet<Event> Events { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}