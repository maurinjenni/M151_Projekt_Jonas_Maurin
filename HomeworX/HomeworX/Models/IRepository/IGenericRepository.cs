using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeworX.Models.IRepository
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        TEntity Get(Guid uid);

        void Insert(TEntity entity);

        void Delete(Guid uid);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
