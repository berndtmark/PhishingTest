using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PhishingTest.DataAccessLayer.DataContext;

namespace PhishingTest.DataAccessLayer.Repository
{
    public abstract class RepositoryBase
    {
        protected PSDataContext Context;

        public RepositoryBase(PSDataContext context)
        {
            Context = context;
        }

        protected TEntity Find<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            IQueryable<TEntity> items = FindAll<TEntity>(filter);

            // Relies on FindAll returning an IQueryable that allows 'deferred-loading'
            TEntity item = items.SingleOrDefault();

            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Entity not found");
            }
        }

        protected IQueryable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return FindAll<TEntity>(null);
        }

        protected IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            if (filter == null)
            {
                return this.Context.Set<TEntity>();
            }
            else
            {
                return this.Context.Set<TEntity>().Where(filter);
            }
        }

        protected void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
                this.Context = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
