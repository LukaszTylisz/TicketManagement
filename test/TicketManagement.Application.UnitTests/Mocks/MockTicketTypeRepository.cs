using Moq;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Domain;

namespace TicketManagement.Application.UnitTests.Mocks;
public class MockTicketTypeRepository
{
    public static Mock<ITicketTypeRepository> GetMockTicketTypeRepository()
    {
        var ticketTypes = new List<TicketType>
        {
            new TicketType
            {
                Id = 1,
                DefaultDays = 15,
                Name = "Test Ticket"
            },
             new TicketType
                {
                    Id = 2,
                    DefaultDays = 10,
                    Name = "Train Ticket"
                },
                new TicketType
                {
                    Id = 3,
                    DefaultDays = 30,
                    Name = "Bus Ticket"
                }
        };

        var mockRepo = new Mock<ITicketTypeRepository>();

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(ticketTypes);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<TicketType>()))
            .Returns((TicketType ticketType) =>
            {
                ticketTypes.Add(ticketType);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.IsTicketUnique(It.IsAny<string>()))
            .ReturnsAsync((string name) =>
            {
                return !ticketTypes.Any(q => q.Name == name);
            });

        return mockRepo;
    }
}