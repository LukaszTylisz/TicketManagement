﻿using MediatR;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Change;

public class ChangeTicketRequestResolvedCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public bool Resolved { get; set; }
}