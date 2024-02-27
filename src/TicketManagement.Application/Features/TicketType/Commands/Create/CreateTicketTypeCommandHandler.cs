using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Commands.Create;

public class CreateTicketTypeCommandHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository)
    : IRequestHandler<CreateTicketTypeCommand, int>
{
    public async Task<int> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        //validate incoming data
        var validator = new CreateTicketTypeCommandValidator(ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid TicketType", validationResult);

        // convert to domain entity object
        var ticketTypeToCreate = mapper.Map<Domain.TicketType>(request);

        // add to database
        await ticketTypeRepository.CreateAsync(ticketTypeToCreate);

        return ticketTypeToCreate.Id;
    }
}