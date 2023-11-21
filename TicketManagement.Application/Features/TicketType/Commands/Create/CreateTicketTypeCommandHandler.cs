using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Commands.Create;

public class CreateTicketTypeCommandHandler : IRequestHandler<CreateTicketTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public CreateTicketTypeCommandHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
    }

    public async Task<int> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        //validate incoming data
        var validator = new CreateTicketTypeCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid LeadType", validationResult);

        // convert to domain entity object
        var ticketTypeToCreate = _mapper.Map<Domain.TicketType>(request);

        // add to database
        await _ticketTypeRepository.CreateAsync(ticketTypeToCreate);

        return ticketTypeToCreate.Id;


    }
}