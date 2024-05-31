using ACME.Core.CustomEntity;
using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Services;
using ACME.Test.Helpers;
using FluentAssertions;

namespace ACME.Test.ContractCourseTests;

public class ListContractCourseSuccess : BaseTest
{
    private IContractCourseService _contractCourseService;
    private IStudentService _studentService;
    private ICourseService _courseService;
    private List<Student> _students;
    private List<Course> _courses;
    private PaginationInfo<ContractCourse> _contractCourseList;
    private PaginationInfo<ContractCourse> _contractCourseListEmpty;
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
        _contractCourseList = _contractCourseService.GetListContractCourse(DateTime.Now, DateTime.Now.AddDays(50), pageSize: 132);
        _contractCourseListEmpty = _contractCourseService.GetListContractCourse(DateTime.Now.AddMonths(1), DateTime.Now.AddMonths(2), pageSize: 132);
    }

    [Fact]
    public void Then_Success()
    {
        _contractCourseList.Data.Should().HaveCount(132);
    }
    
    [Fact]
    public void Then_Success_Empty()
    {
        _contractCourseListEmpty.TotalCount.Should().Be(0);
        _contractCourseListEmpty.Data.Should().HaveCount(0);
    }
}
