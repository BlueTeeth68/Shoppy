using AutoFixture;

namespace Core.Test;

public class CoreTestBase
{
    protected readonly Fixture Fixture;

    public CoreTestBase()
    {
        Fixture = new Fixture();
        Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        
    }
}