
using SporC.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities.Concrete
{
	public class Team : BaseEntity
	{
        public string TeamName { get; set; }

        public Category? categories { get; set; }

        public string LogoUrl { get; set; }

        public virtual ICollection<User?> Users { get; set; }    
        public virtual ICollection<Post?> Posts { get; set; }
    }
}
