using SporC.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SporCDAL.Contexts;
using SporC.Entities;

namespace SporC.DAL.Repositories.Concrete
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(SqlDbContext context) : base(context)
        {
        }
    }
}
