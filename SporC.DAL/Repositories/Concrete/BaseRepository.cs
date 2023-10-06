using Microsoft.EntityFrameworkCore;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Abstract;
using SporCDAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SporC.DAL.Repositories.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly SqlDbContext _context;
        private readonly DbSet<T> _dbset;

        public BaseRepository(SqlDbContext context) 
        {
            _context = context;
            _dbset = _context.Set<T>();
        }


        public async Task<int> Delete(T input)
        {
            _dbset.Remove(input);
            return await _context.SaveChangesAsync();
        }

        public  IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return  _dbset.Where(x => x.IsDeleted == false).Where(filter);
        }

        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[]? include)
        {
            IQueryable<T> query;
            if (filter != null)
            {
                query = _dbset.Where(filter);
            }
            query = _dbset;

            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);

        }

     
        public async Task<int> Insert(T input)
        {
            _dbset.AddAsync(input);
            return await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();

        }

        public async Task<int> Update(T input)
        {
            _dbset.Update(input);
            return await _context.SaveChangesAsync();
        }

       
    }
}
