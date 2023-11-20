using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;

public class GetTicketRequestDetailQueryHandler : IRequestHandler<GetTicketRequestDetailQuery, TicketRequestDetailsDto>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;

    public GetTicketRequestDetailQueryHandler(ITicketRequestRepository ticketRequestRepository, IMapper mapper)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
    }
    public async Task<TicketRequestDetailsDto> Handle(GetTicketRequestDetailQuery request, CancellationToken cancellationToken)
    {
        var ticketRequest = _mapper.Map<TicketRequestDetailsDto>(
            await _ticketRequestRepository.GetTicketWithDetails(request.Id));

        if (ticketRequest == null)
            throw new NotFoundException(nameof(Domain.TicketType), request.Id);

        return ticketRequest;
    }
}