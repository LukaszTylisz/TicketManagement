using TicketManagement.Application.Models.Identity;

namespace TicketManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Clients>> GetClients();
        Task<Clients> GetClient(string userId);
        public string UserId { get; }
    }
}
