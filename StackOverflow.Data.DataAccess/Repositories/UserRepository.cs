using StackOverflow.Data.DataAccess.DataContexts;
using StackOverflow.Data.Entities;

namespace StackOverflow.Data.DataAccess.Repositories
{
	public class UserRepository : BaseRepository<User>
	{
		public UserRepository(DataContext context)
			: base(context, context.Users)
		{
		}
	}
}
