using Microsoft.EntityFrameworkCore;
using SporC.Entities.Concrete;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace SporCDAL.Contexts
{
    public class SqlDbContext : IdentityDbContext<User>
    {
     

        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) 
        {

        
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer(@"Server=tcp:dilsadygmr.database.windows.net,1433;Initial Catalog=SporC;Persist Security Info=False;User ID=admindilsad;Password=Dilsad123-123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
       

        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserType> UserTypes { get; set; }  
        
    }
}