using AutoMapper;
using FootballTicketManagement.Application.Features.TicketAllocation.Commands.Create;
using FootballTicketManagement.Application.Features.TicketAllocation.Commands.Update;
using FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;
using FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;
using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.MappingProfiles;

public class TicketAllocationProfile : Profile
{
    public TicketAllocationProfile()
    {
        CreateMap<TicketAllocationDto, TicketAllocation>().ReverseMap();
        CreateMap<TicketAllocation, TicketAllocationsDetailsDto>();
        CreateMap<CreateTicketAllocationCommand, TicketAllocation>();
        CreateMap<UpdateTicketAllocationCommand, TicketAllocation>();
    }   
}