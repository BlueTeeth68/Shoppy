using AutoFixture;
using MediatR;
using Moq;

namespace WebApi.Test;

public class TestBase
{
    protected readonly Fixture Fixture;
    protected readonly Mock<IMediator> MediatorMock;

    public TestBase()
    {
        Fixture = new Fixture();
        Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        
        MediatorMock = new Mock<IMediator>();
    }
}