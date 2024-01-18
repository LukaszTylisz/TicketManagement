using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;

public class GetTicketRequestDetailQueryHandler : IRequestHandler<GetTicketRequestDetailQuery, TicketRequestDetailsDto>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetTicketRequestDetailQueryHandler(ITicketRequestRepository ticketRequestRepository, IMapper mapper,
        IUserService userService)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<TicketRequestDetailsDto> Handle(GetTicketRequestDetailQuery request,
        CancellationToken cancellationToken)
    {
        var ticketRequest = _mapper.Map<TicketRequestDetailsDto>(
            await _ticketRequestRepository.GetTicketWithDetails(request.Id));

        if (ticketRequest == null)
            throw new NotFoundException(nameof(Domain.TicketType), request.Id);

        ticketRequest.Client = await _userService.GetClient(ticketRequest.RequestingClientId);

        return ticketRequest;
    }
}