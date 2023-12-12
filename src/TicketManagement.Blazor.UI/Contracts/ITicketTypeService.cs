using TicketManagement.Blazor.UI.Models.TicketTypes;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Contracts;

public interface ITicketTypeService
{
    Task<List<TicketTypeVM>> GetTicketTypes();
    Task<TicketTypeVM> GetTicketTypeDetails(int id);
    Task<Response<Guid>> CreateTicketType(TicketTypeVM ticketType);
    Task<Response<Guid>> UpdateTicketType(int Id, TicketTypeVM ticketType);
    Task<Response<Guid>> DeleteTicketType(int Id);
}