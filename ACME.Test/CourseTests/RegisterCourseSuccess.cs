using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.CourseTests;

public class RegisterCourseSuccess : BaseTest
{
    private ICourseService _courseService;
    private Course _course;
    protected override void Given()
    {
        _courseService = new CourseService();
    }

    protected override void When()
    {
        _course = _courseService.RegisterCourse("Matemáticas", 50, DateTime.Now.AddDays(20), DateTime.Now.AddDays(40));
    }

    [Fact]
    public void Then_Success()
    {
        _course.Should().NotBeNull();
        _course?.Id.Should().NotBeEmpty();
    }

}
