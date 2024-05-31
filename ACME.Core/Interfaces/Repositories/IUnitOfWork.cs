using ACME.Core.Entities;
using ACME.Core.Interfaces.Repositories;

namespace ACME.Core.Repositories;

public interface IUnitOfWork
{
    IContractCourseRepository ContractCourseRepository { get; }
    IBaseRepository<Course> CourseRepository { get; }
    IBaseRepository<Student> StudentRepository { get; }
}