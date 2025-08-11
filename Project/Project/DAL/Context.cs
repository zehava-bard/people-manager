using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.DAL
{
    public class Context:DbContext
    {
        public DbSet<Person> Person { get; set; }

        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
