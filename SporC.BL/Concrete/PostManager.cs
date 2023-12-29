using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SporC.Entities;

namespace SporC.BL.Concrete
{
    public class PostManager : ManagerBase<Post>, IPostManager
    {
        private readonly IRepository<Post> repository;

        public PostManager(IRepository<Post> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<int> CountUserPostsAsync(int userId, DateTime lastMinute)
        {
            return await repository.CountAsync(p => p.UserId == userId && p.CreateDate >= lastMinute);

        }
    }
}
