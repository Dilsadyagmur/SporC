using Azure;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities;
using SporCDAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.DAL.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _context;

        public IRepository<User> Users { get; private set; }

        public IRepository<Team> Teams { get; private set; }

        public IRepository<Comment> Comments { get; private set; }

        public IRepository<Post> Posts { get; private set; }

        public IRepository<Picture> Pictures { get; private set; }

        public IRepository<Category> Categories { get; private set; }

       

        public UnitOfWork (SqlDbContext context)
        {
            _context = context;

           
            Users = new Repository<User>(_context);
            Teams = new Repository<Team>(_context);
            Comments = new Repository<Comment>(_context);
            Posts = new Repository<Post>(_context);
            Pictures = new Repository<Picture>(_context);
            Categories = new Repository<Category>(_context);
        }

        public void Save()
        {
            
        }
    }
}
