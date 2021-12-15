using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CardOwnerConfiguration : IEntityTypeConfiguration<CardOwner>
    {
        public void Configure(EntityTypeBuilder<CardOwner> builder)
        {
            builder.HasData(
                new CardOwner
                {
                    Id = new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"),
                    Name = "Дима"
                },
                new CardOwner
                {
                    Id = new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"),
                    Name = "Влад"
                },
                new CardOwner
                {
                    Id = new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"),
                    Name = "Гриша"
                },
                new CardOwner
                {
                    Id = new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"),
                    Name = "Саша"
                },
                new CardOwner
                {
                    Id = new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"),
                    Name = "Кирилл"
                }
            );
        }
    }
}
