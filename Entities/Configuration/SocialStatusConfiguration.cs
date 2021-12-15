using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class SocialStatusConfiguration : IEntityTypeConfiguration<SocialStatus>
    {
        public void Configure(EntityTypeBuilder<SocialStatus> builder)
        {
            builder.HasData(
                new SocialStatus
                {
                    Id = new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431"),
                    Name = "Пенсионер"
                },
                new SocialStatus
                {
                    Id = new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4"),
                    Name = "Инвалид"
                },
                new SocialStatus
                {
                    Id = new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337"),
                    Name = "Ветеран"
                }
            );
        }
    }
}
