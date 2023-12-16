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
    public class TeamManager : ManagerBase<Team>, ITeamManager
    {
        private readonly IRepository<Team> repository;

        public TeamManager(IRepository<Team> repository) : base(repository)
        {
            this.repository = repository;
        }

     

        IQueryable<Team> ITeamManager.GetAllTeams()
        {
            return repository.GetAll();   
        }
    }
}
