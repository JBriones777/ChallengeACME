using ACME.Core.Entities;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.StudentTests;

public class RegisterCourseSuccessTest : BaseTest
{
    private IStudentService _studentService;
    private Student _student;
    protected override void Given()
    {
        _studentService = new StudentService();
    }

    protected override void When()
    {
        _student = _studentService.RegisterStudent("Hermenegildo", 22);
    }

    [Fact]
    public void Then_Success()
    {
        _student.Should().NotBeNull();
        _student?.Id.Should().NotBeEmpty();
    }

}
