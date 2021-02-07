using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_RaceTrack.Core.Repository.Common
{
    public interface IRepository<T> where T:class
    {
        Task Delete(T entityToDelete);
       void  Delete(object id);
       IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             string includeProperties = "");
        Task<T> GetByID(object id);

        T Insert(T entity);
        Task Update(T entityToUpdate);
    }
}
