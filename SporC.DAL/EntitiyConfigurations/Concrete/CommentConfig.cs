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
    public class CommentConfig : BaseConfig<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Content).HasMaxLength(500);
            

        }
    }
}
