using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpyStore.Models.Entities;

namespace SpyStore.DAL.EF
{
    public class StoreContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public StoreContext() { }

        public StoreContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=SpyStore;Trusted_Connection=True;MultipleActiveResultSets=true;",
                    //options => options.ExecutionStrategy(c => new MyExecutionStrategy(c))
                    options => options.EnableRetryOnFailure()
                    );
            }
        }
    }
}
