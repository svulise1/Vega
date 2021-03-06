using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Persistence
{
    public class vegaDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vechile> Vechiles { get; set; }
        public vegaDbContext(DbContextOptions<vegaDbContext> options)
                : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // adding composite primary key 
            modelbuilder.Entity<VechileFeature>().HasKey(vf => new { vf.VechileId, vf.FeatureId });

        }
    }
}
