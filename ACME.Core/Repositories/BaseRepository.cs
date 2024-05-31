using ACME.Core.CustomEntity;
using ACME.Core.Entities;
using ACME.Core.Interfaces.Repositories;
using System.Collections.Concurrent;

namespace ACME.Core.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected static ConcurrentBag<T> _list = new();

    public virtual void Create(T entity)
    {
        entity.Id = Guid.NewGuid();
        _list.Add(entity);
    }

    public virtual PaginationInfo<T> GetList(int page = 1, int pageSize = 10)
    {
        var totalPages = (int)Math.Ceiling((double)_list.Count / pageSize);
        var paginationInfo = new PaginationInfo<T>();
        paginationInfo.TotalCount = _list.Count;
        paginationInfo.TotalPages = totalPages;
        paginationInfo.Page = page;
        paginationInfo.PageSize = pageSize;
        paginationInfo.Data = _list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return paginationInfo;
    }

    public virtual T GetById(Guid id) => _list.FirstOrDefault(x => x.Id == id);

}
