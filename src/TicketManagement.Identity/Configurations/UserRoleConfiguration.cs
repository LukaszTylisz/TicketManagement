using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "CB53D9FE-5115-4B61-8D4B-2345F92A5761",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "96F9A056-534F-4147-9A68-FF8C2A08E139",
                    UserId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                }
            );
        }
    }
}
