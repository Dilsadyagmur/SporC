using SporC.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Abstract
{
    public interface IManagerBase<T> where T : BaseEntity
    {
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<T> GetById(int id);
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> filter);
        Task<IQueryable<T>>? GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include);
    }
}
