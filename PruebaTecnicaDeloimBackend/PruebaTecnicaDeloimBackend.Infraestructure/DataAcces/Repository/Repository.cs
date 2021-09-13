using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Pagination;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Repository
{
    [ExcludeFromCodeCoverage]
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbcontext;
        private readonly DbSet<TEntity> _entities;
        private readonly IUnitOfWork _unitOfWork;
        public Repository(DbContext dbcontext, IUnitOfWork unitOfWork)
        {
            _dbcontext = dbcontext;

            //Desactivar la carga lenta de Entity Framework
            _dbcontext.ChangeTracker.LazyLoadingEnabled = false;

            //Desactivar consulta con seguimiento
            _dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _entities = dbcontext.Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties, IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<TEntity> Members
#pragma warning disable 1998

        public async Task<IQueryable<TEntity>> AsQueryable()
        {
            return _entities.AsQueryable();
        }

#pragma warning disable 1998

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable(), page, limit, orderBy, ascending);

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, int page, int limit, string orderBy, bool ascending = true)
        {
            return await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable().Where(where), page, limit, orderBy, ascending);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }


        public async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        public bool Insert(TEntity entity)
        {
            _entities.Add(entity);
            return _unitOfWork.Save() > 0;
        }

        public bool Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Added;
            }
            return _unitOfWork.Save() > 0;
        }

        public bool Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.Save() > 0;
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Modified;
            }
            return _unitOfWork.Save() > 0;
        }

        public bool Delete(TEntity entity)
        {
            if (_dbcontext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
            return _unitOfWork.Save() > 0;
        }

        public bool Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
            return _unitOfWork.Save() > 0;
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Deleted;
            }
            return _unitOfWork.Save() > 0;
        }
        #endregion
    }
}
