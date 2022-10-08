using FarmasiCase.Shared.Data.Paging;
using System.Linq.Expressions;

namespace FarmasiCase.Shared.Service.Abstract
{
    public interface IService<TDto, TEntity>
    {
        TDto Get(Expression<Func<TEntity, bool>> predicate);
        List<TDto> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        PaginatedList<TDto> GetAllWithPaging(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate = null);
        TDto Add(TDto dto);
        TDto Update(TDto dto);
        void Delete(string id);
    }
}
