using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Entities.Configuration;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<SocialStatus> SocialStatuses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<OwnerStatus> OwnerStatuses { get; set; }
        public DbSet<CardOwner> CardOwners { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            AddStoredProcedures();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurations(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new CardOwnerConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerStatusConfiguration());
            modelBuilder.ApplyConfiguration(new SocialStatusConfiguration());
        }

        private void AddStoredProcedures()
        {
            TryToExecQuery(StoredProcedures.GetAccountsWithoutCards);
        }

        private void TryToExecQuery(string query)
        {
            try 
            { 
                this.Database.ExecuteSqlRaw(query); 
            }
            catch { }
        }
    }
}
