using MediatR;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Create;

public class CreateTicketAllocationCommandHandler(
    ITicketAllocationRepository ticketAllocationRepository,
    ITicketTypeRepository ticketTypeRepository,
    IUserService userService) : IRequestHandler<CreateTicketAllocationCommand, Unit>
{
    public async Task<Unit> Handle(CreateTicketAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTicketAllocationCommandValidator(ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Ticket Allocation Request", validationResult);

        // Get Ticket Type for Allocations
        var ticketType = await ticketTypeRepository.GetByIdAsync(request.TicketTypeId);

        var clients = await userService.GetClients();

        // Get Period
        var period = DateTime.Now.Year;

        // Assign Allocations IF an Allocation doesn't already exist for period and Ticket Type
        var allocations = new List<Domain.TicketAllocation>();
        foreach (var client in clients)
        {
            var allocationExists =
                await ticketAllocationRepository.AllocationExists(client.Id, request.TicketTypeId, period);

            if (allocationExists == false)
            {
                allocations.Add(new Domain.TicketAllocation
                {
                    ClientId = client.Id,
                    TicketTypeId = ticketType.Id,
                    NumberOfDays = ticketType.DefaultDays,
                    Period = period
                });
            }
        }

        if (allocations.Any())
        {
            await ticketAllocationRepository.AddAllocations(allocations);
        }

        return Unit.Value;
    }
}