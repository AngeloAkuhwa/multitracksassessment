using Microsoft.AspNet.Identity.EntityFramework;
using MT_API.Presentation.Model;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace MT_API.Presentation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("AppUser")
        {

        }

        public DbSet<AppUser> AppUsers {  get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in ChangeTracker.Entries<AppUser>())
            {
                switch (item.State)
                {
                    
                    case System.Data.Entity.EntityState.Added:
                        item.Entity.deteCreation = DateTime.UtcNow;   
                        break;
                   
                    case System.Data.Entity.EntityState.Modified:
                        item.Entity.dateUpdated = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);    
        }
    }
}