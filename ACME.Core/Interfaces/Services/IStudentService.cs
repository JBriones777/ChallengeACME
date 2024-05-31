using ACME.Core.Entities;

namespace ACME.Core.Services;

public interface IStudentService
{
    Student RegisterStudent(string name, int age);
}