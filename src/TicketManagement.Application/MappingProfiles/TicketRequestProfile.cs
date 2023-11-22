using AutoMapper;
using TicketManagement.Application.Features.TicketRequest.Commands.Create;
using TicketManagement.Application.Features.TicketRequest.Commands.Update;
using TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;
using TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;
using TicketManagement.Domain;

namespace TicketManagement.Application.MappingProfiles;

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