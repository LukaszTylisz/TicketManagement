﻿using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;

public class GetTicketTypeDetailsQueryHandler : IRequestHandler<GetTicketTypeDetailsQuery, TicketTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public GetTicketTypeDetailsQueryHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
    }
    public async Task<TicketTypeDetailsDto> Handle(GetTicketTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var ticketType = await _ticketTypeRepository.GetByIdAsync(request.id) ??
                         throw new NotFoundException(nameof(TicketType), request.id);
        
        var data = _mapper.Map<TicketTypeDetailsDto>(ticketType);

        return data;
    }
}