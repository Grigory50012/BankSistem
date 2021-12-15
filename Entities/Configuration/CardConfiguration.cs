using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 100,
                    IdAccount = new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 90,
                    IdAccount = new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 80,
                    IdAccount = new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 70,
                    IdAccount = new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 60,
                    IdAccount = new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 50,
                    IdAccount = new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 40,
                    IdAccount = new Guid("8c961fbe-9316-41b0-913c-6fed6977d479")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 30,
                    IdAccount = new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 20,
                    IdAccount = new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca")
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Balance = 10,
                    IdAccount = new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6")
                }
            );
        }
    }
}
