namespace ACME.Test.Helpers;

public abstract class BaseTest
{
    protected BaseTest()
    {
        Given();
        When();
    }
    protected abstract void Given();
    protected abstract void When();
}
