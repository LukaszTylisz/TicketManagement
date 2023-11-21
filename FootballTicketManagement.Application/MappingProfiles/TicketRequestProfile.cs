using AutoMapper;
using FootballTicketManagement.Application.Features.TicketRequest.Commands.Create;
using FootballTicketManagement.Application.Features.TicketRequest.Commands.Update;
using FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;
using FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;
using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.MappingProfiles;

public class TicketRequestProfile : Profile
{
    public TicketRequestProfile()
    {
        CreateMap<TicketRequestListDto, TicketRequest>().ReverseMap();
        CreateMap<TicketRequestDetailsDto, TicketRequest>().ReverseMap();
        CreateMap<TicketRequest, TicketRequestDetailsDto>();
        CreateMap<CreateTicketRequestCommand, TicketRequest>();
        CreateMap<UpdateTicketRequestCommand, TicketRequest>();
    }
}