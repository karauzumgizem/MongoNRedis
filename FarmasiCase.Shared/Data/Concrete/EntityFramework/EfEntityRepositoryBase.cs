using FarmasiCase.Shared.Data.Abstract;
using FarmasiCase.Shared.Data.Paging;
using FarmasiCase.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace FarmasiCase.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        //public EfEntityRepositoryBase(DbContext context)
        //{
        //    _context = context;
        //}

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }
        public List<TEntity> AddRange(List<TEntity> entityList)
        {
            _context.Set<List<TEntity>>().AddRange(entityList);
            return entityList;
        }
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return (predicate == null ? _context.Set<TEntity>().Count() : _context.Set<TEntity>().Count(predicate));
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void DeleteRange(List<TEntity> entityList)
        {
            _context.Set<List<TEntity>>().RemoveRange(entityList);
        }
        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            
            return query.ToList<TEntity>();
        }
        public PaginatedList<TEntity> GetAllWithPaging(int pageIndex = 1, int pageSize = 20, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return PaginatedList<TEntity>.Create(query, pageIndex, pageSize);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.SingleOrDefault();
        }
        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity).State= EntityState.Modified;
            return entity;
        }
        public List<TEntity> UpdateRange(List<TEntity> entityList)
        {
            _context.Set<List<TEntity>>().UpdateRange(entityList);
            return entityList;
        }
    }
}
