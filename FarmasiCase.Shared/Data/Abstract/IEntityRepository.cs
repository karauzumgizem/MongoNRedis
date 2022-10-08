using FarmasiCase.Shared.Data.Paging;
using FarmasiCase.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FarmasiCase.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        PaginatedList<T> GetAllWithPaging(int pageIndex = 1, int pageSize = 10, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T Add(T entity);
        List<T> AddRange(List<T> entityList);
        T Update(T entity);
        List<T> UpdateRange(List<T> entityList);
        void Delete(T entity);
        void DeleteRange(List<T> entityList);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);

    }
}
