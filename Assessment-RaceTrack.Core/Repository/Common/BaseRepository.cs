using Assessment_RaceTrack.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace  Assessment_RaceTrack.Core.Repository.Common
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public RaceTrackContext context;
        public DbSet<T> dbSet;
        public BaseRepository(IUnitOfWork iUnitOfWork)
        {
            this.context = iUnitOfWork.DBContext;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return  orderBy(query).ToList();
            }
            else
            {
                return  query.ToList();
            }
        }

        public virtual async Task<T> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual T Insert(T entity)
        {
            var res= dbSet.Add(entity);
            this.context.SaveChanges();
            return res;
        }

        public virtual void  Delete(object id)
        {
            T entityToDelete =  dbSet.Find(id);
             Delete(entityToDelete).ConfigureAwait(false);
            this.context.SaveChanges();
        }

        public virtual async Task Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual async Task Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
