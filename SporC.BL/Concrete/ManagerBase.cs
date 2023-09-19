using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        private readonly IBaseRepository<T> repository;

        public ManagerBase(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }


        public async virtual Task<int> Insert(T entity)
        {
            return await repository.Insert(entity);
        }

        public async virtual Task<int> Update(T entity)
        {
            return await repository.Update(entity);
        }
        public async virtual Task<int> Delete(T entity)
        {
            return await repository.Delete(entity);
        }
        public async virtual Task<T?> GetById(int id)
        {
            return await repository.GetById(id);
        }
        public async virtual Task<ICollection<T>>? GetAll(Expression<Func<T, bool>>? filter)
        {
            return await repository.GetAll(filter);
        }

        public async virtual Task<IQueryable<T>>? GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            return await repository.GetAllInclude(filter, include);
        }




    }
}
