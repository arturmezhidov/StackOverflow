
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.BusinessModels
{
	public class UserRating
	{
		public int Questions { get; set; }
		public int Answers { get; set; }
		public int LikeAnswers { get; set; }
		public int AcceptedAnswers { get; set; }
	}
}
