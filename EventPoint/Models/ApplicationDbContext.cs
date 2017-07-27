using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventPoint.Models
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
    }
}