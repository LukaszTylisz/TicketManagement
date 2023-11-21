using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}