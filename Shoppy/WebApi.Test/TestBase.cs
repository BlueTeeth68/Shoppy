using MediatR;
using Moq;

namespace WebApi.Test;

public class TestBase : Core.Test.CoreTestBase
{
    protected readonly Mock<IMediator> MediatorMock;

    public TestBase()
    {
        MediatorMock = new Mock<IMediator>();
    }
}