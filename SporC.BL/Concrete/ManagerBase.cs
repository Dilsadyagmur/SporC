using Microsoft.EntityFrameworkCore;
using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities;
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
        private readonly IRepository<T> repository;

        public ManagerBase(IRepository<T> repository)
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
        

        public async virtual Task<IQueryable<T>>? GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            return await repository.GetAllInclude(filter, include);
        }

        public Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

		public async virtual  Task<IQueryable<T>> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
