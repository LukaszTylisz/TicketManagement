using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

public class GetTicketRequestListQueryHandler(
    ITicketRequestRepository ticketRequestRepository,
    IMapper mapper,
    IUserService userService)
    : IRequestHandler<GetTicketRequestListQuery, List<TicketRequestListDto>>
{
    public async Task<List<TicketRequestListDto>> Handle(GetTicketRequestListQuery request,
        CancellationToken cancellationToken)
    {
        List<Domain.TicketRequest> ticketRequests;
        List<TicketRequestListDto> requests;

        if (request.IsLoggedInUser)
        {
            var userId = userService.UserId;
            ticketRequests = await ticketRequestRepository.GetTicketWithDetails(userId);

            var client = await userService.GetClient(userId);
            requests = mapper.Map<List<TicketRequestListDto>>(ticketRequests);
            foreach (var req in requests)
            {
                req.Clients = client;
            }
        }
        else
        {
            ticketRequests = await ticketRequestRepository.GetTicketWithDetails();
            requests = mapper.Map<List<TicketRequestListDto>>(ticketRequests);
            foreach (var req in requests)
            {
                req.Clients = await userService.GetClient(req.RequestingClientId);
            }
        }

        return requests;
    }
}