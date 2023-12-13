using SporC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Abstract
{
    public interface IUserManager : IManagerBase<User>
    {

        Task<int> GetCurrentUserIdAsync();
        Task<User> FindByEmailOrUsernameAsync(string emailOrUsername);

    }
}
