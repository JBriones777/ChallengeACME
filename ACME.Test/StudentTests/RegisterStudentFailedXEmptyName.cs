using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.StudentTests;

public class RegisterStudentFailedXEmptyName : BaseTest
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
            _ = _studentService.RegisterStudent(string.Empty, 18);
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
        _exception.Should().BeOfType<ArgumentNullException>();
        _exception.Message.Should().Be("Value cannot be null. (Parameter 'name')");
    }
}
