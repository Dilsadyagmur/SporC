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
    public class CategoryManager : ManagerBase<Category>, ICategoryManager
    {
        private readonly IRepository<Category> repository;

        public CategoryManager(IRepository<Category> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
