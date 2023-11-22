using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Concrete
{
    public class UserManager : ManagerBase<User>, IUserManager
    {
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> repository) : base(repository)
        {
            _userRepository = repository;
        }

		
	}
}
