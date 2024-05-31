using ACME.Core.Entities;
using ACME.Core.Interfaces.ExternalService;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;
using Moq;
using System.Runtime.InteropServices;

namespace ACME.Test.ContractCourseTests;

public class RegisterContractCourseFailedXErrorPay : BaseTest
{
    private IContractCourseService _contractCourseService;
    private IStudentService _studentService;
    private ICourseService _courseService;
    private ContractCourse _contractCourse;
    private Student _student;
    private Course _course;
    private Mock<IPaymentService> _mockPaymentService;
    private Exception _exception;
    protected override void Given()
    {
        _studentService = new StudentService();
        _courseService = new CourseService();

        _student = _studentService.RegisterStudent("Hermenegildo", 22);
        _course = _courseService.RegisterCourse("Matemáticas", 50, DateTime.Now.AddDays(20), DateTime.Now.AddDays(40));

        _mockPaymentService = new();
        _mockPaymentService.Setup(p => p.Pay(It.IsAny<object>())).Returns(false);
        _contractCourseService = new ContractCourseService(_mockPaymentService.Object);
    }

    protected override void When()
    {
        try
        {
            _contractCourse = _contractCourseService.ContractCourse(_student.Id, _course.Id, 60);
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
        _exception.Should().BeOfType<ExternalException>();
        _exception.Message.Should().Be("An error occurred while trying to make the payment");
    }
}
