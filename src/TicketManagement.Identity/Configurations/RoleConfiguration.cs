using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "96F9A056-534F-4147-9A68-FF8C2A08E139",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "CB53D9FE-5115-4B61-8D4B-2345F92A5761",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}