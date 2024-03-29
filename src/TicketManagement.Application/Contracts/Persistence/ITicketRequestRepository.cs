﻿using TicketManagement.Domain;

namespace TicketManagement.Application.Contracts.Persistence;

public interface ITicketRequestRepository : IGenericRepository<TicketRequest>
{
    Task<TicketRequest> GetTicketWithDetails(int id);
    Task<List<TicketRequest>> GetTicketWithDetails();
    Task<List<TicketRequest>> GetTicketWithDetails(string userId);
}