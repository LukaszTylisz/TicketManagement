using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Models.Identity;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    public string UserId
    {
        get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid");
    }

    public async Task<Client> GetClient(string userId)
    {
        var client = await _userManager.FindByIdAsync(userId);
        return new Client
        {
            Email = client.Email,
            Id = client.Id,
            Firstname = client.FirstName,
            Lastname = client.LastName
        };
    }

    public async Task<List<Client>> GetClients()
    {
        var clients = await _userManager.GetUsersInRoleAsync("Client");
        return clients.Select(q => new Client
        {
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName
        }).ToList();
    }
}