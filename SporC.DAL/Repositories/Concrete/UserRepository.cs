using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;
using SporCDAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.DAL.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlDbContext context) : base(context)
        {
        }
    }
}
