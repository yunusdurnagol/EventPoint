using EventPoint.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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
        public  DbSet<Attendance> Attendances { get; set; }
        public DbSet<Takipci> Takipcis { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new FollowingConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }

   
}