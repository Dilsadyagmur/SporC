using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.BL.Concrete
{
    public class PictureManager : ManagerBase<Picture>, IPictureManager
    {
        public PictureManager(IRepository<Picture> repository) : base(repository)
        {
        }
    }
}
