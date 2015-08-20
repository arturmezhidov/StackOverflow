using StackOverflow.Data.DataAccess.DataContexts;
using StackOverflow.Data.Entities;

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
