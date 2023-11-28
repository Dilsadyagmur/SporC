using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Utilities;
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

        public virtual async Task<int> Delete(T input)
        {
            return await repository.Delete(input);

        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);   
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return repository.GetAll(filter);
        }

        public  IQueryable<T> GetAll()
        {
            return repository.GetAll().Where(i=>i.IsDeleted==false);
        }

        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            return await repository.GetAllInclude(filter, include);
        }

        public async Task<T> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public IQueryable<T> GetByIdforInc(int id)
        {
            return repository.GetByIdforInc(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return repository.GetFirstOrDefault(filter);
        }

        public async Task<int> Insert(T input)
        {
            return await repository.Insert(input);
        }

        public void Save()
        {
            repository.Save();
        }

        public async Task<int> Update(T input)
        {
            return await repository.Update(input);
        }
    }
}
