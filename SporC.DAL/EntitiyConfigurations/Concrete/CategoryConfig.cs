using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SporC.Entities;
using SporCDAL.EntitiyConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporCDAL.EntitiyConfigurations.Concrete
{
    public class CategoryConfig : BaseConfig<Category> 
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(c => c.CategoryName).HasMaxLength(20);
			builder.HasIndex(c=>c.CategoryName).IsUnique();
			builder.HasData(new Category { CategoryName = "Scouting" },
				new Category { CategoryName = "Transfer" },
				new Category { CategoryName = "Match Analysis" },
				new Category { CategoryName = "Other News" }
				);

		}
	}
}
