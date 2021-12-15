using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class OwnerStatusConfiguration : IEntityTypeConfiguration<OwnerStatus>
    {
        public void Configure(EntityTypeBuilder<OwnerStatus> builder)
        {
            builder.HasData(
                new OwnerStatus
                {
                    Id = Guid.NewGuid(),
                    IdCardOwner = new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"),
                    IdSocialStatus = new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431")
                },
                new OwnerStatus
                {
                    Id = Guid.NewGuid(),
                    IdCardOwner = new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"),
                    IdSocialStatus = new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4")
                },
                new OwnerStatus
                {
                    Id = Guid.NewGuid(),
                    IdCardOwner = new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"),
                    IdSocialStatus = new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337")
                },
                new OwnerStatus
                {
                    Id = Guid.NewGuid(),
                    IdCardOwner = new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"),
                    IdSocialStatus = new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431")
                }, new OwnerStatus
                {
                    Id = Guid.NewGuid(),
                    IdCardOwner = new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"),
                    IdSocialStatus = new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4")
                }
            );
        }
    }
}
