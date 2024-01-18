using TicketManagement.Blazor.UI.Models.TicketTypes;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Contracts;

public interface ITicketTypeService
{
    Task<List<TicketTypeVm>> GetTicketTypes();
    Task<TicketTypeVm> GetTicketTypeDetails(int id);
    Task<Response<Guid>> CreateTicketType(TicketTypeVm ticketType);
    Task<Response<Guid>> UpdateTicketType(int Id, TicketTypeVm ticketType);
    Task<Response<Guid>> DeleteTicketType(int Id);
}