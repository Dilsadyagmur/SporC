﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SporC.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporCDAL.EntitiyConfigurations.Abstract
{
	public class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(p => p.Id.ToString());
			builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
		}
	}
}