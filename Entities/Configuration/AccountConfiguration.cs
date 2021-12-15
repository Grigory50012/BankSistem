using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    Id = new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438"),
                    Balance = 10,
                    IdCardOwner = new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"),
                    IdBank = new Guid("6a38147d-92e0-43b8-8006-46649f9f6661")
                },
                new Account
                {
                    Id = new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca"),
                    Balance = 20,
                    IdCardOwner = new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"),
                    IdBank = new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46")
                },
                new Account
                {
                    Id = new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6"),
                    Balance = 30,
                    IdCardOwner = new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"),
                    IdBank = new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930")
                },
                new Account
                {
                    Id = new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d"),
                    Balance = 40,
                    IdCardOwner = new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"),
                    IdBank = new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73")
                },
                new Account
                {
                    Id = new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805"),
                    Balance = 50,
                    IdCardOwner = new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"),
                    IdBank = new Guid("484426b9-677b-470b-b6b6-95c65b4efa32")
                },
                new Account
                {
                    Id = new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3"),
                    Balance = 60,
                    IdCardOwner = new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"),
                    IdBank = new Guid("484426b9-677b-470b-b6b6-95c65b4efa32")
                },
                new Account
                {
                    Id = new Guid("8c961fbe-9316-41b0-913c-6fed6977d479"),
                    Balance = 70,
                    IdCardOwner = new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"),
                    IdBank = new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73")
                }
            );
        }
    }
}
