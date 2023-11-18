using AutoMapper;
using FootballTicketManagement.Application.Features.TicketType.Commands.Create;
using FootballTicketManagement.Application.Features.TicketType.Commands.Update;
using FootballTicketManagement.Application.Features.TicketType.Queries.GetAllTickets;
using FootballTicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;
using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.MappingProfiles;

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