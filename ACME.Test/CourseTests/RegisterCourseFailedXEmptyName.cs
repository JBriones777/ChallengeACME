using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.CourseTests;

public class RegisterCourseFailedXEmptyName : BaseTest
{
    private ICourseService _courseService;
    private Exception _exception;
    protected override void Given()
    {
        _courseService = new CourseService();
    }

    protected override void When()
    {
        try
        {
            _ = _courseService.RegisterCourse(string.Empty, 80, DateTime.Now.AddDays(1), DateTime.Now.AddDays(40));
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
