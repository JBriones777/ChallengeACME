using ACME.Core.CustomEntity;
using ACME.Core.Entities;

namespace ACME.Core.Interfaces.Services;

public interface IContractCourseService
{
    ContractCourse ContractCourse(Guid studenId, Guid courseId, decimal amount);
    PaginationInfo<ContractCourse> GetListContractCourse(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 10);
}