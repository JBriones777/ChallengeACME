using ACME.Core.CustomEntity;
using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.ContractCourseTests;

public class ListContractCourseFailedXStartDateGreaterThanEndDate : BaseTest
{
    private IContractCourseService _contractCourseService;
    private IStudentService _studentService;
    private ICourseService _courseService;
    private List<Student> _students;
    private List<Course> _courses;
    private PaginationInfo<ContractCourse> _contractCourseList;
    private Exception _exception;
    protected override void Given()
    {
        _contractCourseService = new ContractCourseService();
        _studentService = new StudentService();
        _courseService = new CourseService();
        _students = new();
        _courses = new();

        for (int i = 0; i < 10; i++)
        {
            _students.Add(_studentService.RegisterStudent($"Griselda_{i}", 22 + i));
        }

        for (int i = 1; i <= 20; i++)
        {
            _courses.Add(_courseService.RegisterCourse($"Programación_{i}", 50, DateTime.Now.AddDays(i), DateTime.Now.AddDays(30 + i)));
        }

        _students.ForEach(student =>
        {
            _courses.ForEach(course =>
            {
                _contractCourseService.ContractCourse(student.Id, course.Id, 50);
            });
        });
    }

    protected override void When()
    {
        try
        {
            _contractCourseList = _contractCourseService.GetListContractCourse(DateTime.Now.AddMonths(10), DateTime.Now.AddDays(50), pageSize: 132);
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
        _exception.Message.Should().Be("The start date cannot be greater than the end date");
    }

}
