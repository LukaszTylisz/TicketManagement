using Microsoft.AspNetCore.Identity;

namespace FootballTicketManagement.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}