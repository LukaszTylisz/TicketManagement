using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Models.Identity;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity.Services;

public class UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    : IUserService
{
    public string UserId
    {
        get => contextAccessor.HttpContext?.User?.FindFirstValue("uid");
    }

    public async Task<Clients> GetClient(string userId)
    {
        var client = await userManager.FindByIdAsync(userId);
        return new Clients
        {
            Email = client.Email,
            Id = client.Id,
            Firstname = client.FirstName,
            Lastname = client.LastName
        };
    }

    public async Task<List<Clients>> GetClients()
    {
        var clients = await userManager.GetUsersInRoleAsync("Client");
        return clients.Select(q => new Clients
        {
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName
        }).ToList();
    }
}