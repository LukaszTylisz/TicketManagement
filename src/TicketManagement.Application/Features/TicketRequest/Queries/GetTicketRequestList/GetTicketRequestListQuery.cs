﻿using MediatR;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

public class GetTicketRequestListQuery : IRequest<List<TicketRequestListDto>>
{
    public bool IsLoggedInUser { get; set; }
}