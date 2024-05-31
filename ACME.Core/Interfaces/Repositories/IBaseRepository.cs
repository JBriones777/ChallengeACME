using ACME.Core.CustomEntity;
using ACME.Core.Entities;

namespace ACME.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    T GetById(Guid id);
    PaginationInfo<T> GetList(int page = 1, int pageSize = 10);
}