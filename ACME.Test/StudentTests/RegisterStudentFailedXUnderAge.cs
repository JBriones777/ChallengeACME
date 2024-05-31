using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.StudentTests;

public class RegisterStudentFailedXUnderAge : BaseTest
{
    private IStudentService _studentService;
    private Exception _exception;
    protected override void Given()
    {
        _studentService = new StudentService();
    }

    protected override void When()
    {
        try
        {
            _ = _studentService.RegisterStudent("Rufino", 17);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Fact]
    public void Then_Failed()
    {
        _exception.Should().NotBeNull();
        _exception.Should().BeOfType<InvalidOperationException>();
        _exception.Message.Should().Be("Only adults can register.");
    }
}
