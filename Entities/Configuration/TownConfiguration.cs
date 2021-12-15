using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasData(
                new Town
                {
                    Id = new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0"),
                    Name = "Полоцк"
                },
                new Town
                {
                    Id = new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4"),
                    Name = "Новополоцк"
                },
                new Town
                {
                    Id = new Guid("76fc6ed2-cb47-46c1-bd18-eb4ae0990bd3"),
                    Name = "Минск"
                },
                new Town
                {
                    Id = new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970"),
                    Name = "Витебск"
                },
                new Town
                {
                    Id = new Guid("e89e58ea-0e90-497a-af2e-b034a4057332"),
                    Name = "Могилёв"
                }
            );
        }
    }
}
