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
    public class PostConfig : BaseConfig<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder); 
            builder.Property(p=>p.Title).HasMaxLength(20);
            builder.Property(p=>p.Content).HasMaxLength(1000);

        }
    }
}
