using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;

public class GetTicketRequestDetailQueryHandler(
    ITicketRequestRepository ticketRequestRepository,
    IMapper mapper,
    IUserService userService)
    : IRequestHandler<GetTicketRequestDetailQuery, TicketRequestDetailsDto>
{
    public async Task<TicketRequestDetailsDto> Handle(GetTicketRequestDetailQuery request,
        CancellationToken cancellationToken)
    {
        var ticketRequest = mapper.Map<TicketRequestDetailsDto>(
            await ticketRequestRepository.GetTicketWithDetails(request.Id));

        if (ticketRequest == null)
            throw new NotFoundException(nameof(Domain.TicketType), request.Id);

        ticketRequest.Clients = await userService.GetClient(ticketRequest.RequestingClientId);

        return ticketRequest;
    }
}