using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Data.DataAccess.DataContexts
{
	public class DataContext : IdentityDbContext<User>
	{
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Like> Likes { get; set; }

		public DataContext(string connectionString)
			: base(connectionString)
		{
			
		}
	}
}
