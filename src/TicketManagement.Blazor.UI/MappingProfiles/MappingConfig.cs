using AutoMapper;
using TicketManagement.Blazor.UI.Models;
using TicketManagement.Blazor.UI.Models.TicketAllocations;
using TicketManagement.Blazor.UI.Models.TicketRequests;
using TicketManagement.Blazor.UI.Models.TicketTypes;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<TicketTypeDto, TicketTypeVm>().ReverseMap();
        CreateMap<TicketTypeDetailsDto, TicketTypeVm>().ReverseMap();
        CreateMap<CreateTicketTypeCommand, TicketTypeVm>().ReverseMap();
        CreateMap<UpdateTicketTypeCommand, TicketTypeVm>().ReverseMap();

        CreateMap<TicketRequestListDto, TicketRequestVm>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();
        CreateMap<TicketRequestDetailsDto, TicketRequestVm>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();

        CreateMap<CreateTicketRequestCommand, TicketRequestVm>().ReverseMap();
        CreateMap<UpdateTicketRequestCommand, TicketRequestVm>().ReverseMap();

        CreateMap<TicketAllocationDto, TicketAllocationVm>().ReverseMap();
        CreateMap<TicketAllocationsDetailsDto, TicketAllocationVm>().ReverseMap();
        CreateMap<CreateTicketAllocationCommand, TicketAllocationVm>().ReverseMap();
        CreateMap<UpdateTicketAllocationCommand, TicketAllocationVm>().ReverseMap();

        CreateMap<ClientVm, Clients>().ReverseMap();
    }
}