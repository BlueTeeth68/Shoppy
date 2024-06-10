using Core.Test;
using Moq;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Application.Test;

public class TestBase : CoreTestBase
{
    protected readonly Mock<IUnitOfWork> UnitOfWorkMock;

    public TestBase()
    {
        UnitOfWorkMock = new Mock<IUnitOfWork>();
    }
}