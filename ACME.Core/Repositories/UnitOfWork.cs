using ACME.Core.Entities;
using ACME.Core.Interfaces.Repositories;

namespace ACME.Core.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IBaseRepository<Course> _courseRepository;
    private IBaseRepository<Student> _studentRepository;
    private IContractCourseRepository _contractCourseRepository;

    public IBaseRepository<Course> CourseRepository
    {
        get
        {
            if (_courseRepository == null)
                _courseRepository = new BaseRepository<Course>();

            return _courseRepository;
        }
    }

    public IBaseRepository<Student> StudentRepository
    {
        get
        {
            if (_studentRepository == null)
                _studentRepository = new BaseRepository<Student>();

            return _studentRepository;
        }
    }

    public IContractCourseRepository ContractCourseRepository
    {
        get
        {
            if (_contractCourseRepository == null)
                _contractCourseRepository = new ContractCourseRepository();

            return _contractCourseRepository;
        }
    }

}
