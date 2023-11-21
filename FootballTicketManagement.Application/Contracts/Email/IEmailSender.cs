using FootballTicketManagement.Application.Models.Email;

namespace FootballTicketManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}