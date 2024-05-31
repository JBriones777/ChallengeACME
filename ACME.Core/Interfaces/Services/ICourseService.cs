using ACME.Core.Entities;

namespace ACME.Core.Interfaces.Services;

public interface ICourseService
{
    Course RegisterCourse(string name, decimal registrationFee, DateTime startDate, DateTime endDate);
}