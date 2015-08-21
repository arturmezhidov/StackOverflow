using StackOverflow.Data.DataAccess.DataContexts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Data.DataAccess.Repositories
{
	public class QuestionRepository : BaseRepository<Question>
	{
		public QuestionRepository(DataContext context)
			: base(context, context.Questions)
		{
		}
	}
}
