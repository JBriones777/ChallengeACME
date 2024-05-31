using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.ContractCourseTests;

public class RegisterContractCourseFailedXCourseNotFound : BaseTest
{
    private IContractCourseService _contractCourseService;
    private IStudentService _studentService;
    private ContractCourse _contractCourse;
    private Student _student;
    private Exception _exception;
    protected override void Given()
    {
        _contractCourseService = new ContractCourseService();
        _studentService = new StudentService();
        _student = _studentService.RegisterStudent("Hermenegildo", 22);
    }

    protected override void When()
    {
        try
        {
            _contractCourse = _contractCourseService.ContractCourse(_student.Id, new Guid(), 50);
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
        _exception.Message.Should().Be("Course not found");
    }
}
