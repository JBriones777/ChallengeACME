using ACME.Core.Entities;
using ACME.Core.Interfaces.Services;
using ACME.Core.Repositories;

namespace ACME.Core.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService()
    {
        _unitOfWork = new UnitOfWork();
    }

    public Course RegisterCourse(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
        if (registrationFee < 0) throw new ArgumentException("registrationFee cannot be negative");
        if (startDate < DateTime.Now) throw new ArgumentException("The start date cannot be less than today");
        if (startDate > endDate) throw new ArgumentException("The start date cannot be greater than the end date");

        var course = new Course
        {
            Name = name,
            RegistrationFee = registrationFee,
            StartDate = startDate,
            EndDate = endDate
        };
        _unitOfWork.CourseRepository.Create(course);
        return course;
    }
}
