using ACME.Core.Entities;
using ACME.Core.Repositories;

namespace ACME.Core.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService()
    {
        _unitOfWork = new UnitOfWork();
    }

    public Student RegisterStudent(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

        if (age < 18)
            throw new InvalidOperationException("Only adults can register.");

        var student = new Student
        {
            Name = name,
            Age = age
        };

        _unitOfWork.StudentRepository.Create(student);
        return student;
    }
}
