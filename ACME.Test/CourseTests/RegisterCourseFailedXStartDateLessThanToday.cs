using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.CourseTests;

public class RegisterCourseFailedXStartDateLessThanToday : BaseTest
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
            _ = _courseService.RegisterCourse("Filosofía", 80, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(40));
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
        _exception.Should().BeOfType<ArgumentException>();
        _exception.Message.Should().Be("The start date cannot be less than today");
    }
}
