using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class BankBranchConfiguration : IEntityTypeConfiguration<BankBranch>
    {
        public void Configure(EntityTypeBuilder<BankBranch> builder)
        {
            builder.HasData(
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"),
                    IdTown = new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"),
                    IdTown = new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930"),
                    IdTown = new Guid("76fc6ed2-cb47-46c1-bd18-eb4ae0990bd3")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"),
                    IdTown = new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"),
                    IdTown = new Guid("e89e58ea-0e90-497a-af2e-b034a4057332")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"),
                    IdTown = new Guid("e89e58ea-0e90-497a-af2e-b034a4057332")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"),
                    IdTown = new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"),
                    IdTown = new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4")
                },
                new BankBranch
                {
                    Id = Guid.NewGuid(),
                    IdBank = new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"),
                    IdTown = new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0")
                }
            );
        }
    }
}
