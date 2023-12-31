﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class Team : BaseEntity
    {
        public string? TeamName { get; set; }
        public string? LogoUrl { get; set; }

        public virtual ICollection<User?> Users { get; set; }= new List<User>();
        public virtual ICollection<Post?> Posts { get; set; }= new List<Post>();
    }
}
