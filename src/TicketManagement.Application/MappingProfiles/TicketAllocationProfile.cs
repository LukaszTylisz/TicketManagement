using AutoMapper;
using TicketManagement.Application.Features.TicketAllocation.Commands.Create;
using TicketManagement.Application.Features.TicketAllocation.Commands.Update;
using TicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;
using TicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;
using TicketManagement.Domain;

namespace TicketManagement.Application.MappingProfiles;

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