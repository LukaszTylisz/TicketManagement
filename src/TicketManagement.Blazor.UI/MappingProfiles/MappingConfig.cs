using AutoMapper;
using TicketManagement.Blazor.UI.Models.TicketTypes;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<TicketTypeDto, TicketTypeVM>().ReverseMap();
        CreateMap<CreateTicketTypeCommand, TicketTypeVM>().ReverseMap();
    }
}