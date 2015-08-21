using StackOverflow.Data.DataAccess.DataContexts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Data.DataAccess.Repositories
{
	public class AnswerRepository : BaseRepository<Answer>
	{
		public AnswerRepository(DataContext context)
			: base(context, context.Answers)
		{
		}
	}
}
