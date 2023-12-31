﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SporC.Entities;
using SporCDAL.EntitiyConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.DAL.EntitiyConfigurations.Concrete
{
    public class UserConfig : BaseConfig<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.Description).HasMaxLength(255);
        }

    }

}
