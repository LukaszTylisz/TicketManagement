using AutoMapper;
using TicketManagement.Application.Features.TicketType.Commands.Create;
using TicketManagement.Application.Features.TicketType.Commands.Update;
using TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;
using TicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;
using TicketManagement.Domain;

namespace TicketManagement.Application.MappingProfiles;

public class TicketTypeProfile : Profile
{
    public TicketTypeProfile()
    {
        CreateMap<TicketTypeDto, TicketType>().ReverseMap();
        CreateMap<TicketType, TicketTypeDetailsDto>();
        CreateMap<CreateTicketTypeCommand, TicketType>();
        CreateMap<UpdateTicketTypeCommand, TicketType>();
    }
}