using Entities.Models;
using Microsoft.EntityFrameworkCore;

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
