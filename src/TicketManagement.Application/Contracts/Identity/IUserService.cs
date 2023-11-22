using TicketManagement.Application.Models.Identity;

namespace TicketManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(string userId);
        public string UserId { get; }
    }
}
