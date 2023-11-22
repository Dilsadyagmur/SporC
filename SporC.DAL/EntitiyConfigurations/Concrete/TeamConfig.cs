using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SporC.Entities;
using SporCDAL.EntitiyConfigurations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SporCDAL.EntitiyConfigurations.Concrete
{
    public class TeamConfig : BaseConfig<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(t => t.TeamName).HasMaxLength(25);
            builder.HasIndex(t => t.TeamName).IsUnique();
            builder.Property(t => t.LogoUrl).HasMaxLength(70);
            builder.HasData(new Team { Id=1, TeamName="Galatasaray", LogoUrl= "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000162_120x120.png" },              
                new Team { Id = 2, TeamName = "Trabzonspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000154_120x120.png" },
                new Team { Id = 3, TeamName = "Beşiktaş JK", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000148_120x120.png" },
                new Team { Id = 4, TeamName = "Konyaspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000158_120x120.png" },
                new Team { Id = 5, TeamName = "Rizespor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000189_120x120.png" },
                new Team {Id = 6, TeamName = "HataySpor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000122_120x120.png" },
                new Team { Id = 7, TeamName = "Alanyaspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000050_120x120.png" },
                new Team {Id = 8, TeamName = "Kayserispor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000071_120x120.png" },
                new Team { Id = 9, TeamName = "Antalyaspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000051_120x120.png" },
                new Team { Id = 10, TeamName = "Adana Demirspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000161_120x120.png" },
                new Team {Id = 11, TeamName = "Sivasspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000073_120x120.png" },
                new Team {Id = 12, TeamName = "Kasımpaşa", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000038_120x120.png" },
                new Team {Id = 13, TeamName = "Karagümrük", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000169_120x120.png" },
                new Team {Id = 14, TeamName = "Pendikspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000181_120x120.png" },
                new Team {Id = 15, TeamName = "Samsunspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000155_120x120.png" },
                new Team {Id = 16, TeamName = "Başakşehir", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000240_120x120.png" },
                new Team {Id = 17, TeamName = "İstanbulspor", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000175_120x120.png" },
                new Team {Id = 18 ,TeamName = "Gaziantep FK", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000251_120x120.png" },
                new Team {Id = 19, TeamName = "Ankaragücü", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000153_120x120.png" },
                new Team { Id = 20, TeamName = "Fenerbahçe", LogoUrl = "https://fys.tff.org/TFFUploadFolder/KulupLogolari/000150_120x120.png" });
            

        }
    }
}
