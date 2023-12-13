using Microsoft.EntityFrameworkCore;
using SporC.Entities;
using System.Reflection;
using System.Reflection.Emit;

namespace SporCDAL.Contexts
{
    public class SqlDbContext : DbContext
    {
     

        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) 
        {

        
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SporC;Trusted_Connection=True;");

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserType> UserTypes { get; set; }  
        public DbSet<Picture> Pictures { get; set; }    
    }
}