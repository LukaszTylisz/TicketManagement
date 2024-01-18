using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

public class GetTicketRequestListQueryHandler : IRequestHandler<GetTicketRequestListQuery, List<TicketRequestListDto>>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetTicketRequestListQueryHandler(ITicketRequestRepository ticketRequestRepository, IMapper mapper,
        IUserService userService)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
        this._userService = userService;
    }

    public async Task<List<TicketRequestListDto>> Handle(GetTicketRequestListQuery request,
        CancellationToken cancellationToken)
    {
        var ticketRequests = new List<Domain.TicketRequest>();
        var requests = new List<TicketRequestListDto>();

        if (request.IsLoggedInUser)
        {
            var userId = _userService.UserId;
            ticketRequests = await _ticketRequestRepository.GetTicketWithDetails(userId);

            var client = await _userService.GetClient(userId);
            requests = _mapper.Map<List<TicketRequestListDto>>(ticketRequests);
            foreach (var req in requests)
            {
                req.Client = client;
            }
        }
        else
        {
            ticketRequests = await _ticketRequestRepository.GetTicketWithDetails();
            requests = _mapper.Map<List<TicketRequestListDto>>(ticketRequests);
            foreach (var req in requests)
            {
                req.Client = await _userService.GetClient(req.RequestingClientId);
            }
        }

        return requests;
    }
}