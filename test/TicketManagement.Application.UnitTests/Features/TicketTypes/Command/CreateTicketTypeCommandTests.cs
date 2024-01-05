using AutoMapper;
using Moq;
using Shouldly;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Features.TicketType.Commands.Create;
using TicketManagement.Application.MappingProfiles;
using TicketManagement.Application.UnitTests.Mocks;

namespace TicketManagement.Application.UnitTests.Features.TicketTypes.Command;
public class CreateTicketTypeCommandTests
{
    private readonly IMapper _mapper;
    private Mock<ITicketTypeRepository> _mockRepo;

    public CreateTicketTypeCommandTests()
    {
        _mockRepo = MockTicketTypeRepository.GetMockTicketTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<TicketTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidTicketType()
    {
        var handler = new CreateTicketTypeCommandHandler(_mapper, _mockRepo.Object);

        await handler.Handle(new CreateTicketTypeCommand()
        {
            Name = "Test1",
            DefaultDays = 1
        }, CancellationToken.None);

        var ticketTypes = await _mockRepo.Object.GetAsync();
        ticketTypes.Count.ShouldBe(4);
    }
}