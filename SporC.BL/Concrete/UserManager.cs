using Microsoft.AspNetCore.Http;
using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Concrete
{
    public class UserManager : ManagerBase<User>, IUserManager
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IRepository<User> repository, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _userRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async  Task<int> GetCurrentUserIdAsync()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await Task.FromResult(userId);
        }
    }
}
