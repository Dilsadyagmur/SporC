using SporC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.DAL.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Team> Teams { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Post> Posts { get; }
        IRepository<Picture> Pictures { get; }
        IRepository<Category> Categories { get; }

       

        void Save();
    }
}
