using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.ContractCourseTests;

public class RegisterContractCourseFailedXStudentNotFound : BaseTest
{
    private IContractCourseService _contractCourseService;
    private ICourseService _courseService;
    private ContractCourse _contractCourse;
    private Course _course;
    private Exception _exception;
    protected override void Given()
    {
        _contractCourseService = new ContractCourseService();
        _courseService = new CourseService();
        _course = _courseService.RegisterCourse("Matemáticas", 50, DateTime.Now.AddDays(20), DateTime.Now.AddDays(40));
    }

    protected override void When()
    {
        try
        {
            _contractCourse = _contractCourseService.ContractCourse(new Guid(), _course.Id, 50);
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
        _exception.Should().BeOfType<KeyNotFoundException>();
        _exception.Message.Should().Be("Student not found");
    }
}
