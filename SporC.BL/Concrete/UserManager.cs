using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Concrete
{
    public class UserManager : ManagerBase<User>, IUserManager
    {
        private readonly IRepository<User> repository;

        public UserManager(IRepository<User> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
