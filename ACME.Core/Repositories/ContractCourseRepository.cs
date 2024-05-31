using ACME.Core.CustomEntity;
using ACME.Core.Entities;

namespace ACME.Core.Repositories;

internal class ContractCourseRepository : BaseRepository<ContractCourse>, IContractCourseRepository
{
    public virtual PaginationInfo<ContractCourse> GetByRange(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 10)
    {
        var contractCourses = _list.AsQueryable().Where(x => x.Course.StartDate.Date >= startDate.Date && x.Course.EndDate.Date <= endDate.Date);
        var totalCount = contractCourses.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        var paginationInfo = new PaginationInfo<ContractCourse>();
        paginationInfo.TotalCount = totalCount;
        paginationInfo.TotalPages = totalPages;
        paginationInfo.Page = page;
        paginationInfo.PageSize = pageSize;
        paginationInfo.Data = contractCourses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return paginationInfo;
    }
}
