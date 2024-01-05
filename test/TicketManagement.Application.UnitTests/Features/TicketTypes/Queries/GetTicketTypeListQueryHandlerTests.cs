using AutoMapper;
using Moq;
using Shouldly;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;
using TicketManagement.Application.MappingProfiles;
using TicketManagement.Application.UnitTests.Mocks;

namespace TicketManagement.Application.UnitTests.Features.TicketTypes.Queries;
public class GetTicketTypeListQueryHandlerTests
{
    private readonly Mock<ITicketTypeRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetTicketTypeQueryHandler>> _logger;

    public GetTicketTypeListQueryHandlerTests()
    {
        _mockRepo = MockTicketTypeRepository.GetMockTicketTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<TicketTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _logger = new Mock<IAppLogger<GetTicketTypeQueryHandler>>();
    }

    [Fact]
    public async Task GetTicketTypeListTest()
    {
        var handler = new GetTicketTypeQueryHandler(_mapper, _mockRepo.Object, _logger.Object);

        var result = await handler.Handle(new GetTicketTypeQuery(), CancellationToken.None);

        result
            .ShouldBeOfType<List<TicketTypeDto>>();

        result
            .Count
            .ShouldBe(3);
    }
}