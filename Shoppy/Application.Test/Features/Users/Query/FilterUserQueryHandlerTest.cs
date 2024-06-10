using AutoFixture;
using Moq;
using Shoppy.Application.Features.Users.Handlers.Query;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;

namespace Application.Test.Features.Users.Query;

public class FilterUserQueryHandlerTest : TestBase
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly FilterUserQueryHandler _handler;

    public FilterUserQueryHandlerTest()
    {
        _userServiceMock = new Mock<IUserService>();
        _handler = new FilterUserQueryHandler(_userServiceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallFilterUserAsyncOnIUserService()
    {
        // Arrange
        var request = Fixture.Build<FilterUserQuery>().Create();

        var expectedResult = Fixture.Build<PagingResult<FilterUserResult>>().Create();

        _userServiceMock.Setup(s => s.FilterUserAsync(request))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResult.TotalPages, result.TotalPages);
        Assert.Equal(expectedResult.TotalRecords, result.TotalRecords);
        Assert.Equal(expectedResult.Results.Count, result.Results.Count);

        for (int i = 0; i < expectedResult.Results.Count; i++)
        {
            Assert.Equal(expectedResult.Results[i].Id, result.Results[i].Id);
            Assert.Equal(expectedResult.Results[i].FullName, result.Results[i].FullName);
        }

        _userServiceMock.Verify(s => s.FilterUserAsync(request), Times.Once);
    }
}