using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.ContractCourseTests;

public class RegisterContractCourseSuccess : BaseTest
{
    private IContractCourseService _contractCourseService;
    private IStudentService _studentService;
    private ICourseService _courseService;
    private ContractCourse _contractCourse;
    private Student _student;
    private Course _course;
    protected override void Given()
    {
        _contractCourseService = new ContractCourseService();
        _studentService = new StudentService();
        _courseService = new CourseService();
        _student = _studentService.RegisterStudent("Hermenegildo", 22);
        _course = _courseService.RegisterCourse("Matemáticas", 50, DateTime.Now.AddDays(20), DateTime.Now.AddDays(40));
    }

    protected override void When()
    {
        _contractCourse = _contractCourseService.ContractCourse(_student.Id, _course.Id, 50);
    }

    [Fact]
    public void Then_Success()
    {
        _contractCourse.Should().NotBeNull();
        _contractCourse?.Id.Should().NotBeEmpty();
    }
}
