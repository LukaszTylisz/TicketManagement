using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Domain;
using TicketManagement.Persistence.DatabaseContext;

namespace TicketManagement.Persistence.IntegrationTests;

public class TicketManagementContextTests
{
    private TicketManagementDatabaseContext _databaseContext;
    private readonly string _userId;
    private readonly Mock<IUserService> _userServiceMock;

    public TicketManagementContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<TicketManagementDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        _userId = "00000000-0000-0000-0000-000000000000";
        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(m => m.UserId).Returns(_userId);

        _databaseContext = new TicketManagementDatabaseContext(dbOptions, _userServiceMock.Object);
    }

    [Fact]
    public async void Save_SetDateCreatedValue()
    {
        //Arrange
        var ticketTypes = new TicketType()
        {
            Id = 1,
            DefaultDays = 20,
            Name = "Bus Ticket"
        };
        
        //Act
        await _databaseContext.TicketTypes.AddAsync(ticketTypes);
        await _databaseContext.SaveChangesAsync();
        
        //Assert
        ticketTypes.DateCreated.ShouldNotBeNull();
    }
    
    [Fact]
    public async void Save_SetDateModifiedValue()
    {
        //Arrange
        var ticketTypes = new TicketType()
        {
            Id = 1,
            DefaultDays = 20,
            Name = "Bus Ticket"
        };
        
        //Act
        await _databaseContext.TicketTypes.AddAsync(ticketTypes);
        await _databaseContext.SaveChangesAsync();
        
        //Assert
        ticketTypes.DateCreated.ShouldNotBeNull();
    }
}