using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Entities.Configuration;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AccountConfiguration());
            //modelBuilder.ApplyConfiguration(new BankBranchConfiguration());
            //modelBuilder.ApplyConfiguration(new BankConfiguration());
            //modelBuilder.ApplyConfiguration(new CardConfiguration());
            //modelBuilder.ApplyConfiguration(new CardOwnerConfiguration());
            //modelBuilder.ApplyConfiguration(new OwnerStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new SocialStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new TownConfiguration());
        }

        public DbSet<Town> Towns { get; set; }
        public DbSet<SocialStatus> SocialStatuses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<OwnerStatus> OwnerStatuses { get; set; }
        public DbSet<CardOwner> CardOwners { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
    }
}
