using System.Data.Entity;
using IssueTracker.Web.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IssueTracker.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<LogAction> Logs { get; set; }

        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}