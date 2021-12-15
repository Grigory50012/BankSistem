using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasData(
                new Bank
                {
                    Id = new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"),
                    Name = "Белинвестбанк"
                },
                new Bank
                {
                    Id = new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"),
                    Name = "Белагропромбанк"
                },
                new Bank
                {
                    Id = new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930"),
                    Name = "Беларусбанк"
                },
                new Bank
                {
                    Id = new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"),
                    Name = "Приорбанк"
                },
                new Bank
                {
                    Id = new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"),
                    Name = "ВТБбанк"
                }
            );
        }
    }
}
