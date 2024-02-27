using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;

public class GetTicketTypeDetailsQueryHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository)
    : IRequestHandler<GetTicketTypeDetailsQuery, TicketTypeDetailsDto>
{
    public async Task<TicketTypeDetailsDto> Handle(GetTicketTypeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var ticketType = await ticketTypeRepository.GetByIdAsync(request.id) ??
                         throw new NotFoundException(nameof(TicketType), request.id);

        var data = mapper.Map<TicketTypeDetailsDto>(ticketType);

        return data;
    }
}