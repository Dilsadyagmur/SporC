using SporC.Entities.Concrete;
using SporC.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Abstract
{
    public interface ICommentManager : IBaseRepository<Comment> 
    {
    }
}
