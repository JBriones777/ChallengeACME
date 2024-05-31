using ACME.Core.CustomEntity;
using ACME.Core.Entities;
using ACME.Core.Interfaces.Repositories;

namespace ACME.Core.Repositories;

public interface IContractCourseRepository : IBaseRepository<ContractCourse>
{
    PaginationInfo<ContractCourse> GetByRange(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 10);
}