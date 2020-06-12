using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TermWithSynonyms> TermsWithSynonyms { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TermWithSynonyms>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
