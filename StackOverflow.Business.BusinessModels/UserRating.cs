using StackOverflow.Data.Entities;

namespace StackOverflow.Business.BusinessModels
{
	public class UserRating
	{
		public ApplicationUser User { get; set; }
		public int Questions { get; set; }
		public int Answers { get; set; }
		public int LikeAnswers { get; set; }
		public int AcceptedAnswers { get; set; }

		public UserRating()
		{
		}
		public UserRating(ApplicationUser user)
		{
			User = user;
		}
	}
}
