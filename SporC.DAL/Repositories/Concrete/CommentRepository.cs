using SporC.Entities.Concrete;
using SporC.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SporCDAL.Contexts;

namespace SporC.DAL.Repositories.Concrete
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(SqlDbContext context) : base(context)
        {
        }
    }
}
