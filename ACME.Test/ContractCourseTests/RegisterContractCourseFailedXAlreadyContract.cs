using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.ContractCourseTests;

public class RegisterContractCourseFailedXAlreadyContract : BaseTest
{
    private IContractCourseService _contractCourseService;
    private IStudentService _studentService;
    private ICourseService _courseService;
    private ContractCourse _contractCourse;
    private Student _student;
    private Course _course;
    private Exception _exception;
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
        try
        {
            _contractCourse = _contractCourseService.ContractCourse(_student.Id, _course.Id, 50);
            _contractCourse = _contractCourseService.ContractCourse(_student.Id, _course.Id, 50);
        }
        catch (Exception ex)
        {
            _exception= ex;
        }
    }

    [Fact]
    public void Then_Failed()
    {
        _exception.Should().NotBeNull();
        _exception.Should().BeOfType<InvalidOperationException>();
        _exception.Message.Should().Be("You have already contract the course");
    }
}
