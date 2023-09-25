using SporC.BL.Abstract;
using SporC.Entities.Concrete;
using SporC.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Concrete
{
    public class CommentManager : ManagerBase<Comment>, ICommentManager
    {
        public CommentManager(IRepository<Comment> repository) : base(repository)
        {
        }
    }
}
